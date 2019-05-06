using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rmdb.Domain.Model;
using Rmdb.Domain.Model.Extensions;
using Rmdb.Web.Client.Data;
using Rmdb.Web.Client.Data.Contracts;
using Rmdb.Web.Client.ViewModels.Actors;

namespace Rmdb.Web.Client.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModels = (await _actorService.GetAll())
                .Select(actor => new ActorViewModel
                {
                    Id = actor.Id,
                    FullName = $"{actor.Name}, {actor.LastName}",
                    Age = actor.BirthDate.HasValue
                        ? actor.BirthDate.Value.CalculateAge(actor.Deceased).ToString()
                        : "Onbekend"
                });

            return View(viewModels);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorCreateViewModel viewModel)
        {

            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }

            var actor = new Person(viewModel.Name, viewModel.LastName)
            {
                BirthDate = viewModel.BirthDate,
                Deceased = viewModel.Deceased
            };
            await _actorService.Add(actor);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var actor = await _actorService.Get(id);
            var viewModel = new ActorUpdateViewModel
            {
                Name = actor.Name,
                LastName = actor.LastName,
                BirthDate = actor.BirthDate ?? default,
                Deceased = actor.Deceased ?? default,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, ActorUpdateViewModel viewModel)
        {

            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }
            
            var actor = new Person(viewModel.Name, viewModel.LastName)
            {
                BirthDate = viewModel.BirthDate,
                Deceased = viewModel.Deceased
            };
            await _actorService.Update(id, actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _actorService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}