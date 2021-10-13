using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EasyBookStore.Models;
using EasyBookStore.WebModels;

namespace EasyBookStore.Controllers
{
    public class WorkerController : Controller
    {
        private static readonly IEnumerable<Worker> __Workers = Worker.GetWorkers;
        public IActionResult Index()
        {
            return View(__Workers);
        }

        public IActionResult Details(int id)
        {
            var worker = __Workers.First(w => w.Id == id);

            if (worker is null)
                return NotFound();

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
    }
}
