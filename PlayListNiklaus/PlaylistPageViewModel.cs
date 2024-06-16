using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayListNiklaus
{
    public class PlaylistPageViewModel : BindableObject
    {
        public Playlist SelectedPlaylist { get; set; }
        public Color BackgroundColor { get; set; }

        public PlaylistPageViewModel(Playlist selectedPlaylist, Color backgroundColor)
        {
            SelectedPlaylist = selectedPlaylist;
            BackgroundColor = backgroundColor;
        }

        // Other properties and methods of PlaylistPageViewModel
    }

}
