using ETickets.Data.Base;
using ETickets.Data.ViewModel;
using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM newMovie)
        {
            var movie = new Movie()
            {
                Name = newMovie.Name,
                Description = newMovie.Description,
                StartDate = newMovie.StartDate,
                EndDate = newMovie.EndDate,
                Price = newMovie.Price,
                ImageUrl = newMovie.ImageUrl,
                CinemaId = newMovie.CinemaId,
                ProducerId = newMovie.ProducerId,
                MovieCategory = newMovie.MovieCategory,
            };

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            //Actors
            foreach (var actor in newMovie.ActorIds)
            {
                var newMovieActor = new Actor_Movie()
                {
                    MovieId = movie.Id,
                    ActorId = actor
                };
                await _context.Actors_Movies.AddAsync(newMovieActor);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var details = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return details;
        }

        public async Task<NewMovieDropdownVM> GetNewMovieDropDownsValue()
        {
            var dd = new NewMovieDropdownVM()
            {
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync()
            };

            return dd;
        }

        public async Task UpdateMovieAsync(NewMovieVM newMovie)
        {
            var dbMovie =   await _context.Movies.FirstOrDefaultAsync(n=> n.Id == newMovie.Id);
            if (dbMovie != null)
            {
                dbMovie.Name = newMovie.Name;
                dbMovie.Description = newMovie.Description;
                dbMovie.StartDate = newMovie.StartDate;
                dbMovie.EndDate = newMovie.EndDate;
                dbMovie.Price = newMovie.Price;
                dbMovie.ImageUrl = newMovie.ImageUrl;
                dbMovie.CinemaId = newMovie.CinemaId;
                dbMovie.ProducerId = newMovie.ProducerId;
                dbMovie.MovieCategory = newMovie.MovieCategory;

                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActors = await _context.Actors_Movies.Where(n => n.MovieId == newMovie.Id).ToListAsync();
            _context.Actors_Movies.RemoveRange(existingActors);
            await _context.SaveChangesAsync();
            

            //Actors
            foreach (var actor in newMovie.ActorIds)
            {
                var newMovieActor = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actor
                };
                await _context.Actors_Movies.AddAsync(newMovieActor);
            }
            await _context.SaveChangesAsync();
        }
    }
}
