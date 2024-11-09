using maui_music_application.Helpers;
using maui_music_application.ViewModels;
using maui_music_application.Views.Pages;

namespace maui_music_application.Views.Components.Header;

public partial class Header
{
    private bool _isChangePage;

    public Header()
    {
        InitializeComponent();
        BindingContext = new HeaderViewModel();
    }

    private async void TapGestureRecognizer_OnTapped(object? sender, EventArgs eventArgs)
    {
        if (_isChangePage) return;
        _isChangePage = true;
        OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PushAsync(new ProfilePage(), true);
        _isChangePage = false;
    }
}