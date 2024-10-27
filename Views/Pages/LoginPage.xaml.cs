using maui_music_application.Attributes;
using maui_music_application.Helpers;

namespace maui_music_application.Views.Pages;

public partial class LoginPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    [Todo("Handle action click button Sign up")]
    private void SignUpTapped(object? sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<LoginPage>();
    }

    [Todo("Handle action click button back")]
    private void BackTapped(object? sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<LoginPage>();
    }

    [Todo("Handle action click button login by Google")]
    private void LoginGoogle_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<LoginPage>();
    }

    [Todo("Handle action click button login by Facebook")]
    private void LoginFacebook_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<LoginPage>();
    }

    [Todo("Handle action click button login by Apple ID")]
    private void LoginAppleID_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<LoginPage>();
    }

    [Todo("Handle action click button login with password")]
    private async void LoginWithPassword_OnClicked(object sender, EventArgs e)
    {
        TodoAttribute.PrintTask<LoginPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
    }
}
