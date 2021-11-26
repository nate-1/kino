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
        public async Task<IActionResult> Create(AddMovieViewModel request)
        {
            if (!ModelState.IsValid)
                return View(request);

            await this._moviesService.CreateMovieAsync(request);

            return Redirect("/Movies");
        }
    }
}
