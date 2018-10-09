using FilmLibrary_FinalProject.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibraryDatabase
{
    public class DBConnectionClass
    {
        static string dbName = "FilmDatabase.db";
        static string dbFolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + dbName;
        static string dbPath = String.Format(dbFolderPath, dbName);


        /// <summary>
        /// Insert new user into local database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>true if successful, false if unsuccessful</returns>
        public bool AddUser(User user)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.CreateTable<User>(); // Only creates a new table if one doesn't exist locally already.
                    conn.Insert(user);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("An exception has occured\n\nMessage: {0}\nSource: {1}", ex.Message, ex.Source);
                return false;
            }
        }

        /// <summary>
        /// Insert movie into local database.
        /// </summary>
        /// <param name="movie">Accepts a movie object.</param>
        /// <returns>true if successfull, false if unsuccessful</returns>
        public bool AddMovie(Movie movie)
        {
            try
            {
                // Because only one connection can be open at a time, by using the Using statement, you don't have 
                // to continually ensure your connections are closed manually.
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))  
                {
                    conn.CreateTable<Movie>(); // Only creates a new table if one doesn't exist locally already.
                    conn.Insert(movie);
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("An exception has occured\n\nMessage: {0}\nSource: {1}", ex.Message, ex.Source);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Locates the User data in the SQLite database.
        /// Uses a linq command to find the users data row.
        /// Compares the passed in password to the password 
        /// in the users datarow.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool FindLoginData(string username, string pwd)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.CreateTable<User>();
                    var user = conn.Table<User>().Where(u => u.UserName == username).FirstOrDefault();
                    if (user.Password == pwd)
                        return true;
                    else
                        return false;
                }
            } catch (NullReferenceException)
            {
                return false;
            }
        }
        /// <summary>
        /// Checks to see if the account the user is trying to create already
        /// exists by comparing the username and email of the user to rows 
        /// already in the database.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool DoesUserExist(string email, string username)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {

                    conn.CreateTable<User>();
                    var user = conn.Table<User>().Where(u => u.UserName == username).FirstOrDefault();

                    if (user.UserName == username || user.Email == email)
                        return true;
                    else
                        return false;
                }
            } catch (NullReferenceException)
            {
                return false;
            }
        }


    }
}
