using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rmdb.Web.Client.Data.Contracts;
using Rmdb.Web.Client.Model;
using Rmdb.Web.Client.ViewModels.Actors;
using Rmdb.Web.Client.ViewModels.Movies;
using Rmdb.Web.Client.ViewModels.Shared;

namespace Rmdb.Web.Client.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;

        public MoviesController(IMovieService movieRepository, IActorService actorRepository)
        {
            _movieService = movieRepository;
            _actorService = actorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var movies = (await _movieService.GetAllAsync());
            var viewModels = Mapper.Map<IEnumerable<MovieViewModel>>(movies);

            return View(viewModels);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var movie = await _movieService.GetAsync(id);
            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var viewModel = Mapper.Map<MovieDetailsViewModel>(movie);
            var actors = await _actorService.GetAllAsync();
            viewModel.Items = actors
                .Select(actor => new SelectListItem($"{ actor.Name} {actor.LastName}", actor.Id.ToString()));

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Details(Guid id, SelectionViewModel selection)
        {
            if (await _movieService.AddActorAsync(id, selection.Selected) == null)
            {
                return RedirectToAction(nameof(Details), new { Id = id });
            }

            return RedirectToAction(nameof(Details));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateViewModel viewModel)
        {

            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }

            var movie = Mapper.Map<Movie>(viewModel);
            await _movieService.CreateAsync(movie);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(Guid id)
        {
            var movie = await _movieService.GetAsync(id);
            if (movie == null)
            {
                RedirectToAction(nameof(Create));
            }

            var viewModel = Mapper.Map<MovieUpdateViewModel>(movie);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, MovieUpdateViewModel viewModel)
        {
            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }

            var movie = Mapper.Map<Movie>(viewModel);
            await _movieService.UpdateAsync(id, movie);

            return RedirectToAction(nameof(Details));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var movie = _movieService.GetAsync(id);
            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            await _movieService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}