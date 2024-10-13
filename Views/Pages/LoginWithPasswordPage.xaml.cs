using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Helpers;

namespace maui_music_application.Views.Pages;

public partial class LoginWithPasswordPage
{
    public LoginWithPasswordPage()
    {
        InitializeComponent();
    }

    [Todo("Handle action click button Sign up")]
    private async void SignUpTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<LoginWithPasswordPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    [Todo("Handle action click button back")]
    private void BackTapped(object? sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<LoginWithPasswordPage>();
    }

    [Todo("Handle action click button login with password")]
    private void LoginWithPassword_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<LoginWithPasswordPage>();
        var username = EntryEmail.Text;
        var password = EntryPassword.Text;
        var rememberMe = CheckBoxRememberMe.IsChecked;
    }

    [Todo("Handle action click button forget password")]
    private async void ForgetPassword_OnTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<LoginWithPasswordPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private void RememberMe_OnTapped(object? sender, TappedEventArgs e)
    {
        CheckBoxRememberMe.IsChecked = !CheckBoxRememberMe.IsChecked;
    }
}
