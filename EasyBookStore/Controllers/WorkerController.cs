using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    }
}
