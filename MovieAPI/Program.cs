using MovieAPI.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMovieTitle();
            Console.ReadLine();
        }

        public static void GetMovieTitle()
        {

            int cont = 0;
            string movieTitle;
            do
            {
                Console.Write("Enter a movie title to search for: ");
                movieTitle = Console.ReadLine();
                GetMovieData(movieTitle);
                Console.ReadLine();
            } while (cont != 0);
        }

        public static async void GetMovieData(string movieTitle)
        {
            MovieAPIModel movieVM = new MovieAPIModel();
            MovieData movieData = new MovieData();

            movieData = await movieVM.GetMovieDataAsync(movieTitle);

            Console.WriteLine("Here are your results:\n " +
                "Title: {0} \n Year Released: {1} \n Genre: {2} \n Writer: {3} \n Plot: {4} ",
                movieData.Title, movieData.Year, movieData.Genre, movieData.Writer, movieData.Plot);

        }
    }
}
