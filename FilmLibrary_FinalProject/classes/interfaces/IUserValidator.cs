using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary_FinalProject.interfaces
{
    interface IUserValidator
    {
        bool IsValidEmail(string email);
        bool IsValidPassword(string pwd1, string pwd2);
    }
}
