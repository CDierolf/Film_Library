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
        public LibraryWindow()
        {
            InitializeComponent();
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
                foreach (var m in movies)
                {
                    lstVMovies.Items.Add(m);
                }
            }
        }
    }
}
