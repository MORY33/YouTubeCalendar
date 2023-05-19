using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using YouTubeOfficial.Models;
using YouTubeOfficial.Services;

namespace YouTubeOfficial
{

    public partial class MainWindow : Window
    {
        private readonly UserService _userService;


        public MainWindow()
        {
            InitializeComponent();
            _userService = new UserService(new UserMoviesContext());
            UpdateUserList();

        }

        private bool UserExists(string login, string password)
        {
            using (var context = new UserMoviesContext())
            {

                var user = context.Users.FirstOrDefault(u => u.Login == login);
                

                return context.Users.Any(u => u.Login == login && u.Password == password);
            }
        }
        private int? GetUserId(string login, string password)
        {
            using (var context = new UserMoviesContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user != null)
                {
                    return user.ID;
                }
                return null;
            }
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = UsernameInput.Text;
            string password = PasswordLoginInput.Password;

            
            if (UserExists(login, password))
            {
                int? userId = GetUserId(login, password);
                // Navigate to the second window
                AuthenticatedWindow authenticatedWindow = new AuthenticatedWindow(userId.Value);
                authenticatedWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("User not found or incorrect password. Please check your login credentials.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void GoToCreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPanel.Visibility = Visibility.Collapsed;
            CreateUserPanel.Visibility = Visibility.Visible;
        }

        private void GoToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            CreateUserPanel.Visibility = Visibility.Collapsed;
            LoginPanel.Visibility = Visibility.Visible;


        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginInput.Text;
            string password = PasswordInput.Password;


            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both login and password.");
                return;
            }

            var newUser = new User { Login = login, Password = password };
            _userService.AddNewUser(newUser);
            MessageBox.Show("New user added!");

            UpdateUserList();
        }

        private void UpdateUserList()
        {
            UserList.ItemsSource = _userService.GetAllUsers();
        }



    }
}