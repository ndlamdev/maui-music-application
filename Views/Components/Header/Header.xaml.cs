using maui_music_application.ViewModels;

namespace maui_music_application.Components.Header;

public partial class Header : ContentView
{
    public Header()
    {
        InitializeComponent();
        BindingContext = new HeaderViewModel();
    }
}