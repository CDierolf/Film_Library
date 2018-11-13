using FilmLibrary_FinalProject.models;
using FilmLibrary_FinalProject.models.validators;
using FilmLibraryDatabase;
using SQLite;
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
    /// Interaction logic for CreateAccountWindow.xaml
    /// </summary>
    public partial class CreateAccountWindow : Window
    {
        public CreateAccountWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// // Creates a new account after validating and ensuring the account doesn't already exist.
        /// Christopher K. Dierolf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserValidator uv = new UserValidator(txtEmail.Text, txtUserName.Text, pwdPass1.Password, pwdPass2.Password);
            DBConnectionClass db = new DBConnectionClass();

            if (uv.IsValidUser()) // Validate the entered data.
            {
                User user = new User(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtUserName.Text, pwdPass1.Password);
                if (user.ValidateUserAccount(txtEmail.Text, txtUserName.Text))
                {
                    MessageBox.Show("An account is already created with the data you've entered."); // Account already exists.
                }
                else // Create the new account.
                {
                    if (db.AddUser(user))
                        lblAcctStatus.Content = "Account Created!";
                    else
                        lblAcctStatus.Content = "Something went wrong :(.";
                }
            } 
        }
    }
}
