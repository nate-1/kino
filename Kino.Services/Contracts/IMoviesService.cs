using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Kino.Services.ViewModel;

namespace Kino.Services
{
    public interface IMoviesService
    {
        Task<List<MoviesIndexViewModel>> GetAllAsync();

        Task CreateMovieAsync(AddMovieViewModel model);
    }
}
