<<<<<<< HEAD
﻿using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
                //if (user!= null)
                //{
                //    Console.WriteLine($"User: {user.Login}, Password: {user.Password}");

                //}

                return context.Users.Any(u => u.Login == login && u.Password == password);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = UsernameInput.Text;
            string password = PasswordLoginInput.Password;
          

            if (UserExists(login, password))
            {
                // Navigate to the second window
                AuthenticatedWindow authenticatedWindow = new AuthenticatedWindow();
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
=======
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
using YouTubeOfficial.Models;
using YouTubeOfficial.Services;

namespace YouTubeOfficial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserService _userService;

        public MainWindow()
        {
            InitializeComponent();
            _userService = new UserService(new UserMoviesContext());
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User { Login = "testowy", Password = "testowy" };
            _userService.AddNewUser(newUser);
            MessageBox.Show("New user added!");
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Your login logic here
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Your create user logic here
        }
    }
}
>>>>>>> added login panel and switch between create user
