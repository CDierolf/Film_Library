using FilmLibrary_FinalProject.classes.exceptions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FilmLibrary_FinalProject.models
{
    /// <summary>
    /// Movie Class
    /// Christopher Dierolf
    /// Used fields for saving movie data from the database.
    /// Not all fields from the API are used, thus, this class is smaller than the MovieAPI Model
    /// </summary>
    public class Movie
    {
        // Dev DeCoste Removed Image field
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string MovieTitle { get; set; }
        public string ReleaseYear { get; set; }
        public string Plot { get; set; }
        public string Actors { get; set; }
        public string Genre { get; set; }
        public string RunTime { get; set; }
        public string Awards { get; set; }
        public string Director { get; set; }


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
        /// // Dev DeCoste Removed Image field
        public Movie(string movieTitle, string releaseYear, string plot, string actors, string genre, string runTime, string director)
        {
            MovieTitle = movieTitle;
            ReleaseYear = releaseYear;
            Plot = plot;
            Actors = actors;
            Genre = genre;
            RunTime = runTime;
            Director = director;
        }

        public Movie(string movieTitle, string releaseYear, string plot, string actors, string genre, string runTime, string awards, string director) : this(movieTitle, releaseYear, plot, actors, genre, runTime, director)
        {
            Awards = awards;
        }

        #endregion



       
    }
}
