using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rmdb.Domain.Model;
using Rmdb.Domain.Model.Extensions;
using Rmdb.Web.Client.Data;
using Rmdb.Web.Client.ViewModels.Director;

namespace Rmdb.Web.Client.Controllers
{
    public class DirectorsController : Controller
    {
        public IActionResult Index()
        {
            var repository = new DirectorRepository(HttpContext.Session);
            var viewModels = repository.Directors
                .Select(director => new DirectorViewModel
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
        public IActionResult Create(DirectorCreateViewModel viewModel)
        {

            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }

            var repository = new DirectorRepository(HttpContext.Session);

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
            var repository = new DirectorRepository(HttpContext.Session);

            var director = repository.Get(id);
            var viewModel = new DirectorUpdateViewModel
            {
                Name = director.Name,
                LastName = director.LastName,
                BirthDate = director.BirthDate ?? default,
                Deceased = director.Deceased ?? default,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(Guid id, DirectorUpdateViewModel viewModel)
        {

            if (!TryValidateModel(viewModel))
            {
                return View(viewModel);
            }

            var repository = new DirectorRepository(HttpContext.Session);

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
            var repository = new DirectorRepository(HttpContext.Session);
            repository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}