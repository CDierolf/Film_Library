using MovieAPI.models;
using System;
using FilmLibrary_FinalProject.models;
using FilmLibraryDatabase;
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
using System.Windows.Shapes;

namespace FilmLibrary_FinalProject.views
{
    /// <summary>
    /// Interaction logic for AddMovieFromAPIWindow.xaml
    /////// </summary>
    public partial class AddMovieFromAPIWindow : Window
    {
        public AddMovieFromAPIWindow()
        {
            InitializeComponent();

            txtAPIMovieTitle.Text = null;
        }

        public void GetMovieTitle()
        {
            int cont = 0;
            string movieTitle, formattedTitle;
            do
            {
                Console.Write("Enter a movie title to search for: ");
                movieTitle = Console.ReadLine();
                formattedTitle = movieTitle.Replace(" ", "_"); // Replace spaces with underscores for more accurate results.
                GetMovieData(movieTitle);
                Console.ReadLine();
            } while (cont != 0);
        }

        public async void GetMovieData(string movieTitle)
        {
            MovieAPIModel movieVM = new MovieAPIModel();
            MovieData movieData = new MovieData();

            movieData = await movieVM.GetMovieDataAsync(movieTitle);

            apiTitleText.Text = movieData.Title;
            apiYearText.Text = movieData.Year;
            apiActorstext.Text = movieData.Actors;
            apiRunTimeText.Text = movieData.Runtime;
            apiPlotText.Text = movieData.Plot;
            apiGenreText.Text = movieData.Genre;

            //MessageBox.Show("Here are your results:\n " +
            //  "Title: " + movieData.Title + " \n Year Released: " + movieData.Year + " \n Genre: " + movieData.Genre +
            //  " \n Writer: " + movieData.Writer + " \n Plot: " + movieData.Plot);
        }

        private void btAPISearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtAPIMovieTitle != null)
                GetMovieData(txtAPIMovieTitle.Text);
            else
                MessageBox.Show("Movie title cannot be blank");
        }

        // Jason George
        private void btAPIReset_Click(object sender, RoutedEventArgs e)
        {
            txtAPIMovieTitle = null;

            apiTitleText.Text = "";
            apiYearText.Text = "";
            apiActorstext.Text = "";
            apiRunTimeText.Text = "";
            apiPlotText.Text = "";
            apiGenreText.Text = "";
        }

        private void btAPIAdd_Click(object sender, RoutedEventArgs e)
        {
            DBConnectionClass db = new DBConnectionClass();

            Movie movie = new Movie(apiTitleText.Text, apiYearText.Text, apiPlotText.Text, apiActorstext.Text, apiGenreText.Text, apiRunTimeText.Text);

            if (db.AddMovie(movie))
            {
                string message = "The movie has been added!";
                MessageBox.Show(message);
            }
            else
            {
                string message = "There was an error. Please try again!";
                MessageBox.Show(message);
            }
        }

    }
}
