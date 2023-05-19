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
using YouTubeOfficial.Models;
using YouTubeOfficial.Services;

namespace YouTubeOfficial
{

    public partial class ScheduleWindow : Window
    {
        private UserService _userService;
        private int _userId;

        public ScheduleWindow(int userId)
        {
            InitializeComponent();

            _userId = userId;
            _userService = new UserService(new UserMoviesContext());

            UpdateMovieList();
        }

        private void UpdateMovieList()
        {
            var movies = _userService.GetAllMoviesForUser(_userId);

            moviesDataGrid.ItemsSource = movies;
        }
        private void RemoveMovieButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedMovie = moviesDataGrid.SelectedItem as Movie;

            if (selectedMovie == null)
            {
                MessageBox.Show("Please select a movie to remove.", "Remove Movie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to remove the movie '{selectedMovie.Title}'?", "Remove Movie", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _userService.RemoveMovie(selectedMovie.ID);
                    UpdateMovieList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing movie: {ex.Message}", "Remove Movie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


    }

}
