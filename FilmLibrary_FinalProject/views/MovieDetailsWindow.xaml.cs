using FilmLibrary_FinalProject.models;
using MovieAPI.models;
using FilmLibraryDatabase;
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
using System.Windows.Shapes;

namespace FilmLibrary_FinalProject.views
{
    /// <summary>
    /// Interaction logic for MovieDetailsWindow.xaml
    /// </summary>
    public partial class MovieDetailsWindow : Window
    {
        Movie movie = new Movie();
        DBConnectionClass db = new DBConnectionClass();
        public MovieDetailsWindow(Movie _movie)
        {
            InitializeComponent();
            movie = _movie;
            
        }



        //Dev DeCoste
        public async void GetMovieData(string movieTitle)
        {
            MovieAPIModel movieVM = new MovieAPIModel();
            MovieData movieData = new MovieData();
            GetMovieData(movieTitle);


            movieData = await movieVM.GetMovieDataAsync(movieTitle);

            apiTitleText.Text = movieData.Title;
            apiYearText.Text = movieData.Year;
            apiActorstext.Text = movieData.Actors;
            apiRunTimeText.Text = movieData.Runtime;
            apiPlotText.Text = movieData.Plot;
            apiGenreText.Text = movieData.Genre;
        }
        
        private void btRemoveMovie_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(movie.MovieTitle);
            MessageBox.Show("Deleting..." + movie.MovieTitle);
            db.DeleteMovie(movie);
            MessageBox.Show("Movie Deleted");
            //Dev DeCoste
            this.Close();
        }

    }
}
