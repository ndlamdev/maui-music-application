// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 01:01:32 - 01/01/2025
// User: Lam Nguyen

using maui_music_application.Attributes;
using maui_music_application.Helpers;

namespace maui_music_application.Views.Pages.Admin;

public partial class AddNewSongPage
{
    public AddNewSongPage()
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

    private bool IsClicked { get; set; }

    private void Back_OnClicked(object? sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Picker_OnSelectedArtistChanged(object? sender, EventArgs e)
    {
    }

    private async void TapGestureRecognizer_OnArtistTapped(object? sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View?)sender, 100);
        ArtistPicker.Unfocus();
        ArtistPicker.Focus();
    }

    [Todo("Handel action select album")]
    private void Picker_OnSelectedAlbumChanged(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<AddNewSongPage>();
    }

    private async void TapGestureRecognizer_OnAlbumTapped(object? sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View?)sender, 100);
        AlbumPicker.Unfocus();
        AlbumPicker.Focus();
    }

    [Todo("Handel action create new song")]
    private void Create_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<AddNewSongPage>();
    }

    [Todo("Handel action cancel create new song")]
    private async void Cancel_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<AddNewSongPage>();
        if (IsClicked) return;
        IsClicked = true;
        await OpacityEffect.RunOpacity((View?)sender, 100);
        await Navigation.PopAsync();
        IsClicked = false;
    }

    [Todo("Handel action upload song file")]
    private void UploadSong_OnTapped(object? sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<AddNewSongPage>();
    }

    [Todo("Handel action upload thumbnail file")]
    private void UploadThumbnail_OnTapped(object? sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<AddNewSongPage>();
    }
}