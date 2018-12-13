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
    // Implementation of the UserValidator class
    // Validates the data passed into the user class.
    // Christopher Dierolf
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

        /// <summary>
        /// Validates a user based on a valid email and password
        /// Christopher Dierolf
        /// </summary>
        /// <returns></returns>
        public bool IsValidUser()
        {
            if (!IsValidEmail() || !IsValidPassword())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        /// <summary>
        /// Validates an email address using the MailAddress object
        /// Christopher Dierolf
        /// </summary>
        /// <returns></returns>
        public bool IsValidEmail()
        {
            try
            {
                MailAddress m = new MailAddress(Email);
                return true;
            }catch (FormatException)
            {
                MessageBox.Show("E-mail is in an incorrect format.");
                return false;
            }
        }

        /// <summary>
        /// Ensures that the user's password is valid based on the comparison of two entered passwords.
        /// Christopher Dierolf
        /// </summary>
        /// <returns></returns>
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
