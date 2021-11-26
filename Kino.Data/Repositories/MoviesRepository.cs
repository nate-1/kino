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
            if(id <= 0)
                throw new ArgumentNullException(nameof(id));

            return this._dbContect.Movies.FirstOrDefaultAsync(f => f.Id == id); 
        }

        public async Task AddAsync(Movie movie)
        {
            if(movie is null)
                throw new ArgumentNullException(nameof(movie));

            await this._dbContect.Movies.AddAsync(movie); 
            await this._dbContect.SaveChangesAsync();
        }   

        public async Task DeleteAsync(int id)
        {
            if(id <= 0)
                return; 

            bool exists = await this._dbContect.Movies.AnyAsync(f => f.Id == id);

            if(!exists)
                return; 

            Movie movieToDelete = new Movie()
            {
                Id = id
            };

            this._dbContect.Movies.Remove(movieToDelete);
            await this._dbContect.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            if(movie is null || movie.Id <= 0) 
                return;

            this._dbContect.Movies.Update(movie);
            await this._dbContect.SaveChangesAsync();
        }
    }
}