using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary_FinalProject.interfaces
{
    interface IUserValidator
    {
        bool IsValidUser(bool email, bool date, bool name);
        bool IsValidEmail(string email);
        bool IsValidDate(string date);
        bool IsValidUsername(string username);
    }
}
