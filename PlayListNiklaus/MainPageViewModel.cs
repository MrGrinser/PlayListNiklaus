using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Graphics;

namespace PlayListNiklaus
{
    public class MainPageViewModel : BindableObject
    {
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

        public ICommand SearchCommand { get; }

        public MainPageViewModel()
        {
            LoadMockAlbums();
            SearchCommand = new Command(FilterAlbums);
            IsDarkMode = false;
            UpdateBackgroundColor();
        }

        private void LoadMockAlbums()
        {
            Albums = new ObservableCollection<Album>
            {
            new Album { Title = "Ace of Spades", Artist = "Motörhead", CoverImage = "heavymetall.png" },
            new Album { Title = "Classical Masterpieces", Artist = "Beethoven", CoverImage = "beet.png" },
            new Album { Title = "News of the World", Artist = "Queen", CoverImage = "green.png" },
            new Album { Title = "Infinite", Artist = "Eminem", CoverImage = "hiphop1.png" },
            new Album { Title = "Encore", Artist = "Eminem", CoverImage = "hiphop2.png" },
            new Album { Title = "Louis Under the Stars", Artist = "Louis Armstrong", CoverImage = "jazz.png" },
            new Album { Title = "Recovery", Artist = "Eminem", CoverImage = "hiphop3.png" },
            new Album { Title = "A Kind of Magic", Artist = "Queen", CoverImage = "rock.png" },
            new Album { Title = "Beethoven Piano Music", Artist = "Beethoven", CoverImage = "piano.png" },
            new Album { Title = "The Game", Artist = "Queen", CoverImage = "rock2.png" }

            };

            FilteredAlbums = new ObservableCollection<Album>(Albums);
        }

        private void FilterAlbums()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredAlbums = new ObservableCollection<Album>(Albums);
            }
            else
            {
                var lowerCaseQuery = SearchQuery.ToLower();
                FilteredAlbums = new ObservableCollection<Album>(
                    Albums.Where(album =>
                        album.Title.ToLower().Contains(lowerCaseQuery) ||
                        album.Artist.ToLower().Contains(lowerCaseQuery)));
            }
        }

        private void UpdateBackgroundColor()
        {
            MainContentBackgroundColor = IsDarkMode ? Colors.Black : Colors.White;
        }
    }

    public class Album
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string CoverImage { get; set; }
    }
}
