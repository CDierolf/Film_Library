﻿using FilmLibrary_FinalProject.interfaces;
using System;
using System.Collections.Generic;
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
            if (!IsValidDate(Date) || !IsValidEmail(Email) || !IsValidUsername(Username)) {
                if (!IsValidDate(Date))
                {
                    throw new InvalidDateException("Date is in an incorrect format.");
                }

                if (!IsValidEmail(Email))
                {
                    throw new InvalidEmailException("Email address is invalid.");
                }

                if (!IsValidUsername(Username))
                {
                    throw new InvalidUsernameException("Username is invalid.");
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsValidDate(string date)
        {
            throw new NotImplementedException();
        }

        public bool IsValidEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsValidUsername(string username)
        {
            throw new NotImplementedException();
        }

       
    }
}
