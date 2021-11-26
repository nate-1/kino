using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kino.Data;
using Kino.Data.Model;

namespace Kino.Data.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly AppDbContext _dbContect;
        public MoviesRepository(AppDbContext dbContext)
        {
            this._dbContect = dbContext;
        }

        public Task<List<Movie>> GetAllAsync()
        {
            return this._dbContect.Movies.ToListAsync(); 
        }

        public Task<Movie> GetAsync(int id)
        {
            return this._dbContect.Movies.FirstAsync(f => f.Id == id); 
        }

        public Task AddAsync(Movie movie)
        {
            return default; 
        }

        public Task DeleteAsync(int id)
        {
            return default;
        }

        public Task UpdateAsync(Movie movie)
        {
            return default;
        }
    }
}