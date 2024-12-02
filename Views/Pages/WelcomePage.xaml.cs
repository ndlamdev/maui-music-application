// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 00:10:15 - 06/10/2024
// User: Lam Nguyen

using maui_music_application.Attributes;

namespace maui_music_application.Views.Pages;

public partial class WelcomePage
{
    public WelcomePage()
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

    [Todo("Handle button 'Get Started'")]
    private void ButtonBorderShadow_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<WelcomePage>();
        Navigation.PushAsync(new LoginPage());
    }
}