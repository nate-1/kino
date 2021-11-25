﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kino.Data.Model
{
    public class Actor
    {
        public Actor()
        {
            this.Movies = new List<Movie>();
        }
        public int Id;

        [Required]
        [StringLength(50)]
        public string Name; 

        public List<Movie> Movies; 

    }
}