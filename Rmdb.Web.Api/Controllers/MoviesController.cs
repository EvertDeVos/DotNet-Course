using Microsoft.AspNetCore.Mvc;
using Rmdb.Domain.Dtos.Movies;
using Rmdb.Domain.Model;
using Rmdb.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<MovieListDto>>> Get()
        {
            return Ok(await _movieService.GetMoviesAsync());
        }
    }
}
