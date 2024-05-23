using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ETickets.Data;
using ETickets.Models;
using ETickets.Data.Services;

namespace ETickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: actors/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Logo, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(cinema);
            }

            await _service.AddAsync(cinema);

            return RedirectToAction(nameof(Index));
        }

        //Get: actors/details/id
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if (details == null) return View("NotFound");

            return View(details);
        }

        //Get: actors/edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if (details == null) return View("NotFound");

            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Logo, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(cinema);
            }

            await _service.UpdateAsync(id, cinema);

            return RedirectToAction("Details", new { id });
        }

        //Get: actors/delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if (details == null) return View("NotFound");

            return View(details);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if (details == null) return View("NotFound");


            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
