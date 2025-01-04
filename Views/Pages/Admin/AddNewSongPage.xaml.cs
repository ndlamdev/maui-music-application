// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 01:01:32 - 01/01/2025
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Helpers;
using maui_music_application.Services;
using maui_music_application.ViewModels;

namespace maui_music_application.Views.Pages.Admin;

public partial class AddNewSongPage
{
    private IAdminService _service;
    private readonly AddNewSongViewModel _viewModel;

    public AddNewSongPage()
    {
        _service = ServiceHelper.GetService<IAdminService>();
        _viewModel = new AddNewSongViewModel(true, Navigation);
        BindingContext = _viewModel;
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
        // LoadDataArtistAsync();
        // LoadDataAlbumPicker();
    }

    private bool IsClicked { get; set; }

    private void Back_OnClicked(object? sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }


    private async void TapGestureRecognizer_OnArtistTapped(object? sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View?)sender, 100);
        ArtistPicker.Unfocus();
        ArtistPicker.Focus();
    }


    private async void TapGestureRecognizer_OnAlbumTapped(object? sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View?)sender, 100);
        AlbumPicker.Unfocus();
        AlbumPicker.Focus();
    }

    private async void TapGestureRecognizer_OnGenreTapped(object? sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View?)sender, 100);
        GenrePicker.Unfocus();
        GenrePicker.Focus();
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

        await _viewModel.PickSourceAsync();
    }

    [Todo("Handle action upload thumbnail file")]
    private async void UploadThumbnail_OnTapped(object? sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<AddNewSongPage>();
        await _viewModel.PickThumbnailAsync();
    }

    [Todo("Handle action create new song")]
    private void Create_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<AddNewSongPage>();

        try
        {
            Log.Info("AddNewSongPage", $"Creating new song");
            _viewModel.OnSubmit(this);
        }
        catch (Exception ex)
        {
            Log.Error("AddNewSongPage", $"{ex.Message}");
        }
    }
}