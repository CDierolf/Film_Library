using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary_FinalProject.models
{
    public class Movie
    {

        public string MovieTitle { get; set; }
        public string ReleaseYear { get; set; }
        public string Plot { get; set; }
        public string Actors { get; set; }
        public string Genre { get; set; }
        /// <summary>
        /// Default ctor
        /// </summary>
        public Movie() { }

        public Movie(string movieTitle, string releaseYear, string plot, string actors, string genre)
        {
            MovieTitle = movieTitle;
            ReleaseYear = releaseYear;
            Plot = plot;
            Actors = actors;
            Genre = genre;
        }


    }
}
