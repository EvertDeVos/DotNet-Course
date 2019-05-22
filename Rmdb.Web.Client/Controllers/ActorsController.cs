using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rmdb.Web.Client.Data;
using Rmdb.Web.Client.Data.Contracts;
using Rmdb.Web.Client.Model;
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
            var actors = (await _actorService.GetAllAsync());
            var viewModels = Mapper.Map<IEnumerable<ActorViewModel>>(actors);

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

            var actor = Mapper.Map<Actor>(viewModel);
            await _actorService.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var actor = await _actorService.GetAsync(id);
            var viewModel = Mapper.Map<ActorUpdateViewModel>(actor);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, ActorUpdateViewModel viewModel)
        {

            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }

            var actor = Mapper.Map<Actor>(viewModel);

            await _actorService.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _actorService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}