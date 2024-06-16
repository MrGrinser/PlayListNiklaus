using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Graphics;

namespace PlayListNiklaus
{
    public class MainPageViewModel : BindableObject
    {
        private string _email;
        private string _subscriptionStatus;
        public string SubscriptionStatus
        {
            get { return _subscriptionStatus; }
            set
            {
                _subscriptionStatus = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public ICommand SubscribeCommand { get; }
        private ObservableCollection<Album> _albums;
        public ObservableCollection<Album> Albums
        {
            get { return _albums; }
            set
            {
                _albums = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Album> _filteredAlbums;
        public ObservableCollection<Album> FilteredAlbums
        {
            get { return _filteredAlbums; }
            set
            {
                _filteredAlbums = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Playlist> _playlists;
        public ObservableCollection<Playlist> Playlists
        {
            get { return _playlists; }
            set
            {
                _playlists = value;
                OnPropertyChanged();
            }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                FilterAlbums();
            }
        }

        private bool _isDarkMode;
        public bool IsDarkMode
        {
            get { return _isDarkMode; }
            set
            {
                _isDarkMode = value;
                OnPropertyChanged();
                UpdateBackgroundColor();
            }
        }

        private Color _mainContentBackgroundColor;
        public Color MainContentBackgroundColor
        {
            get { return _mainContentBackgroundColor; }
            set
            {
                _mainContentBackgroundColor = value;
                OnPropertyChanged();
            }
        }

        private string _selectedGenre;
        public string SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                _selectedGenre = value;
                OnPropertyChanged();
                FilterAlbums();
            }
        }

        public ObservableCollection<string> Genres { get; }

        public ICommand SearchCommand { get; }
        public ICommand AlbumSelectedCommand { get; }

        public ICommand PlaylistSelectedCommand { get; }

        public MainPageViewModel()
        {
            LoadMockAlbums();
            LoadMockPlaylists();
            SearchCommand = new Command(FilterAlbums);
            IsDarkMode = false;
            UpdateBackgroundColor();
            AlbumSelectedCommand = new Command<Album>(OnAlbumSelected);
            PlaylistSelectedCommand = new Command<Playlist>(OnPlaylistSelected);
            SubscribeCommand = new Command(Subscribe);

            Genres = new ObservableCollection<string>
            {
                "All",
                "HeavyMetall",
                "Classical Music",
                "Rock",
                "Hip Hop",
                "Jazz"
            };
            SelectedGenre = "All";
        }
        private void Subscribe()
        {
            // Implement your subscription logic here
            // For example, you can send the email to your backend service
            // or perform any other necessary actions.
            // Example:
            if (RegexUtilities.IsValidEmail(Email))
            {
                SubscriptionStatus = $"Successfully subscribed with {Email}";
                // Reset email field
                Email = string.Empty;

                // Show popup or message box
                ShowSubscriptionPopup();
            }
            else
            {
                // Handle case where email is empty or invalid
                SubscriptionStatus = "Please enter a valid email address.";
            }
        }
        private void ShowSubscriptionPopup()
        {
            // You can use a platform-specific service or MAUI's built-in mechanisms to show a popup
            // For MAUI:
            Application.Current.MainPage.DisplayAlert("Subscription Successful", $"Successfully subscribed with {Email}", "OK");
        }
    

    private Album _selectedAlbum;
        public Album SelectedAlbum
        {
            get { return _selectedAlbum; }
            set
            {
                _selectedAlbum = value;
                OnPropertyChanged();
                if (_selectedAlbum != null)
                {
                    OnAlbumSelected(_selectedAlbum);
                }
            }
        }
        private void OnPlaylistSelected(Playlist selectedPlaylist)
        {

            Application.Current.MainPage.Navigation.PushAsync(new PlaylistPage
            {
                BindingContext = new PlaylistPageViewModel(selectedPlaylist, MainContentBackgroundColor)
            });
        }
        private void OnAlbumSelected(Album selectedAlbum)
        {
            Application.Current.MainPage.Navigation.PushAsync(new AlbumPage
            {
                BindingContext = new AlbumPageViewModel(selectedAlbum, MainContentBackgroundColor)
            });
        }

     
        private void LoadMockPlaylists()
        {
            Playlists = new ObservableCollection<Playlist>
            {
                new Playlist
                {
                   Title = "Workout",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "Eye of the Tiger", Duration = "4:05" },
                        new Song { Title = "Lose Yourself", Duration = "5:21" },
                        new Song { Title = "We Will Rock You", Duration = "2:58" }
                    }
                },
                new Playlist
                {
                   Title = "Relax",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "Take It Easy", Duration = "3:45" },
                        new Song { Title = "Lovely Day", Duration = "4:18" },
                        new Song { Title = "Sunny", Duration = "3:50" }
                    }
                }
            };

            
        }

        private void LoadMockAlbums()
        {
            Albums = new ObservableCollection<Album>
            {
                new Album
                {
                    Title = "Ace of Spades",
                    Artist = "Motörhead",
                    CoverImage = "heavymetall.png",
                    Genre = "HeavyMetall",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "Ace of Spades", Duration = "2:47" },
                        new Song { Title = "Love Me Like a Reptile", Duration = "3:23" },
                        new Song { Title = "Live to win", Duration = "3:36" }
                    }
                },
                new Album {
                    Title = "Classical Masterpieces",
                    Artist = "Beethoven",
                    CoverImage = "beet.png",
                    Genre = "Classical Music",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "9. Sinfonie", Duration = "2:47" },
                        new Song { Title = "5. Sinfonie", Duration = "3:23" },
                        new Song { Title = "2. Sinfonie", Duration = "3:36" }
                    }
                },
                new Album { Title = "News of the World",
                    Artist = "Queen",
                    CoverImage = "green.png",
                    Genre = "Rock",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "All Dead, All Dead", Duration = "3:10" },
                        new Song { Title = "We Will Rock You", Duration = "2:02" },
                        new Song { Title = "Spread Your Wings", Duration = "4:35" }
                    }
                },
                new Album
                {
                    Title = "Infinite",
                    Artist = "Eminem",
                    CoverImage = "hiphop1.png",
                    Genre = "Hip Hop",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "Infinite", Duration = "4:00" },
                        new Song { Title = "Rap God", Duration = "6:04" },
                        new Song { Title = "Lose Yourself", Duration = "5:26" },
                        new Song { Title = "Stan", Duration = "6:44" }
                    }
                },
                new Album
                {
                    Title = "Encore",
                    Artist = "Eminem",
                    CoverImage = "hiphop2.png",
                    Genre = "Hip Hop",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "Mockingbird", Duration = "4:10" },
                        new Song { Title = "Without Me", Duration = "4:50" },
                        new Song { Title = "Sing for the Moment", Duration = "5:40" },
                        new Song { Title = "Like Toy Soldiers", Duration = "5:24" }
                    }
                },
                new Album
                {
                    Title = "Louis Under the Stars",
                    Artist = "Louis Armstrong",
                    CoverImage = "jazz.png",
                    Genre = "Jazz",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "What a Wonderful World", Duration = "2:21" },
                        new Song { Title = "La Vie En Rose", Duration = "3:25" },
                        new Song { Title = "When You're Smiling", Duration = "4:03" },
                        new Song { Title = "Dream a Little Dream of Me", Duration = "3:15" }
                    }
                },
                new Album
                {
                    Title = "Recovery",
                    Artist = "Eminem",
                    CoverImage = "hiphop3.png",
                    Genre = "Hip Hop",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "Not Afraid", Duration = "4:08" },
                        new Song { Title = "Love the Way You Lie (feat. Rihanna)", Duration = "4:23" },
                        new Song { Title = "No Love (feat. Lil Wayne)", Duration = "4:59" },
                        new Song { Title = "Space Bound", Duration = "4:38" },
                        new Song { Title = "Cold Wind Blows", Duration = "5:04" }
                    }
                },
                new Album
                {
                    Title = "A Kind of Magic",
                    Artist = "Queen",
                    CoverImage = "rock.png",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "A Kind of Magic", Duration = "4:24" },
                        new Song { Title = "Princes of the Universe", Duration = "3:32" },
                        new Song { Title = "Friends Will Be Friends", Duration = "4:08" },
                        new Song { Title = "One Vision", Duration = "4:03" },
                        new Song { Title = "Who Wants to Live Forever", Duration = "5:15" }
                    }
                },
                new Album
                {
                    Title = "Beethoven Piano Music",
                    Artist = "Beethoven",
                    CoverImage = "piano.png",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "Für Elise", Duration = "2:55" },
                        new Song { Title = "Moonlight Sonata", Duration = "5:17" },
                        new Song { Title = "Pathétique Sonata", Duration = "7:55" },
                        new Song { Title = "Ode to Joy", Duration = "4:20" }
                    }
                },
                new Album
                {
                    Title = "The Game",
                    Artist = "Queen",
                    CoverImage = "rock2.png",
                    Genre = "Rock",
                    Songs = new ObservableCollection<Song>
                    {
                        new Song { Title = "Play the Game", Duration = "3:33" },
                        new Song { Title = "Another One Bites the Dust", Duration = "3:35" },
                        new Song { Title = "Save Me", Duration = "3:48" },
                        new Song { Title = "Crazy Little Thing Called Love", Duration = "2:44" },
                        new Song { Title = "Dragon Attack", Duration = "4:18" },
                        new Song { Title = "Under Pressure", Duration = "4:03" }
                    }
                }
            };

            FilteredAlbums = new ObservableCollection<Album>(Albums);
        }

        private void FilterAlbums()
        {
            var lowerCaseQuery = SearchQuery?.ToLower();
            var filtered = Albums.Where(album =>
                (string.IsNullOrWhiteSpace(SearchQuery) ||
                 album.Title.ToLower().Contains(lowerCaseQuery) ||
                 album.Artist.ToLower().Contains(lowerCaseQuery)) &&
                (SelectedGenre == "All" || album.Genre == SelectedGenre));

            FilteredAlbums = new ObservableCollection<Album>(filtered);
        }

        private void UpdateBackgroundColor()
        {
            MainContentBackgroundColor = IsDarkMode ? Colors.Black : Colors.White;
        }
    }
}
