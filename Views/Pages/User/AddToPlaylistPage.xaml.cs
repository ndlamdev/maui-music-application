// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 08:12:52 - 28/12/2024
// User: Lam Nguyen

using Android.Util;
using CommunityToolkit.Maui.Views;
using Java.Lang;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;
using maui_music_application.Views.Components.Popup;

namespace maui_music_application.Views.Pages.User;

public partial class AddToPlaylistPage
{
    private readonly long _musicId;
    private readonly Debouncer _debouncer = new();

    public AddToPlaylistPage(long musicId)
    {
        _musicId = musicId;
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
        LoadPlaylist();
    }

    private void OnBack(object? sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }

    private void NewPlaylist_Clicked(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new CreatePlaylistPage());
    }

    private void Search_OnOnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _debouncer.UseDebounced(() => { LoadPlaylist(e.NewTextValue); }, 750);
    }

    private void LoadPlaylist(string name = "")
    {
        var service = ServiceHelper.GetService<IPlaylistService>();
        if (service == null) throw new NullPointerException();
        var popup = LoadingPopup.GetInstance();
        this.ShowPopup(popup);
        service.GetPlaylistCardsNotHasSong(name, _musicId).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                ShowToastErrorHelper.ShowToast<AddToPlaylistPage, ApiPaging<PlaylistCard>>(task, popup,
                    "Load playlist failed: ");
                return;
            }

            if (!task.IsCompleted) return;
            popup.Close();
            var result = task.Result;
            LoadGridData(service, result.Content.ToArray());
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void LoadGridData(IPlaylistService service, PlaylistCard[] data)
    {
        GridLayoutPlaylist.Adapter(new PlaylistCardAdapter(
            data,
            Navigation,
            pl =>
            {
                Log.Info("Adding to the playlist", $"{pl.Id},  {_musicId}");
                service.AddSongIntoPlayList(pl.Id, _musicId).ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        ShowToastErrorHelper.ShowToast<AddToPlaylistPage, APIResponse>(task,
                            "Add song into playlist failed: ");
                        return;
                    }

                    AndroidHelper.ShowToast("Add song successful");
                    Navigation.PopAsync();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }));
    }
}