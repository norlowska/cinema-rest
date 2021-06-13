using CinemaRest.Service.Enums;
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
    public class MovieController : ControllerBase
    {
        private readonly ICinemaContext _context;
        private const string ENDPOINT = "/api/movie";
        private const string REL_GET_ALL = "get_movies";
        private const string REL_GET_POSTER = "get_movie_poster";
        private const string REL_SELF = "self";
        private string HOST = string.Empty;
        public MovieController(ICinemaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Movie> GetMovies([FromQuery] string date)
        {
            HOST = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host;
            List<Movie> movies = new List<Movie>();
            if (string.IsNullOrEmpty(date))
                movies = Movie.GetAll((CinemaContext)_context);
            else
                movies = Movie.GetRepertoire((CinemaContext)_context, DateTime.Parse(date));
            
            foreach(Movie m in movies)
            {
                m.Links.AddRange(GetLinks(m.Id, REL_GET_ALL));
            }
            return movies;
        }

        [HttpGet("{id}/Poster")]
        public IActionResult GetPoster(Guid id)
        {
            HOST = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host;
            Movie movie = Movie.GetById((CinemaContext)_context, id);
            if (movie == null) return NotFound();
            byte[] bytes = movie.ImageData;
            return File(bytes, "image/jpeg");
        }

        private List<Link> GetLinks(Guid id, string self)
        {
            string url = HOST + ENDPOINT + "/";
            return new List<Link>()
            {
                new Link()
                {
                    Method=HttpMethodEnum.GET.ToString(),
                    Rel= self == REL_GET_ALL ? REL_SELF : REL_GET_ALL,
                    Href= url
                },
                new Link()
                {
                    Method=HttpMethodEnum.GET.ToString(),
                    Rel= self == REL_GET_POSTER ? REL_SELF : REL_GET_POSTER,
                    Href= url + id + "/Poster"
                }
            };
        }
    }
}
