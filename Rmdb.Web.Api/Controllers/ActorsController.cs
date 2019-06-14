using Microsoft.AspNetCore.Mvc;
using Rmdb.Domain.Dtos.Actors;
using Rmdb.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmdb.Web.Api.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService ?? throw new ArgumentNullException(nameof(actorService));
        }

        // GET api/actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorListDto>>> Get()
        {
            return Ok(await _actorService.GetAsync());
        }

        // GET api/actors/{id}
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ActorDetailDto>> Get(Guid id)
        {
            var actor = await _actorService.GetAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        // POST api/actors
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddActorDto addActor)
        {
            var id = await _actorService.AddAsync(addActor);

            return CreatedAtAction(nameof(Get), new { Id = id });
        }

        // PUT api/actors/{id}
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ActorDetailDto>> Put(Guid id, [FromBody] EditActorDto editActor)
        {
            var movie = await _actorService.UpdateAsync(id, editActor);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // DELETE api/actors/{id}
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _actorService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
