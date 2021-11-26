using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kino.Data.Model
{
    public class Genre
    {
        public Genre()
        {
            this.Movies = new List<Movie>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Label { get; set; }

        public List<Movie> Movies { get; set; } 
    }
}