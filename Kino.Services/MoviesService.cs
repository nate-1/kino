using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kino.Data;
using Kino.Services.ViewModel;

namespace Kino.Services
{
    public class MoviesService : IMoviesService
    {
       private readonly AppDbContext _appDbContext;

       public MoviesService(AppDbContext appDbContext)
       {
           this._appDbContext = appDbContext;
       }

       public Task CreateMovieAsync(AddMovieViewModel model)
       {
           throw new NotImplementedException();
       }

       public Task<List<MoviesIndexViewModel>> GetAllAsync()
       {
           throw new NotImplementedException();
       }
        
    }
}
