using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary_FinalProject.interfaces
{
    interface IUserValidator
    {
        bool IsValidEmail();
        bool IsValidPassword();
    }
}
