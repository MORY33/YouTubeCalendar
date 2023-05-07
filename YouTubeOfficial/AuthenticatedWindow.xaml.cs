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
//using Google.Apis.YouTube.v3.Data;
using YouTubeOfficial.Models;



namespace YouTubeOfficial
{
    /// <summary>
    /// Interaction logic for AuthenticatedWindow.xaml
    /// </summary>
    public partial class AuthenticatedWindow : Window
    {

        private readonly YouTubeService youtubeService;

        public AuthenticatedWindow()
        {
            InitializeComponent();

        }

        
            private async Task LoadVideos()
            {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyBI4RrOuSnWku4LO0n7TObonpIKWtx8wb0",
                ApplicationName = "YtCalendar"
            });

            var playlistItemsRequest = youtubeService.PlaylistItems.List("snippet");
            playlistItemsRequest.PlaylistId = "PLUPnAD_KMe8byysGeCZiBMKGrgWB0YvPg";
            playlistItemsRequest.MaxResults = 50;
            var playlistItemsResponse = await playlistItemsRequest.ExecuteAsync();
            Console.WriteLine(playlistItemsResponse.Items);
            VideoGrid.ItemsSource = playlistItemsResponse.Items;


            //var videos = new List<Video>();
            //foreach (var playlistItem in playlistItemsResponse.Items)
            //{
              //  var video = new Video
                //{
                  //  Title = playlistItem.Snippet.Title,
                    //Description = playlistItem.Snippet.Description,
                    //ThumbnailUrl = playlistItem.Snippet.Thumbnails.Default__.Url
                //};
                //videos.Add(video);
            //}
            //
            //VideoGrid.ItemsSource = videos;
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

    }
}