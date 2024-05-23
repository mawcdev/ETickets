using ETickets.Data;
using ETickets.Data.Services;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
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
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl, Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(actor);
            }

            await _service.AddAsync(actor);

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
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureUrl, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(actor);
            }

            await _service.UpdateAsync(id, actor);

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
