using Microsoft.AspNetCore.Mvc;
using Rmdb.Domain.Dtos.Movies;
using Rmdb.Domain.Services;
using System;
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

        // GET api/movies
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _movieService.GetAsync());
        }

        // GET api/movies/{id}
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var movie = await _movieService.GetAsync(id);

            if(movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // POST api/movies
        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] AddMovieDto movie)
        {
            var id = await _movieService.AddAsync(movie);

            return CreatedAtAction("Get", new { Id = id });
        }
    }
}
