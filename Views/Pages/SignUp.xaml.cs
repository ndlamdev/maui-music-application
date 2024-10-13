using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Helpers;

namespace maui_music_application.Views.Pages;

public partial class SignUp
{
    public SignUp()
    {
        InitializeComponent();
    }

    [Todo("Handle action click button log in")]
    private async void SignInTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<SignUp>();
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    [Todo("Handle action click button back")]
    private void BackTapped(object? sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<SignUp>();
    }


    [Todo("Handle action click button sign up")]
    private void SignUp_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<SignUp>();
        var username = EntryEmail.Text;
        var password = EntryPassword.Text;
        var confirmPassword = EntryConfirmPassword.Text;
    }
}
