using FilmLibrary_FinalProject.interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary_FinalProject.models.validators
{
    public class UserValidator : IUserValidator
    {
        public string Date { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public bool IsValidUser(bool isValidDate, bool isValidEmail, bool isValidUsername)
        {
            if (!IsValidDate(Date) || !IsValidEmail(Email) || !IsValidUsername(Username))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsValidDate(string date)
        {
            string format;
            DateTime result;
            CultureInfo provider = CultureInfo.InvariantCulture;

            format = "d";

            try
            {
                result = DateTime.ParseExact(date, format, provider);
            }
            catch (InvalidDateException ex)
            {
                Console.WriteLine("Invalid date format.\n\nMessage: {0}\nSource: {1}", ex.Message, ex.Source);
                return false;
                
            }
            return true;
        }

        public bool IsValidEmail(string email)
        {
            //TODO
            throw new NotImplementedException();
        }

        public bool IsValidUsername(string username)
        {
            //TODO
            throw new NotImplementedException();
        }

       
    }
}
