using FilmLibrary_FinalProject.interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace FilmLibrary_FinalProject.models.validators
{
    public class UserValidator : IUserValidator
    {
        public UserValidator(string email, string username, string pass1, string pass2)
        {
            Email = email;
            Username = username;
            Pass1 = pass1;
            Pass2 = pass2;
        }

        public string Email { get; set; }
        public string Username { get; set; }
        public string Pass1 { get; set; }
        public string Pass2 { get; set; }


        public bool IsValidUser()
        {
            if (!IsValidEmail(Email) || !IsValidPassword(Pass1, Pass2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        

        public bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }catch (FormatException)
            {
                MessageBox.Show("E-mail is in an incorrect format.");
                return false;
            }
        }

        public bool IsValidPassword()
        {
            if (Pass1 == Pass2)
                return true;
            else
                MessageBox.Show("Passwords must match");
                return false;
        }
    }
}
