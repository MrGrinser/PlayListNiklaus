using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlayListNiklaus
{
    public class Playlist : INotifyPropertyChanged
    {
        private bool _isSelected;
        
        private ObservableCollection<Song> _songs;
        public string Title { get; set; }

        public ObservableCollection<Song> Songs
        {
            get { return _songs; }
            set
            {
                _songs = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public Playlist()
        {
            Songs = new ObservableCollection<Song>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

