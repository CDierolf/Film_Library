using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary_FinalProject.models
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException() { }
        public InvalidDateException(string message) : base(message) { }
        public InvalidDateException(string message, Exception inner) : base(message, inner) { }
    }

    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() { }
        public InvalidEmailException(string message) : base(message) { }
        public InvalidEmailException(string message, Exception inner) : base(message, inner) { }
    }

    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException() { }
        public InvalidUsernameException(string message) : base(message) { }
        public InvalidUsernameException(string message, Exception inner) : base(message, inner) { }
    }

    
}
