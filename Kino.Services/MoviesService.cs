using System;
using System.IO;
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

        public async Task CreateMovieAsync(AddMovieViewModel model)
        {
            IEnumerable<Actor> actors =  model.Actor.Split(';', StringSplitOptions.TrimEntries).Select(
                a => new Actor()
                {
                    Name = a
                }
            );

            IEnumerable<Genre> genres = model.Genre.Split(';', StringSplitOptions.TrimEntries).Select(
                a => new Genre()
                {
                    Label = a
                }
            );

            Movie movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ReleaseDate = model.ReleaseDate, 
                Actors = actors.ToList(),
                Genres = genres.ToList() 
            };

            string dirPath = Path.Combine(AppContext.BaseDirectory, "file");

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            string filePath = Path.Combine(dirPath, model.Title.Replace(" ", "_") + "_" + model.ReleaseDate.Year + '.' + model.Poster.ContentType.Split("/")[1]);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                await model.Poster.CopyToAsync(fs);
            }
            
            await this._moviesRepo.AddAsync(movie);
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
