using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayListNiklaus
{
    public class PlaylistPageViewModel : BindableObject
    {
        public Playlist SelectedPlaylist { get; set; }
        public Color Background { get; set; }
        private Song _selectedSong;
        private bool _isSongSelected;


        public PlaylistPageViewModel(Playlist selectedPlaylist, Color backgroundColor)
        {
            SelectedPlaylist = selectedPlaylist;
            Background = backgroundColor;
            SongSelectedCommand = new Command<Song>(OnSongSelected);
        }
        public Song SelectedSong
        {
            get => _selectedSong;
            set
            {
                _selectedSong = value;
                OnPropertyChanged();
            }
        }

        public bool IsSongSelected
        {
            get => _isSongSelected;
            set
            {
                _isSongSelected = value;
                OnPropertyChanged();
            }
        }

        public ICommand SongSelectedCommand { get; }

        private void OnSongSelected(Song song)
        {
            SelectedSong = song;
            IsSongSelected = true;

            // Update the IsSelected property for each song
            foreach (var s in SelectedPlaylist.Songs)
            {
                s.IsSelected = s == song;
            }
        }

        // Other properties and methods of PlaylistPageViewModel
    }

}
