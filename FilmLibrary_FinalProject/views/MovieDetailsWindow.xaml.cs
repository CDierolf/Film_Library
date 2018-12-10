using FilmLibrary_FinalProject.models;
using MovieAPI.models;
using FilmLibrary_FinalProject.classes;
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
    /// 
    // Dev Decoste
    public partial class MovieDetailsWindow : Window
    {
        Movie movie = new Movie();
        DBConnectionClass db = new DBConnectionClass();
        public MovieDetailsWindow(Movie _movie)
        {
            InitializeComponent();
            this.movie = _movie;
            apiTitleText.Text = movie.MovieTitle;
            apiYearText.Text = movie.ReleaseYear;
            apiActorstext.Text = movie.Actors;
            apiRunTimeText.Text = movie.RunTime;
            apiPlotText.Text = movie.Plot;
            apiGenreText.Text = movie.Genre;
            apiAwards.Text = movie.Awards;
            apiDirector.Text = movie.Director;
        }
        
        private void btRemoveMovie_Click(object sender, RoutedEventArgs e)
        {
            db.DeleteMovie(movie);
            //Dev DeCoste
            this.Close();
        }

        // Dev Decoste
        private void btnEditMovie_Click(object sender, RoutedEventArgs e)
        {
            movie.MovieTitle = apiTitleText.Text;
            movie.ReleaseYear = apiYearText.Text;
            movie.Actors = apiActorstext.Text;
            movie.RunTime = apiRunTimeText.Text;
            movie.Plot = apiPlotText.Text;
            movie.Genre = apiGenreText.Text;
            movie.Awards = apiAwards.Text;
            movie.Director = apiDirector.Text;

            DBConnectionClass db = new DBConnectionClass();
            if (db.UpdateMovie(movie) == true)
            {
                MessageBox.Show("Movie updated!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
            
        }
    }
}
