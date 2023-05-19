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
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using YouTubeOfficial.Models;
using YouTubeOfficial.Services;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using System.Runtime.Remoting.Contexts;

namespace YouTubeOfficial
{
    public partial class AuthenticatedWindow : Window
    {
        private int _userId;
        private YouTubeService youtubeService;
        private readonly UserService _userService;
        private readonly User _user;

        public AuthenticatedWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _userService = new UserService(new UserMoviesContext());
            _user = _userService.GetAllUsers().FirstOrDefault(u => u.ID == userId);
            UpdateMovieList();
            
            this.Title = $"Authenticated Window - {_user.Login}";

        }


        private async Task LoadVideos()
        {
            var scopes = new[] { YouTubeService.Scope.Youtube };
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = "294116173483-2e0us8b5kd60rcrvfgdk5n66fr8mi5k8.apps.googleusercontent.com",
                    ClientSecret = "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"
                },
                scopes,
                "user",
                CancellationToken.None,
                new FileDataStore("YouTube.Auth.Store")
            );

            youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YtCalendar"
            });

            var videosRequest = youtubeService.Videos.List("snippet");
            videosRequest.Chart = VideosResource.ListRequest.ChartEnum.MostPopular;
            videosRequest.MaxResults = 50;
            var videosResponse = await videosRequest.ExecuteAsync();

            Console.WriteLine(videosResponse.Items);
            VideoGrid.ItemsSource = videosResponse.Items;
        }



        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadVideos();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
            this.Close();
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedVideo = (Google.Apis.YouTube.v3.Data.Video)VideoGrid.SelectedItem;
            if (selectedVideo == null)
            {
                MessageBox.Show("Please select a video to add to the playlist");
                return;
            }

            var newPlaylistItem = new Google.Apis.YouTube.v3.Data.PlaylistItem
            {
                Snippet = new Google.Apis.YouTube.v3.Data.PlaylistItemSnippet
                {
                    PlaylistId = "PLyutXedVClXkeYAvVDhTL17j9PqELO3ez",
                    ResourceId = new Google.Apis.YouTube.v3.Data.ResourceId
                    {
                        Kind = "youtube#video",
                        VideoId = selectedVideo.Id
                    },
                    Title = selectedVideo.Snippet.Title,
                    Description = selectedVideo.Snippet.Description,
                    PublishedAt = WatchDateDatePicker.SelectedDate ?? DateTime.Now // Use selected date or current date if none selected
                }
            };

            try
            {
                var playlistItemsInsertRequest = youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet");
                await playlistItemsInsertRequest.ExecuteAsync();

                var newMovie = new Movie();
                newMovie.sessionDate = WatchDateDatePicker.SelectedDate ?? DateTime.Now;
                newMovie.Title = selectedVideo.Snippet.Title;
                newMovie.Link = $"https://www.youtube.com/watch?v={selectedVideo.Id}";
                newMovie.UserId = _userId;

                var userService = new UserService(new UserMoviesContext());
                userService.AddNewMovie(newMovie);

                MessageBox.Show("Video added to playlist successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding video to playlist: " + ex.Message);
            }
        }


        private void UpdateMovieList()
        {
            MovieList.ItemsSource = _userService.GetAllMovies();
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            UserService userService = new UserService(new UserMoviesContext());
            List<Movie> movies = _userService.GetAllMoviesForUser(_userId);

            ScheduleWindow scheduleWindow = new ScheduleWindow(_userId);

            scheduleWindow.ShowDialog();
        }
    }
}