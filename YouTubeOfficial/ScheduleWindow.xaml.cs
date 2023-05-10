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
    /// <summary>
    /// Interaction logic for ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        private UserService _userService;
        private int _userId;

        public ScheduleWindow(int userId)
        {
            InitializeComponent();

            _userId = userId;
            _userService = new UserService(new UserMoviesContext());

            // Populate the DataGrid with movies
            UpdateMovieList();
        }

        private void UpdateMovieList()
        {
            // Get all movies for the current user
            var movies = _userService.GetAllMoviesForUser(_userId);

            // Bind the movies to the DataGrid
            moviesDataGrid.ItemsSource = movies;
        }
        private void RemoveMovieButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected movie from the grid
            var selectedMovie = moviesDataGrid.SelectedItem as Movie;

            if (selectedMovie == null)
            {
                // No movie selected
                MessageBox.Show("Please select a movie to remove.", "Remove Movie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Confirm the removal with the user
            var result = MessageBox.Show($"Are you sure you want to remove the movie '{selectedMovie.Title}'?", "Remove Movie", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Remove the movie from the database
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
