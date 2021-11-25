using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kino.Data.Model
{
    public class Poster
    {
        public Poster()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(2)]
        public string Contry { get; set;}

        [Required]
        public Movie Movie { get; set; }

    }
}