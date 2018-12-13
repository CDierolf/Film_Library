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
        }
        /// <summary>
        /// Authenticate login information.
        /// Calls User.AuthenticateUser(username, password) which calls
        /// DbConnectionClass.FindUserData(username, password) to authenticate
        /// user data. Passes the username for database filtering.
        ///
        /// Christopher Dierolf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            if (user.AuthenticateUser(txtUserName.Text, pwdPassword.Password))
            {
                LibraryWindow lw = new LibraryWindow();
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
        /// Christopher Dierolf
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
