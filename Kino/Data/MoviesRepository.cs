using System;
using System.Collections.Generic;
using System.Linq;

namespace Kino.Data
{
    public class MoviesRepository : IMoviesRepository
    {
        private static List<Movie> movies;
        public MoviesRepository()
        {
            if (movies is not null)
                return;

            movies = new List<Movie> {
                new Movie()
                {
                    Id = 1,
                    Title = "Shang-Chi et la Légende des Dix Anneaux",
                    Director = "Destin Daniel Cretton",
                    ReleaseDate = new DateTime(2021,9,1),
                    Genre = new List<string>{
                        "Action", "Aventure", "Fantastique"
                    },
                    Actors = new List<string> {
                        "Simu Liu","Tony Leung Chiu-wai","Awkwafina","Meng'er Zhang","Michelle Yeoh"
                    }
                },
                new Movie() {
                    Id = 2,
                    Title = "Red Notice",
                    Director = "Rawson Marshall Thurber",
                    ReleaseDate = new DateTime(2021,11,5),
                    Genre = new List<string>{
                        "Action", "Comédie", "Crime", "Thriller"
                    },
                    Actors = new List<string> {
                        "Dwayne Johnson","Ryan Reynolds","Gal Gadot"
                    }
                },
                new Movie() {
                    Id = 3,
                    Title = "Venom : Let There Be Carnage",
                    Director = "Kelly Marcel",
                    ReleaseDate = new DateTime(2021,10,20),
                    Genre = new List<string>{
                        "Science-Fiction", "Action", "Aventure"
                    },
                    Actors = new List<string> {
                        "Tom Hardy","Woody Harrelson","Michelle Williams","Naomie Harris"
                    }
                },
                new Movie() {
                    Id = 4,
                    Title = "Mourir peut attendre",
                    Director = "Cary Joji Fukunaga",
                    ReleaseDate = new DateTime(2021,10,6),
                    Genre = new List<string>{
                        "Action", "Aventure", "Thriller"
                    },
                    Actors = new List<string> {
                        "Daniel Craig","Rami Malek","Léa Seydoux"
                    }
                },
                new Movie() {
                    Id = 5,
                    Title = "Clifford",
                    Director = "Walt Becker",
                    ReleaseDate = new DateTime(2021,12,1),
                    Genre = new List<string>{
                        "Animation", "Comédie", "Familial"
                    },
                    Actors = new List<string> {
                        "Darby Camp","Jack Whitehall","Izaac Wang"
                    }
                },
            };
        }

        public List<Movie> GetAll()
            => movies;

        public Movie Get(int id)
            => movies.Find(m => m.Id == id);

        public void Add(Movie movie)
        {
            if (movie.Id > 0)
                throw new InvalidOperationException("Id must be 0");

            var max = movies.Max(m => m.Id);
            movie.Id = max + 1;
            movies.Add(movie);
        }

        public void Delete(int id)
        {
            var movie = movies.Find(m => m.Id == id);
            if (movie is not null)
                movies.Remove(movie);

        }

        public void Update(Movie movie)
        {
            var i = movies.FindIndex(m => m.Id == movie.Id);
            if (i != -1)
            {
                movies.RemoveAt(i);
                movies.Insert(i, movie);
            }
        }
    }
}