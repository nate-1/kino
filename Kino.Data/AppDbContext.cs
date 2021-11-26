using System;
using Microsoft.EntityFrameworkCore;
using Kino.Data.Model;
namespace Kino.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Poster> Posters { get; set; }
    }
}
