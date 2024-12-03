// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 00:10:15 - 06/10/2024
// User: Lam Nguyen

using maui_music_application.Attributes;
using maui_music_application.Helpers;
using maui_music_application.Services;

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
    private async void ButtonBorderShadow_OnClicked(object? sender, EventArgs e)
    {
        IUserService userService = ServiceHelper.GetService<IUserService>();
        TodoAttribute.PrintTask<WelcomePage>();
        bool isLogin = await userService.CheckIfUserHasAccount();
        if (isLogin)
        {
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}