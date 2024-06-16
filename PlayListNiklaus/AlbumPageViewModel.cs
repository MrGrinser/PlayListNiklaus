using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public AlbumPageViewModel(Album selectedAlbum, Color mainContentBackgroundColor )
        {
            SelectedAlbum = selectedAlbum;
            Background = mainContentBackgroundColor;
        }
    }
}

