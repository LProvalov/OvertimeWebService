using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebAPI.Repositories;
using WebAPI.Services;
using WebAPI.DataProviders;

namespace WebAPI.Auth
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private readonly JsonSerializerSettings _serializerSettings;

        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options)
        {
            this._next = next;
            this._options = options.Value;

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (!httpContext.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
            {
                return _next(httpContext);
            }

            if(!httpContext.Request.Method.Equals("POST") || !httpContext.Request.HasFormContentType){
                httpContext.Response.StatusCode = 400;
                return httpContext.Response.WriteAsync("Bad request");
            }

            return GenerateToken(httpContext);
        }

        private async Task GenerateToken(HttpContext context)
        {
            string username = context.Request.Form["username"];
            string email = context.Request.Form["email"];
            string password = context.Request.Form["password"];

            Task<ClaimsIdentity> identity = _options.IdentityResolver(username, email, password); //GetIdentity(username, email, password);
            if(identity.Result == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid username or email or password");
                return;
            }

            DateTime now = DateTime.UtcNow;
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, string.IsNullOrEmpty(username) ? "undefined" : username),
                new Claim(JwtRegisteredClaimNames.Email, string.IsNullOrEmpty(email) ? "undefined" : email),
                new Claim(JwtRegisteredClaimNames.Jti, await _options.NonceGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds
            };

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
        }
    }
}
