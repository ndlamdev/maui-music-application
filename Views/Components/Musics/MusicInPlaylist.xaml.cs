// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:00 - 26/09/2024
// User: Lam Nguyen

using CommunityToolkit.Maui.Views;
using Java.Lang;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Enum;
using maui_music_application.Services;
using maui_music_application.Views.Components.Popup;
using maui_music_application.Views.Pages;

namespace maui_music_application.Views.Components.Musics;

public partial class MusicInPlaylist
{
    private string? _songName, _singerName, _songThumbnail;

    public MusicInPlaylist()
    {
        InitializeComponent();
        BindingContext = this;
    }


    public Action Action
    {
        set
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (_, _) =>
            {
                await OpacityEffect.RunOpacity(this, 100);
                value.Invoke();
            };
            GestureRecognizers.Add(tapGestureRecognizer);
        }
    }

    public string SongName
    {
        get => _songName ?? string.Empty;
        set
        {
            _songName = value;
            OnPropertyChanged();
        }
    }

    public string SingerName
    {
        get => _singerName ?? string.Empty;
        set
        {
            _singerName = value;
            OnPropertyChanged();
        }
    }

    public long SongId { get; set; }

    public long PlaylistId { get; set; }

    public bool CanRemove { get; set; }

    public TypePlaylist Type { get; set; }

    public string SongThumbnail
    {
        get => _songThumbnail ?? string.Empty;
        set
        {
            _songThumbnail = value;
            OnPropertyChanged();
        }
    }

    public Page Page { get; set; } = new();

    private async void ImageButton_OnClicked(object sender, TappedEventArgs e)
    {
        if (!CanRemove) return;
        await OpacityEffect.RunOpacity((View)sender, 100);
        var contextMenuPopup = new ContextMenuPopup();
        contextMenuPopup.SetMenuItems(["Xóa khỏi playlist"],
        [
            (_, _) =>
            {
                switch (Type)
                {
                    case TypePlaylist.Playlist:
                    {
                        RemoveSongInPlaylist(contextMenuPopup);
                        break;
                    }
                    case TypePlaylist.Favorite:
                    {
                        UnlikeSong(contextMenuPopup);
                        break;
                    }
                }
            }
        ]);
        contextMenuPopup.SetPoint(e.GetPosition(Page)?.X - 165 ?? 0,
            e.GetPosition(Page)?.Y + 10 ?? 0);
        Page.ShowPopup(contextMenuPopup);
    }

    private void UnlikeSong(ContextMenuPopup menu)
    {
        var service = ServiceHelper.GetService<ISongService>();
        if (service == null) throw new NullPointerException();
        var popupLoading = LoadingPopup.GetInstance();
        Page.ShowPopup(popupLoading);
        service.Like(true, SongId).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                ShowToastErrorHelper.ShowToast<MusicInPlaylist>(task, popupLoading,
                    "Unlike song failed: ");
                return;
            }

            if (!task.IsCompleted) return;
            popupLoading.Close();
            menu.Close();
            AndroidHelper.ShowToast(task.Result.Message);
            if (Page is PlaylistMusicPage page)
                page.RemoveSong(SongId);
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void RemoveSongInPlaylist(ContextMenuPopup menu)
    {
        var service = ServiceHelper.GetService<IPlaylistService>();
        if (service == null) throw new NullPointerException();
        var popupLoading = LoadingPopup.GetInstance();
        Page.ShowPopup(popupLoading);
        service.RemoveSongIntoPlayList(PlaylistId, SongId).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                ShowToastErrorHelper.ShowToast<MusicInPlaylist>(task, popupLoading,
                    "Remove song into playlist failed: ");
                return;
            }

            if (!task.IsCompleted) return;
            popupLoading.Close();
            menu.Close();
            AndroidHelper.ShowToast(task.Result.Message);
            if (Page is PlaylistMusicPage page)
                page.RemoveSong(SongId);
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
}