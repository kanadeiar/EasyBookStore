using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EasyBookStore.Models;
using EasyBookStore.WebModels;
using EasyBookStore.Models.Data;

namespace EasyBookStore.Controllers
{
    public class WorkerController : Controller
    {
        private static readonly IList<Worker> __Workers = StaticData.GetWorkers;
        public IActionResult Index()
        {
            return View(__Workers);
        }

        public IActionResult Details(int id)
        {
            if (id < 0) return BadRequest();

            var worker = __Workers.FirstOrDefault(w => w.Id == id);

            if (worker is null) return NotFound();

            var workerWebModel = new WorkerDetailsWebModel
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Patronymic = worker.Patronymic,
                Age = worker.Age,
            };

            return View(workerWebModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null) return View(new WorkerEditWebModel());

            var worker = __Workers.FirstOrDefault(w => w.Id == id);
            if (worker is null) return NotFound();

            var model = new WorkerEditWebModel
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Patronymic = worker.Patronymic,
                Age = worker.Age,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(WorkerEditWebModel model)
        {
            var worker = new Worker
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                Age = model.Age,
            };
            if (worker.Id == 0)
                __Workers.Add(worker);
            else
                __Workers[__Workers.IndexOf(__Workers.FirstOrDefault(w => w.Id == worker.Id))] = worker;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var worker = __Workers.FirstOrDefault(w => w.Id == id);
            if (worker is null) return NotFound();

            var model = new WorkerEditWebModel
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Patronymic = worker.Patronymic,
                Age = worker.Age,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id <= 0) return BadRequest();

            __Workers.RemoveAt(__Workers.IndexOf(__Workers.FirstOrDefault(w => w.Id == id)));

            return RedirectToAction("Index");
        }
    }
}
