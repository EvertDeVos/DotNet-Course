using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rmdb.Domain.Model;
using Rmdb.Domain.Model.Extensions;
using Rmdb.Web.Client.Data;
using Rmdb.Web.Client.ViewModels.Actors;

namespace Rmdb.Web.Client.Controllers
{
    public class ActorsController : Controller
    {
        public IActionResult Index()
        {
            var repository = new ActorRepository(HttpContext.Session);
            var viewModels = repository.Actors
                .Select(director => new ActorViewModel
                {
                    Id = director.Id,
                    FullName = $"{director.Name}, {director.LastName}",
                    Age = director.BirthDate.HasValue
                        ? director.BirthDate.Value.CalculateAge(director.Deceased).ToString()
                        : "Onbekend"
                });

            return View(viewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ActorCreateViewModel viewModel)
        {

            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }

            var repository = new ActorRepository(HttpContext.Session);

            var director = new Person(viewModel.Name, viewModel.LastName)
            {
                BirthDate = viewModel.BirthDate,
                Deceased = viewModel.Deceased
            };
            repository.Add(director);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(Guid id)
        {
            var repository = new ActorRepository(HttpContext.Session);

            var director = repository.Get(id);
            var viewModel = new ActorUpdateViewModel
            {
                Name = director.Name,
                LastName = director.LastName,
                BirthDate = director.BirthDate ?? default,
                Deceased = director.Deceased ?? default,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(Guid id, ActorUpdateViewModel viewModel)
        {

            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }

            var repository = new ActorRepository(HttpContext.Session);

            var director = new Person(viewModel.Name, viewModel.LastName)
            {
                BirthDate = viewModel.BirthDate,
                Deceased = viewModel.Deceased
            };
            repository.Update(id, director);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            var repository = new ActorRepository(HttpContext.Session);
            repository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}