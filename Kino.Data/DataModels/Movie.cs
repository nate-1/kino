using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kino.Data.Model
{
    public class Movie
    {
        public Movie()
        {
            this.Actors = new List<Actor>(); 
            this.Genres = new List<Genre>();
            this.Posters = new List<Poster>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Director { get; set; }
        
        [Required]
        public DateTime ReleaseDate { get; set; }
        
        public List<Genre> Genres { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Poster> Posters { get; set; }
    }
}