using System;
using System.Collections.Generic;

namespace Kino.Data
{
    public class Movie
    {
        public Movie()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> Genre { get; set; }
        public List<string> Actors { get; set; }
    }
}