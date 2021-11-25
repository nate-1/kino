using System;
using System.Collections.Generic;
using System.Linq;
using Kino.Data.Model;

namespace Kino.Data.Repositories
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