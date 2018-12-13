using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary_FinalProject.classes.exceptions
{
    // Exception handling if the movie title wasn't found while using the API.
    public class NoTitleFoundMovieException : Exception
    {
        public NoTitleFoundMovieException() { }
        public NoTitleFoundMovieException(string message) : base(message) { }
        public NoTitleFoundMovieException(string message, Exception inner) : base(message, inner) { }

    }

    // Not used
    public class InvalidMovieYearException : Exception
    {
        public InvalidMovieYearException() { }
        public InvalidMovieYearException(string message) : base(message) { }
        public InvalidMovieYearException(string message, Exception inner) : base(message, inner) { }
    }
}
