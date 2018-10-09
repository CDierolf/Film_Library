using FilmLibrary_FinalProject.models;
using FilmLibrary_FinalProject.views;
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
            //GetMovieTitle();

            //UserTextBox.Text = "Username";
            //PassTextBox.Text = "Password";
            
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
        /// <summary>
        /// Authenticate login information.
        /// Calls User.AuthenticateUser(username, password) which calls
        /// DbConnectionClass.FindUserData(username, password) to authenticate
        /// user data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LibraryWindow lw = new LibraryWindow();
            User user = new User();
            if (user.AuthenticateUser(txtUserName.Text, pwdPassword.Password))
            {
                lw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        /// <summary>
        /// Open CreateAccountWindow so that the user can create a new account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateAcct_Click(object sender, RoutedEventArgs e)
        {
            CreateAccountWindow caw = new CreateAccountWindow();
            caw.Show();
        }
    }
}
