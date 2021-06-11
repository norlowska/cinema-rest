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
        public UserController() { }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type=typeof(string))]
        public IActionResult Login()
        {
            try
            {
                return new OkObjectResult("Success");
            }
            catch (Exception ex)
            {
                return new UnauthorizedObjectResult("Wystąpił błąd podczas aktualizacji rezerwacji. " + ex.Message);
            }
        }
    }
}
