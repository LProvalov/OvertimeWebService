using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using WebAPI.DataProviders;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [EnableCors("AllowCors")]
    [Route("api/[controller]")]
    [Authorize]
    public class MeController : Controller
    {
        public MeController(IMainDataProvider dataProvider)
        {
            DataProvider = dataProvider;
        }

        public IMainDataProvider DataProvider { get; set; }

        public string Get()
        {
            var username = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return $"Hello, {username}.";
        }

    }
}
