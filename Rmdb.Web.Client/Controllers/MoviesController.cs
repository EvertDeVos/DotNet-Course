using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rmdb.Domain.Model;
using Rmdb.Web.Client.Data;
using Rmdb.Web.Client.ViewModels.Movie;

namespace Rmdb.Web.Client.Controllers
{
    public class MoviesController : Controller
    {

        public IActionResult Index()
        {
            var repository = new MovieRepository(HttpContext.Session);
            var viewModels = repository.Movies.Select(movie => new MovieViewModel
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

        public IActionResult Details(Guid id)
        {
            var repository = new MovieRepository(HttpContext.Session);
            var movie = repository.Get(id);
            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new MovieDetailsViewModel
            {
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Color = movie.Color,
                Score = movie.Score
            };

            return View(viewModel);
        }


        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel viewModel)
        {

            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }

            var repository = new MovieRepository(HttpContext.Session);
            repository.Create(new Movie(viewModel.Title)
            {
                Description = viewModel.Description,
                ReleaseDate = viewModel.ReleaseDate,
                RunTime = viewModel.RunTime,
                Score = viewModel.Score ?? default,
                Color = viewModel.Color
            });

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(Guid id)
        {
            var repository = new MovieRepository(HttpContext.Session);
            var movie = repository.Get(id);
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
        public IActionResult Update(Guid id, MovieUpdateViewModel viewModel)
        {
            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }

            var repository = new MovieRepository(HttpContext.Session);
            repository.Update(id, new Movie(viewModel.Title)
            {
                Description = viewModel.Description,
                ReleaseDate = viewModel.ReleaseDate,
                RunTime = viewModel.RunTime,
                Score = viewModel.Score ?? default,
                Color = viewModel.Color,
            });

            return RedirectToAction(nameof(Details));
        }

        public IActionResult Delete(Guid id) {

            var repository = new MovieRepository(HttpContext.Session);
            var movie = repository.Get(id);
            if (movie == null) {
                return RedirectToAction(nameof(Index));
            }

            repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}