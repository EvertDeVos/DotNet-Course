using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Rmdb.Domain.Dtos.Movies;
using Rmdb.Domain.Services;
using Rmdb.Web.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmdb.Web.Api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        // GET api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieListDto>>> Get()
        {
            return Ok(await _movieService.GetAsync());
        }

        // GET api/movies/{id}
        [HttpGet("{id:Guid}")]
        [RequestHeaderMatchesMediaType(HeaderNames.Accept,
            "application/json",
            "application/vnd.rmdb.movie+json")]
        public async Task<ActionResult<MovieDetailDto>> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var movie = await _movieService.GetAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // GET api/movies/{id}
        [HttpGet("{id:Guid}")]
        [RequestHeaderMatchesMediaType(HeaderNames.Accept,
            "application/json",
            "application/vnd.rmdb.moviewithactors+json")]
        public async Task<ActionResult<MovieDetailWithActorsDto>> GetWithActors(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var movie = await _movieService.GetWithActorsAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // POST api/movies
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddMovieDto addMovie)
        {
            var id = await _movieService.AddAsync(addMovie);

            return CreatedAtAction("Get", new { Id = id });
        }

        // PUT api/movies/{id}
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EditMovieDto editMovie)
        {
            var movie = await _movieService.UpdateAsync(id, editMovie);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // DELETE api/movies/{id}
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _movieService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST api/movies/{id}/actors
        [HttpPost("{id:Guid}/actors")]
        public async Task<IActionResult> AddActor(Guid id, [FromBody]AddActorToMovieDto addActor)
        {
            var actor = await _movieService.AddActorToMovieAsync(id, addActor);

            if(actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }
    }
}
