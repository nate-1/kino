using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Kino.Models;
using Kino.Data.Model;
using Kino.Data.Repositories;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddMovieViewModel request)
        {
            if (!ModelState.IsValid)
                return View(request);

            // Movie movies = new Movie()
            // {
            //     Actors = request.Actor.Split(';', StringSplitOptions.TrimEntries).ToList(),
            //     Genre = request.Genre.Split(';', StringSplitOptions.TrimEntries).ToList(),
            //     Title = request.Title,
            //     Director = request.Director,
            //     ReleaseDate = request.ReleaseDate
            // };
            // _moviesRepo.Add(movies);

            string dirPath = Path.Combine(AppContext.BaseDirectory, "file");

            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            string filePath = Path.Combine(dirPath, request.Title.Replace(" ", "_") + "_" + request.ReleaseDate.Year + '.' + request.Poster.ContentType.Split("/")[1]);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                request.Poster.CopyToAsync(fs).Wait();
            }
            return Redirect("/Movies");
        }
    }
}
