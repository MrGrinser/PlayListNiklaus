using System.Windows.Input;

public class AlbumPageViewModel : BindableObject
{
    private Album _selectedAlbum;
    private Song _selectedSong;
    private bool _isSongSelected;

    public AlbumPageViewModel(Album album, Color background)
    {
        SelectedAlbum = album;
        Background = background;
        SongSelectedCommand = new Command<Song>(OnSongSelected);
    }

    public Album SelectedAlbum
    {
        get => _selectedAlbum;
        set
        {
            _selectedAlbum = value;
            OnPropertyChanged();
        }
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

    public Color Background { get; }

    private void OnSongSelected(Song song)
    {
        SelectedSong = song;
        IsSongSelected = true;

        // Update the IsSelected property for each song
        foreach (var s in SelectedAlbum.Songs)
        {
            s.IsSelected = s == song;
        }
    }
}
