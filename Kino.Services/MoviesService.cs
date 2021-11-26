using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kino.Data;
using Kino.Data.Model;
using Kino.Data.Repositories;
using Kino.Services.ViewModel;

namespace Kino.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepo;

        public MoviesService(IMoviesRepository moviesRepo)
        {
            this._moviesRepo = moviesRepo;
        }

        public Task CreateMovieAsync(AddMovieViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MoviesIndexViewModel>> GetAllAsync()
        {
            List<Movie> movies = await this._moviesRepo.GetAllAsync();

            if(movies is null || movies.Count == 0)
                return new List<MoviesIndexViewModel>();

            IEnumerable<MoviesIndexViewModel> model = movies.Select((a) => {
                return new MoviesIndexViewModel()
                {
                    Index = a.Id, 
                    Title = a.Title, 
                    Director = a.Director, 
                    ReleaseYear = a.ReleaseDate.Year
                };
            });

           return model ?? new List<MoviesIndexViewModel>();
        }
        
    }
}
