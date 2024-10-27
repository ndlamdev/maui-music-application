using maui_music_application.Attributes;

namespace maui_music_application.Views.Pages;

public partial class ForgetPasswordPage
{
    public ForgetPasswordPage()
    {
        InitializeComponent();
    }

    [Todo("Handle action click button back")]
    private void BackTapped(object? sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<ForgetPasswordPage>();
    }


    [Todo("Handle action click button find account")]
    private void FindAccount_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<ForgetPasswordPage>();
        var username = EntryEmail.Text;
    }


    [Todo("Handle action click button sign up")]
    private void SignUpTapped(object? sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<ForgetPasswordPage>();
    }
}
