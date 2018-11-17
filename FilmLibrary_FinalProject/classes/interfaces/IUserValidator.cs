using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary_FinalProject.interfaces
{
    // User validator interface
    // Christopher Dierolf
    interface IUserValidator
    {
        bool IsValidEmail();
        bool IsValidPassword();
    }
}
