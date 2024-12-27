using maui_music_application.ViewModels;
using maui_music_application.Views.Pages;

namespace maui_music_application.Views.Components.Header;

public partial class Header
{
    public Header()
    {
        InitializeComponent();
        BindingContext = new HeaderViewModel();
    }

    private void ButtonIcon_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new TopPage());
    }
}