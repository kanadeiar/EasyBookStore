﻿using Microsoft.AspNetCore.Mvc;
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

namespace EasyBookStore.Controllers
{
    [Route("Worker/[action]/{id?}")]
    [Authorize]
    public class WorkerController : Controller
    {
        private readonly IWorkerData _workerData;
        private readonly ILogger<WorkerController> _logger;

        public WorkerController(IWorkerData workerData, ILogger<WorkerController> logger)
        {
            _workerData = workerData;
            _logger = logger;
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

        [Authorize(Roles = Role.Administrators)]
        public async Task<IActionResult> Create()
        {
            return View("Edit", new WorkerEditWebModel());
        }

        [Authorize(Roles = Role.Administrators)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return View(new WorkerEditWebModel());

            var worker = await _workerData.Get((int)id);
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

            var worker = new Worker
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                Age = model.Age,
            };
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

        [HttpPost, Authorize(Roles = Role.Administrators)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0) return BadRequest();
            await _workerData.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
