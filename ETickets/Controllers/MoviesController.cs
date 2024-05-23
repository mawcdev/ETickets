using ETickets.Data;
using ETickets.Data.Services;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n => n.Cinema);
            return View(data);
        }

       // [HttpPost]
        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(n => n.Cinema);

            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(n => n.Name.Contains(searchString) 
                    || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);

            }
            return View("Index", data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetMovieByIdAsync(id);

            if (details == null) return View("NotFound");

            return View(details);
        }

        public async Task<IActionResult> Create()
        {
            var dd = await _service.GetNewMovieDropDownsValue();
            ViewBag.Cinemas = new SelectList(dd.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dd.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(dd.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM newMovie)
        {
            if (!ModelState.IsValid)
            {
                var dd = await _service.GetNewMovieDropDownsValue();
                ViewBag.Cinemas = new SelectList(dd.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dd.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(dd.Actors, "Id", "FullName");
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(newMovie);
            }

            await _service.AddNewMovieAsync(newMovie);

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(int id)
        {
            var dd = await _service.GetNewMovieDropDownsValue();
            ViewBag.Cinemas = new SelectList(dd.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dd.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(dd.Actors, "Id", "FullName");

            var details = await _service.GetMovieByIdAsync(id);

            if (details == null) return View("NotFound");

            var newMovie = new NewMovieVM()
            {
                Name = details.Name,
                Description = details.Description,
                StartDate = details.StartDate,
                EndDate = details.EndDate,
                Price = details.Price,
                ImageUrl = details.ImageUrl,
                CinemaId = details.CinemaId,
                ProducerId = details.ProducerId,
                MovieCategory = details.MovieCategory,
                ActorIds = details.Actors_Movies.Select(n => n.ActorId).ToList()
            };

            return View(newMovie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM newMovie)
        {
            if (id != newMovie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var dd = await _service.GetNewMovieDropDownsValue();
                ViewBag.Cinemas = new SelectList(dd.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dd.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(dd.Actors, "Id", "FullName");
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(newMovie);
            }

            await _service.UpdateMovieAsync(newMovie);

            return RedirectToAction("Details", new { id });
        }
    }
}
