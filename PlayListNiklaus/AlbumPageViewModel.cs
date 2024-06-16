using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayListNiklaus
{
    public class AlbumPageViewModel : BindableObject
    {
        private Album _selectedAlbum;
        public Album SelectedAlbum
        {
            get { return _selectedAlbum; }
            set
            {
                _selectedAlbum = value;
                OnPropertyChanged();
            }
        }

        private Color _background;
        public Color Background
        {
            get { return _background; }
            set
            {
                _background = value;
                OnPropertyChanged();
            }
        }
        private Song _selectedSong;
        public Song SelectedSong
        {
            get { return _selectedSong; }
            set
            {
                _selectedSong = value;
                OnPropertyChanged();
                IsSongSelected = _selectedSong != null;
            }
        }

        private bool _isSongSelected;
        public bool IsSongSelected
        {
            get { return _isSongSelected; }
            set
            {
                _isSongSelected = value;
                OnPropertyChanged();
            }
        }

        public ICommand SongSelectedCommand { get; }

        public AlbumPageViewModel(Album selectedAlbum, Color mainContentBackgroundColor )
        {
            SelectedAlbum = selectedAlbum;
            Background = mainContentBackgroundColor;
            SongSelectedCommand = new Command<Song>(OnSongSelected);
        }
        private void OnSongSelected(Song selectedSong)
        {
            SelectedSong = selectedSong;
        }

    }
}

