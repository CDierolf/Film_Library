using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FilmLibrary_FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Testing references
            //MovieAPI.models.MovieAPIModel api = new MovieAPI.models.MovieAPIModel();
            GetMovieTitle();
            
        }

        public static void GetMovieTitle()
        {

            int cont = 0;
            string movieTitle;
            do
            {
                Console.Write("Enter a movie title to search for: ");
                movieTitle = Console.ReadLine();
                GetMovieData("The GodFather"); // Hardcoding a title for testing
                Console.ReadLine();
            } while (cont != 0);
        }

        public static async void GetMovieData(string movieTitle)
        {
            MovieAPI.models.MovieAPIModel movieVM = new MovieAPI.models.MovieAPIModel();
            MovieAPI.models.MovieData movieData = new MovieAPI.models.MovieData();

            movieData = await movieVM.GetMovieDataAsync(movieTitle);

            MessageBox.Show("Here are your results: \n" + "Title: " + movieData.Title + "\nYear Released: " +
                movieData.Year + "\nGenre: " + movieData.Genre + "\nPlot: " + movieData.Plot);

        }
    }
}
