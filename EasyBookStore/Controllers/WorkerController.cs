using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EasyBookStore.Models;
using EasyBookStore.WebModels;
using EasyBookStore.Models.Data;
using EasyBookStore.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using EasyBookStore.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using EasyBookStore.Domain.Models.Identity;
using EasyBookStore.Services;

namespace EasyBookStore.Controllers
{
    [Route("Worker/[action]/{id?}")]
    [Authorize]
    public class WorkerController : Controller
    {
        private readonly IWorkerData _workerData;
        private readonly ILogger<WorkerController> _logger;
        private readonly IMapper<WorkerDetailsWebModel> _detailsMapper;
        private readonly IMapper<WorkerEditWebModel> _editMapper;
        private readonly IMapper<Worker> _workerMapper;

        public WorkerController(IWorkerData workerData, ILogger<WorkerController> logger, 
            IMapper<WorkerDetailsWebModel> detailsMapper, IMapper<WorkerEditWebModel> editMapper, IMapper<Worker> workerMapper)
        {
            _workerData = workerData;
            _logger = logger;
            _detailsMapper = detailsMapper;
            _editMapper = editMapper;
            _workerMapper = workerMapper;
        }   

        public async Task<IActionResult> Index()
        {
            var workers = await _workerData.GetAll();
            return View(workers);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id < 0) return BadRequest();

            var worker = await _workerData.Get(id);

            if (worker is null) return NotFound();

            var workerWebModel = _detailsMapper.Map(worker);
            return View(workerWebModel);
        }

        [Authorize(Roles = Role.Administrators)]
        public async Task<IActionResult> Create()
        {
            return View("Edit", new WorkerEditWebModel());
        }

        [Authorize(Roles = Role.Administrators)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is not { } workerId) return View(new WorkerEditWebModel());

            var worker = await _workerData.Get(workerId);
            if (worker is null) return NotFound();

            var model = _editMapper.Map(worker);
            return View(model);
        }

        [HttpPost, Authorize(Roles = Role.Administrators)]
        public async Task<IActionResult> Edit(WorkerEditWebModel model)
        {
            if (model is null)
                return BadRequest();
            if (model.FirstName == "Ленин")
                ModelState.AddModelError(nameof(model.FirstName), "Запрещено иметь имя \"Ленин\"");
            if (model.LastName == "Иванов" && model.FirstName == "Иван" && model.Patronymic == "Иванович")
                ModelState.AddModelError(string.Empty, "Нельзя иметь фамилию имя и отчество \"Иванов Иван Иванович\"");
            if (!ModelState.IsValid)
                return View(model);

            var worker = _workerMapper.Map(model);
            if (worker.Id == 0)
                await _workerData.Add(worker);
            else
                await _workerData.Update(worker);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = Role.Administrators)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var worker = await _workerData.Get(id);
            if (worker is null) return NotFound();

            var model = _editMapper.Map(worker);
            return View(model);
        }

        [HttpPost, Authorize(Roles = Role.Administrators)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0) return BadRequest();
            await _workerData.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
