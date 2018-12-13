using FilmLibrary_FinalProject.interfaces;
using FilmLibraryDatabase;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary_FinalProject.models
{
    /// <summary>
    /// Christopher Dierolf
    /// User Class
    /// </summary>
    public class User
    {
        #region Class Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// default ctor
        /// </summary>
        public User() { }

        /// <summary>
        /// Overloaded ctor for new user creation
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <param name="email"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public User(string firstName, string lastName, string email, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Authenticate user credentials. 
        /// Compares the user entered credentials against
        /// the local database user table.
        /// Inherited from the IUserValidator interface
        /// ///Christopher K. Dierolf
        /// </summary>
        /// <returns>Returns true if credentials are authenticated. False if failed</returns>
        public bool AuthenticateUser(string userName, string password)
        {
            DBConnectionClass db = new DBConnectionClass();
            if (db.FindLoginData(userName, password))
                return true;
            else
                return false;
            
        }

        public bool ValidateUserAccount(string email, string username)
        {
            DBConnectionClass db = new DBConnectionClass();
            {
                if (db.DoesUserExist(email, username))
                    return true;
                else
                    return false;
            }
        }
        #endregion
    }
}

