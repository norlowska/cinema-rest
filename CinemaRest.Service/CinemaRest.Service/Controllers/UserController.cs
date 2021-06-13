using CinemaRest.Service.Enums;
using CinemaRest.Service.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaRest.Service.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [HeaderAuthorizationBasic]
    public class UserController : ControllerBase
    {

        private const string ENDPOINT = "/api/user";
        private const string REL_LOGIN = "login";
        private const string REL_SELF = "self";
        private string HOST = string.Empty;

        public UserController() { }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type=typeof(string))]
        public IActionResult Login()
        {
            try
            {
                HOST = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host;
                return new OkObjectResult(new { Message = "Success", Links = GetLinks(Guid.Empty, REL_LOGIN) });
            }
            catch (Exception ex)
            {
                return new UnauthorizedObjectResult("Wystąpił błąd podczas aktualizacji rezerwacji. " + ex.Message);
            }
        }

        private List<Link> GetLinks(Guid id, string self)
        {
            string url = HOST + ENDPOINT + "/";
            return new List<Link>()
            {
                new Link()
                {
                    Method=HttpMethodEnum.GET.ToString(),
                    Rel= self == REL_LOGIN ? REL_SELF : REL_LOGIN,
                    Href= url + "Login"
                }
            };
        }
    }
}
