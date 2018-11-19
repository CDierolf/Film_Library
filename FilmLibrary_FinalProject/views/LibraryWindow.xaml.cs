﻿using System;
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
using FilmLibrary_FinalProject.models;
using FilmLibrary_FinalProject.views;
using FilmLibraryDatabase;


/// <summary>
/// Behind code for LibraryWindow
/// </summary>
namespace FilmLibrary_FinalProject
{
    /// <summary>
    /// Interaction logic for LibraryWindow.xaml
    /// </summary>
    public partial class LibraryWindow : Window
    {
        // Make the list accessible throughout the window.
        List<Movie> movies;
        public LibraryWindow()
        {
            InitializeComponent();
            // Christopher Dierolf
            DBConnectionClass db = new DBConnectionClass();

            movies = new List<Movie>();
            movies = db.GetMovies(); // Get the movies from the database.

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

        // Function that binds the listbox itemsource to the movies list
        // Christopher Dierolf
        public void ShowMovies()
        {
            if (movies != null)
            {
                lstVMovies.ItemsSource = movies;
            }
        }

        //Filter the listbox of movies
        // Christopher Dierolf
        private void txtSearchMovies_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            // var filteredList = movies.Where(m => m.MovieTitle.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            var filteredList = (from m in movies
                                where m.MovieTitle.ToLower().Contains(searchTextBox.Text.ToLower())
                                select m).ToList();

            if (filteredList != null)
                lstVMovies.ItemsSource = filteredList;
        }

        // Get the data from the listview selection and pass it to the MovieDetailsWindow
        // Christopher Dierolf
        private void lstVMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Movie movie = new Movie();
            if (lstVMovies.SelectedItems.Count > 0)
            {
                var items = lstVMovies.SelectedItems[0];
                movie = (Movie)items;

                // Test
                //MessageBox.Show(movie.MovieTitle);

                // Open the MovieDetailsWindow
                MovieDetailsWindow mdw = new MovieDetailsWindow(movie);
                mdw.Show();
                // Pass the movie object from the listview to the new window.
            }
        }
    }
}
