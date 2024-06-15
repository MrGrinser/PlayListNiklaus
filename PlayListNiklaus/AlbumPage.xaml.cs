using Microsoft.Maui.Controls;

namespace PlayListNiklaus
{
    public partial class AlbumPage : ContentPage
    {
        public AlbumPage()
        {
            InitializeComponent();
            var mainPage = Application.Current.MainPage as MainPage;
            BindingContext = mainPage?.BindingContext;
        }
    }
}
