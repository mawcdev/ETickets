using ETickets.Data.Base;
using ETickets.Data.ViewModel;
using ETickets.Models;

namespace ETickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownVM> GetNewMovieDropDownsValue();

        Task AddNewMovieAsync(NewMovieVM newMovie);
        Task UpdateMovieAsync(NewMovieVM newMovie);

    }
}
