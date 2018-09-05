using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary_FinalProject.models
{
    public class Movie
    {
        #region Class Properties
        
        public string MovieTitle { get; set; }
        public string ReleaseYear { get; set; }
        public string Plot { get; set; }
        public string Actors { get; set; }
        public string Genre { get; set; }
        #endregion


        #region Constructors
        
        /// <summary>
        /// Default ctor
        /// </summary>
        public Movie() { }


        /// <summary>
        /// overloaded ctor
        /// </summary>
        /// <param name="movieTitle"></param>
        /// <param name="releaseYear"></param>
        /// <param name="plot"></param>
        /// <param name="actors"></param>
        /// <param name="genre"></param>
        public Movie(string movieTitle, string releaseYear, string plot, string actors, string genre)
        {
            MovieTitle = movieTitle;
            ReleaseYear = releaseYear;
            Plot = plot;
            Actors = actors;
            Genre = genre;
        }

        #endregion

        #region Class Methods

        /// <summary>
        /// Saves the movie to the local database
        /// </summary>
        /// <returns>True if save is successful, false if not</returns>
        public bool SaveMovie()
        {
            ///TODO
            return false;
        }
        #endregion


    }
}
