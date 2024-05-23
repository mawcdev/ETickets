using ETickets.Data;
using ETickets.Data.Services;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(producer);
            }

            await _service.AddAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        //Get: producers/details/id
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if (details == null) return View("NotFound");

            return View(details);
        }

        //Get: producers/edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _service.GetByIdAsync(id);

            if (details == null) return View("NotFound");

            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureUrl, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(producer);
            }

            await _service.UpdateAsync(id, producer);

            return RedirectToAction("Details", new { id });
        }

        //Get: producers/delete/id
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
