using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

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

        public MainPageViewModel()
        {
            LoadMockAlbums();
        }

        private void LoadMockAlbums()
        {
            Albums = new ObservableCollection<Album>
            {
                new Album { Title = "Album 1", Artist = "Artist 1", CoverImage = "heavymetall.png" },
                new Album { Title = "Album 2", Artist = "Artist 2", CoverImage = "beet.png" },
                new Album { Title = "Album 3", Artist = "Artist 3", CoverImage = "green.png" },
                new Album { Title = "Album 4", Artist = "Artist 1", CoverImage = "hiphop1.png" },
                new Album { Title = "Album 5", Artist = "Artist 2", CoverImage = "hiphop2.png" },
                new Album { Title = "Album 6", Artist = "Artist 3", CoverImage = "jazz.png" },
                new Album { Title = "Album 7", Artist = "Artist 1", CoverImage = "hiphop3.png" },
                new Album { Title = "Album 8", Artist = "Artist 2", CoverImage = "rock.png" },
                new Album { Title = "Album 9", Artist = "Artist 3", CoverImage = "piano.png" },
                new Album { Title = "Album 10", Artist = "Artist 1", CoverImage = "rock2.png" }

                // Add more albums as needed
            };
        }
    }

    public class Album
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string CoverImage { get; set; }
    }
}