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
using FilmLibrary_FinalProject.classes.exceptions;

namespace FilmLibrary_FinalProject.views
{
    /// <summary>
    /// Interaction logic for AddMovieFromAPIWindow.xaml
    /////// </summary>
    public partial class AddMovieFromAPIWindow : Window
    {
        // Christopher Dierolf
        bool addMovieOk = false; // Add Movie Flag used to prevent the addition of blank movie data.

        public AddMovieFromAPIWindow()
        {
            InitializeComponent();
            txtAPIMovieTitle.Text = null;
        }

        /// <summary>
        /// Retreives the movie data from the api using the movie title.
        /// ///Christopher Dierolf
        /// </summary>
        /// <param name="movieTitle"></param>
        public async void GetMovieData(string movieTitle)
        {
            MovieAPIModel movieVM = new MovieAPIModel();
            MovieData movieData = new MovieData();

            string formattedTitle;

            try
            {

                formattedTitle = movieTitle.Replace(" ", "_"); // Replace spaces with underscores for more accurate results.

                movieData = await movieVM.GetMovieDataAsync(formattedTitle);
                if (movieData.Title == null || movieData.Title == "")
                {
                    addMovieOk = false; // Set the flag to false to prevent adding blank movies.

                    throw new NoTitleFoundMovieException("The title wasn't found in the api database.\n\n" +
                        "Ensure that you've type the title correctly (Example: The Godfather Part 2 vs The Godfather Part II.");
                }
                else
                {

                    apiTitleText.Text = movieData.Title;
                    apiYearText.Text = movieData.Year;
                    apiActorstext.Text = movieData.Actors;
                    apiDirector.Text = movieData.Director;
                    apiRunTimeText.Text = movieData.Runtime;
                    apiAwards.Text = movieData.Awards;
                    apiPlotText.Text = movieData.Plot;
                    apiGenreText.Text = movieData.Genre;

                    addMovieOk = true; // Set flag to true to allow the addition of a movie.
                }
            } catch (NoTitleFoundMovieException e)
            {
                MessageBox.Show(e.Message);
            }

            // TEST
            //MessageBox.Show("Here are your results:\n " +
            //  "Title: " + movieData.Title + " \n Year Released: " + movieData.Year + " \n Genre: " + movieData.Genre +
            //  " \n Writer: " + movieData.Writer + " \n Plot: " + movieData.Plot);
        }

        /// <summary>
        /// Ensures the movie title textbox isn't blank or whitespace before callling the API
        /// Christopher Dierolf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            txtAPIMovieTitle.Clear();

            apiTitleText.Text = "";
            apiYearText.Text = "";
            apiActorstext.Text = "";
            apiDirector.Text = "";
            apiRunTimeText.Text = "";
            apiAwards.Text = "";
            apiPlotText.Text = "";
            apiGenreText.Text = "";

        }

        /// <summary>
        /// Adds the movie to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAPIAdd_Click(object sender, RoutedEventArgs e)
        {
            // Christopher Dierolf
            DBConnectionClass db = new DBConnectionClass();
            Movie movie;

            if (addMovieOk == false) // Don't add blank movies.
                MessageBox.Show("There is no movie data to add.");
            else // Add the movie
            {
                movie = new Movie(apiTitleText.Text, apiYearText.Text, apiPlotText.Text, apiActorstext.Text, apiGenreText.Text, apiRunTimeText.Text, apiAwards.Text, apiDirector.Text);
                if (db.AddMovie(movie))
                {
                    string message = "The movie has been added!";
                    MessageBox.Show(message);
                    //Dev DeCoste
                    this.Close();
                }
                else
                {
                    string message = "There was an error. Please try again!";
                    MessageBox.Show(message);
                }
            }
        }

    }
}
