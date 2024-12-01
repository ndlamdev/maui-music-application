// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 18:11:44 - 09/11/2024
// User: Lam Nguyen

using maui_music_application.Helpers;

namespace maui_music_application.Views.Pages;

public partial class CreatePlaylistPage
{
    public CreatePlaylistPage()
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
        await OpacityEffect.RunOpacity((View?)sender, 100);
        await Navigation.PopAsync(true);
    }

    private void Picker_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
    }

    private void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        OpacityEffect.RunOpacity((View?)sender, 100);
        MyPicker.Unfocus();
        MyPicker.Focus();
    }
}