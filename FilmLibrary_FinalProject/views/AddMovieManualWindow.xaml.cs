using FilmLibrary_FinalProject.models;
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
    /// Interaction logic for AddMovieManualWindow.xaml
    /// </summary>
    public partial class AddMovieManualWindow : Window
    {
        public AddMovieManualWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBConnectionClass db = new DBConnectionClass();

            Movie movie = new Movie(txtMovieTitle.Text, txtReleaseYear.Text, txtPlot.Text, txtActors.Text, txtGenre.Text, txtRunTime.Text);

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
