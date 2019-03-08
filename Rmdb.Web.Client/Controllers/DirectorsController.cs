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
                .Select(p => new DirectorViewModel
                {
                    Id = p.Id,
                    FullName = $"{p.Name}, {p.LastName}",
                    Age = p.BirthDate.HasValue
                        ? p.BirthDate.Value.CalculateAge(p.Deceased).ToString()
                        : "Onbekend"
                });

            return View(viewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DirectorCreateViewModel vm)
        {

            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            var repository = new DirectorRepository(HttpContext.Session);

            var person = new Person(vm.Name, vm.LastName) { BirthDate = vm.BirthDate, Deceased = vm.Deceased };
            repository.Add(person);

            return RedirectToAction("Index");
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
        public IActionResult Update(Guid id, DirectorUpdateViewModel vm)
        {

            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            var repository = new DirectorRepository(HttpContext.Session);

            var person = new Person(vm.Name, vm.LastName)
            {
                BirthDate = vm.BirthDate,
                Deceased = vm.Deceased
            };
            repository.Update(id, person);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var repository = new DirectorRepository(HttpContext.Session);
            repository.Delete(id);

            return RedirectToAction("Index");
        }

    }
}