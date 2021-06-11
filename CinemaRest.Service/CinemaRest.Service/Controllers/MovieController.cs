using CinemaRest.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CinemaRest.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [HeaderAuthorizationBasicAttribute]
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

        [HttpGet("{id}/Poster")]
        public FileResult GetPoster(Guid id)
        {
            byte[] bytes = Movie.GetById((CinemaContext)_context, id).ImageData;
            return File(bytes, "image/jpeg");
        }
    }
}
