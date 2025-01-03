// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 01:01:32 - 01/01/2025
// User: Lam Nguyen

using Android.Util;
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

    [Todo("Handle action select album")]
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

    [Todo("Handle action create new song")]
    private void Create_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<AddNewSongPage>();
    }

    [Todo("Handle action cancel create new song")]
    private async void Cancel_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<AddNewSongPage>();
        if (IsClicked) return;
        IsClicked = true;
        await OpacityEffect.RunOpacity((View?)sender, 100);
        await Navigation.PopAsync();
        IsClicked = false;
    }

    [Todo("Handle action upload song file")]
    private async void UploadSong_OnTapped(object? sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<AddNewSongPage>();

        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Select a file",
            FileTypes = FilePickerFileType.Videos // Example: Restrict to image files
        });

        if (result != null)
        {
            // Access the file metadata
            string fileName = result.FileName;
            string fullPath = result.FullPath; // Available only on supported platforms
            Log.Info("AddNewSongPage", $"File name: {fileName}");
            Log.Info("AddNewSongPage", $"Full path: {fullPath}");

            // Read the file contents
            using var stream = await result.OpenReadAsync();
            // You can use the stream to process the file
            Log.Info("AddNewSongPage", $"File size: {stream.Length} bytes");
        }
    }

    [Todo("Handle action upload thumbnail file")]
    private async void UploadThumbnail_OnTapped(object? sender, TappedEventArgs e)
    {

        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Select a file",
            FileTypes = FilePickerFileType.Images // Example: Restrict to image files
        });

        if (result != null)
        {
            // Access the file metadata
            string fileName = result.FileName;
            string fullPath = result.FullPath; // Available only on supported platforms
            Log.Info("AddNewSongPage", $"File name: {fileName}");
            Log.Info("AddNewSongPage", $"Full path: {fullPath}");

            // Read the file contents
            using var stream = await result.OpenReadAsync();
            // You can use the stream to process the file
            Log.Info("AddNewSongPage", $"File size: {stream.Length} bytes");
        }
    }
}