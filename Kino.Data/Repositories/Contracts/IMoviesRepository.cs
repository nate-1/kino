using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Kino.Data.Model;

namespace Kino.Data.Repositories
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetAsync(int id);
        Task AddAsync(Movie movie);
        Task DeleteAsync(int id);

        Task UpdateAsync(Movie movie);
    }
}