using Microsoft.AspNetCore.Mvc;
using Rmdb.Domain.Dtos.Movies;
using Rmdb.Domain.Model;
using Rmdb.Domain.Services;
using System.Collections.Generic;

namespace Rmdb.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieListDto>> Get()
        {
            return Ok(_movieService.GetMovies());
        }
    }
}
