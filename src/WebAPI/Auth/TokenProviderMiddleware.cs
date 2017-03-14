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
        private readonly IMainDataProvider _dataProvider;

        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options, IMainDataProvider mainDataProvider)
        {
            this._next = next;
            this._options = options.Value;
            this._dataProvider = mainDataProvider;
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
            var username = context.Request.Form["username"];
            var email = context.Request.Form["email"];
            var password = context.Request.Form["password"];

            Task<ClaimsIdentity> identity = GetIdentity(username, email, password);
            if(identity == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid username or email or password");
                return;
            }

            DateTime now = DateTime.UtcNow;
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
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
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private Task<ClaimsIdentity> GetIdentity(string username, string email, string uncryptedPassword)
        {
            var dpResponse = _dataProvider.ValidateUser(username, email, uncryptedPassword);
            if(dpResponse.Data == true)
            {
                ClaimsIdentity ci = new ClaimsIdentity(new System.Security.Principal.GenericIdentity(username, "Token"), new Claim[] { });
                return Task.FromResult(ci);
            }
            // TODO: check cache
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
