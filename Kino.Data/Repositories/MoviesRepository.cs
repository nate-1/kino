using System;
using System.Collections.Generic;
using System.Linq;
using Kino.Data.Model;

namespace Kino.Data.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private static List<Movie> movies;
        public MoviesRepository()
        {
            if (movies is not null)
                return;
        }

        public List<Movie> GetAll()
            => movies;

        public Movie Get(int id)
            => movies.Find(m => m.Id == id);

        public void Add(Movie movie)
        {
            if (movie.Id > 0)
                throw new InvalidOperationException("Id must be 0");

            var max = movies.Max(m => m.Id);
            movie.Id = max + 1;
            movies.Add(movie);
        }

        public void Delete(int id)
        {
            var movie = movies.Find(m => m.Id == id);
            if (movie is not null)
                movies.Remove(movie);

        }

        public void Update(Movie movie)
        {
            var i = movies.FindIndex(m => m.Id == movie.Id);
            if (i != -1)
            {
                movies.RemoveAt(i);
                movies.Insert(i, movie);
            }
        }
    }
}