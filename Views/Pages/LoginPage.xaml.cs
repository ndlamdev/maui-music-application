using maui_music_application.Attributes;
using maui_music_application.Helpers;

namespace maui_music_application.Views.Pages;

public partial class LoginPage
{
    public LoginPage()
    {
        InitializeComponent();
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
    }

    [Todo("Handle action click button Sign up")]
    private async void SignUpTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<LoginPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PushAsync(new SignUpPage());
    }

    [Todo("Handle action click button back")]
    private async void BackTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<LoginPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PopAsync();
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
        await Navigation.PushAsync(new LoginWithPasswordPage());
    }
}