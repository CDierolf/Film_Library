using FilmLibrary_FinalProject.interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary_FinalProject.models
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        #region Class Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
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
        public User(string firstName, string lastName, string dob, string email, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
            Email = email;
            UserName = userName;
            Password = password;

            // Validate and call create user
            // ValidateUser(...);
            
        }
        #endregion


        #region Methods
        /// <summary>
        /// Authenticate user credentials. 
        /// Compares the user entered credentials against
        /// the local database user table.
        /// Inherited from the IUserValidator interface
        /// </summary>
        /// <returns>Returns true if credentials are authenticated. False if failed</returns>
        public bool AuthenticateUser()
        {
            // TODO
            return true;
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <returns>True if created successfully, false otherwise</returns>
        public bool CreateUser()
        {
            // TODO
            return true;
        }

        #endregion
    }
}

