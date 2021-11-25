using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kino.Data.Model
{
    public class Genre
    {
        public Genre()
        {
        }
        public int Id;

        [Required]
        [StringLength(50)]
        public string Label; 
    }
}