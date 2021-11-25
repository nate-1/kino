using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kino.Data.Model
{
    public class Movie
    {
        public Movie()
        {
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Director { get; set; }
        
        [Required]
        [StringLength(50)]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public List<Genre> Genre { get; set; }
        public List<Actor> Actors { get; set; }
        public string Poster { get; set; }
    }
}