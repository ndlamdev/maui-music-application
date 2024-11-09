// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 20:11:45 - 09/11/2024
// User: Lam Nguyen

namespace maui_music_application.Views.Pages;

public partial class ProfilePage
{
    public ProfilePage()
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

    private async void OnBack(object? sender, TappedEventArgs e)
    {
      await Navigation.PopAsync(true);
    }
}