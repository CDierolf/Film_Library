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
using FilmLibrary_FinalProject.models;
using FilmLibrary_FinalProject.views;
using FilmLibraryDatabase;

namespace FilmLibrary_FinalProject
{
    /// <summary>
    /// Interaction logic for LibraryWindow.xaml
    /// </summary>
    public partial class LibraryWindow : Window
    {
        List<Movie> movies;
        public LibraryWindow()
        {
            InitializeComponent();
            DBConnectionClass db = new DBConnectionClass();
            movies = new List<Movie>();
            movies = db.GetMovies();
            ShowMovies();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddMovieManualWindow newMovieManual = new AddMovieManualWindow();
            newMovieManual.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddMovieFromAPIWindow newAPIMovie = new AddMovieFromAPIWindow();
            newAPIMovie.Show();
        }

        public void ShowMovies()
        {
            List<Movie> movies;
            DBConnectionClass db = new DBConnectionClass();
            movies = db.GetMovies();

            if (movies != null)
            {
                lstVMovies.ItemsSource = movies;
            }
        }

        private void txtSearchMovies_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            var filteredList = movies.Where(m => m.MovieTitle.Contains(searchTextBox.Text)).ToList();

            if (filteredList != null)
                lstVMovies.ItemsSource = filteredList;
        }
    }
}
