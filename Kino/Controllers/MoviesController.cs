using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Kino.Models;
using Kino.Services;
using Kino.Services.ViewModel;
namespace Kino.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;
        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<MoviesIndexViewModel> modelList = await this._moviesService.GetAllAsync();

            return View(modelList);
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
