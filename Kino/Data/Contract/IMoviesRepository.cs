using System;
using System.Collections.Generic;
using System.Linq;

namespace Kino.Data
{
    public interface IMoviesRepository
    {
        List<Movie> GetAll();
        Movie Get(int id);
        void Add(Movie movie);
        void Delete(int id);

        void Update(Movie movie);
    }
}