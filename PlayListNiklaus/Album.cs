using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Album : BindableObject
{
    private bool _isSelected;

    public string Title { get; set; }
    public string Artist { get; set; }
    public string CoverImage { get; set; }
    public string Genre { get; set; }
    public ObservableCollection<Song> Songs { get; set; } // Add this line

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

    public Album()
    {
        Songs = new ObservableCollection<Song>(); // Initialize the Songs collection
    }
}