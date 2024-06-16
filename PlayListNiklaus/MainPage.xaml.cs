using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace PlayListNiklaus
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
            
        }
     
    }
}
