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
