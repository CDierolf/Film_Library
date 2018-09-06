using FilmLibrary_FinalProject.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibraryDatabase
{
    public class DBConnectionClass
    {
        static string dbName = "FilmDatabase.db";
        static string dbFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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


    }
}
