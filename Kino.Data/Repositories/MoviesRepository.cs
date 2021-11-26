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
        private readonly AppDbContext _dbContext;
        public MoviesRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<List<Movie>> GetAllAsync()
        {
            return this._dbContext.Movies
            .Include(m => m.Director)
            .Include(m => m.Genres)
            .Include(m => m.Actors)
            .ToListAsync(); 
        }

        public Task<Movie> GetAsync(int id)
        {
            if(id <= 0)
                throw new ArgumentNullException(nameof(id));

            return this._dbContext.Movies
            .Include(m => m.Director)
            .Include(m => m.Genres)
            .Include(m => m.Actors)
            .FirstOrDefaultAsync(f => f.Id == id); 
        }

        public async Task AddAsync(Movie movie)
        {
            if(movie is null)
                throw new ArgumentNullException(nameof(movie));

            await this._dbContext.Movies.AddAsync(movie); 
            await this._dbContext.SaveChangesAsync();
        }   

        public async Task DeleteAsync(int id)
        {
            if(id <= 0)
                return; 

            bool exists = await this._dbContext.Movies.AnyAsync(f => f.Id == id);

            if(!exists)
                return; 

            Movie movieToDelete = new Movie()
            {
                Id = id
            };

            this._dbContext.Movies.Remove(movieToDelete);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            if(movie is null || movie.Id <= 0) 
                return;

            this._dbContext.Movies.Update(movie);
            await this._dbContext.SaveChangesAsync();
        }
    }
}