using MovieAPI.models;
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
    /// Interaction logic for AddMovieFromAPIWindow.xaml
    /// </summary>
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

        public static async void GetMovieData(string movieTitle)
        {
            MovieAPIModel movieVM = new MovieAPIModel();
            MovieData movieData = new MovieData();

            movieData = await movieVM.GetMovieDataAsync(movieTitle);

            MessageBox.Show("Here are your results:\n " +
                "Title: " + movieData.Title + " \n Year Released: " + movieData.Year + " \n Genre: " + movieData.Genre +
                " \n Writer: " + movieData.Writer + " \n Plot: " + movieData.Plot);
        }

        private void btAPISearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtAPIMovieTitle != null)
                GetMovieData(txtAPIMovieTitle.Text);
            else
                MessageBox.Show("Movie title cannot be blank");
        }
    }
}
