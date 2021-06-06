using CinemaRest.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaRest.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ICinemaContext _context;
        public MovieController(ICinemaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Movie> GetMovies([FromQuery] string date)
        {
            if (string.IsNullOrEmpty(date))
                return Movie.GetAll((CinemaContext)_context);
            return Movie.GetRepertoire((CinemaContext)_context, DateTime.Parse(date));
        }
    }
}
