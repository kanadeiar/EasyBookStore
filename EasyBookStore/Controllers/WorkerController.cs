using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EasyBookStore.Models;

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
            return View(__Workers.First(w => w.Id == id));
        }
    }
}
