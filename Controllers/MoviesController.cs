using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kino.Models;
using Kino.Data;

namespace Kino.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository _moviesRepo;
        public MoviesController(IMoviesRepository moviesRepo)
        {
            _moviesRepo = moviesRepo;
        }
        public IActionResult Index()
        {
            IEnumerable<MoviesIndexViewModel> models = _moviesRepo.GetAll().Select(a =>  new MoviesIndexViewModel() 
            {
                Director = a.Director, 
                Index = a.Id, 
                ReleaseYear = a.ReleaseDate.Year, 
                Title = a.Title
            });

            return View(models);
        }
    }
}
