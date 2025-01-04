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
using maui_music_application.Helpers.Enum;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;
using maui_music_application.Views.Components.Popup;

namespace maui_music_application.Views.Pages.User;

public partial class EditSongIntoPlaylistPage
{
    private readonly long _musicId;
    private readonly Debouncer _debouncer = new();
    private readonly bool _add = true;
    private readonly Action<long, long>? _customAction;
    private readonly Action<string, LoadingPopup>? _loadData;

    public EditSongIntoPlaylistPage(long musicId)
    {
        _musicId = musicId;
        InitializeComponent();
    }

    public EditSongIntoPlaylistPage(long musicId, bool add = true)
    {
        _musicId = musicId;
        _add = add;
        InitializeComponent();
    }

    public EditSongIntoPlaylistPage(long musicId, Action<string, LoadingPopup> loadData,
        Action<long, long> customAction)
    {
        _musicId = musicId;
        _customAction = customAction;
        _loadData = loadData;
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

    private void Search_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _debouncer.UseDebounced(() => LoadPlaylist(e.NewTextValue), 750);
    }

    private void LoadPlaylist(string name = "")
    {
        var service = ServiceHelper.GetService<IPlaylistService>();
        if (service == null) throw new NullPointerException();
        var popup = LoadingPopup.GetInstance();
        this.ShowPopup(popup);
        if (_customAction != null && _loadData != null)
        {
            _loadData.Invoke(name, popup);
            return;
        }

        if (_add)
        {
            service.GetPlaylistCardsNotHasSong(name, _musicId).ContinueWith(
                task => LoadDataHelper(service, popup, task), TaskScheduler.FromCurrentSynchronizationContext());
            return;
        }

        service.GetPlaylistCardsHasSong(name, _musicId).ContinueWith(
            task => LoadDataHelper(service, popup, task), TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void LoadDataHelper(IPlaylistService service, LoadingPopup popup, Task<ApiPaging<PlaylistCard>> task)
    {
        if (task.IsFaulted)
        {
            ShowToastErrorHelper.ShowToast<EditSongIntoPlaylistPage, ApiPaging<PlaylistCard>>(task, popup,
                "Load playlist failed: ");
            return;
        }

        if (!task.IsCompleted) return;
        popup.Close();
        var result = task.Result;
        LoadGridData(service, result.Content.ToArray());
    }

    private void LoadGridData(IPlaylistService service, PlaylistCard[] data)
    {
        GridLayoutPlaylist.Adapter(new PlaylistCardAdapter(
            data,
            Navigation,
            pl =>
            {
                Log.Info("Adding to the playlist", $"{pl.Id},  {_musicId}");
                if (_customAction != null)
                {
                    _customAction.Invoke(pl.Id, _musicId);
                    return;
                }

                if (_add)
                {
                    service.AddSongIntoPlayList(pl.Id, _musicId).ContinueWith(task =>
                    {
                        if (task.IsFaulted)
                        {
                            ShowToastErrorHelper.ShowToast<EditSongIntoPlaylistPage, APIResponse>(task,
                                "Add song into playlist failed: ");
                            return;
                        }

                        AndroidHelper.ShowToast("Add song successful");
                        Navigation.PopAsync();
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    return;
                }

                service.RemoveSongIntoPlayList(pl.Id, _musicId).ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        ShowToastErrorHelper.ShowToast<EditSongIntoPlaylistPage, APIResponse>(task,
                            "Remove song into playlist failed: ");
                        return;
                    }

                    AndroidHelper.ShowToast("Remove song successful");
                    Navigation.PopAsync();

                    var audioService = ServiceHelper.GetService<IAudioPlayerService>();
                    if (audioService == null || audioService.IsSingleSong() || audioService.Playlist == null ||
                        audioService.Playlist.Type == TypePlaylist.Favorite) return;
                    audioService.Playlist.AllSongId.Remove(_musicId);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }));
    }
}