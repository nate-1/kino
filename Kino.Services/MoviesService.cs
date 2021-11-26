using System;
using Kino.Data;

namespace Kino.Services
{
    public class MoviesService
    {
       private readonly AppDbContext _appDbContext;

       public MoviesService(AppDbContext appDbContext)
       {
           this._appDbContext = appDbContext;
       }
        
    }
}
