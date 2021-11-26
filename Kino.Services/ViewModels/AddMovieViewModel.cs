using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kino.Services.ViewModel
{
    public class AddMovieViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Actor { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public IFormFile Poster { get; set; }
    }
}
