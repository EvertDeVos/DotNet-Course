using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rmdb.Domain.Model;
using Rmdb.Web.Client.Data.Contracts;
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
            var viewModels = (await _movieService.GetAll())
                .Select(movie => new MovieViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Score = movie.Score,
                    ReleaseDate = movie.ReleaseDate.HasValue
                    ? movie.ReleaseDate.Value.ToShortDateString()
                    : "Onbekend"
                });

            return View(viewModels);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var movie = await _movieService.Get(id);
            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var actors = await _actorService.GetAll();
            var viewModel = new MovieDetailsViewModel
            {
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Color = movie.Color,
                Score = movie.Score,
                Actors = movie.Actors
                    .Select(ma => ma.Actor)
                    .Select(a => new ActorViewModel { FullName = $"{a.Name} {a.LastName}" }),
                Items = actors
                    .Select(actor => new SelectListItem($"{ actor.Name} {actor.LastName}", actor.Id.ToString()))
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Details(Guid id, SelectionViewModel selection)
        {
            if (await _movieService.AddActor(id, selection.Selected) == null)
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

            await _movieService.Create(new Movie(viewModel.Title)
            {
                Description = viewModel.Description,
                ReleaseDate = viewModel.ReleaseDate,
                RunTime = viewModel.RunTime,
                Score = viewModel.Score ?? default,
                Color = viewModel.Color
            });

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(Guid id)
        {
            var movie = await _movieService.Get(id);
            if (movie == null)
            {
                RedirectToAction(nameof(Create));
            }

            var viewModel = new MovieUpdateViewModel
            {
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Color = movie.Color,
                RunTime = movie.RunTime,
                Score = movie.Score
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, MovieUpdateViewModel viewModel)
        {
            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }

            await _movieService.Update(id, new Movie(viewModel.Title)
            {
                Description = viewModel.Description,
                ReleaseDate = viewModel.ReleaseDate,
                RunTime = viewModel.RunTime,
                Score = viewModel.Score ?? default,
                Color = viewModel.Color,
            });

            return RedirectToAction(nameof(Details));
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            var movie = _movieService.Get(id);
            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            await _movieService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}