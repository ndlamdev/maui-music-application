// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 15:10:03 - 25/10/2024
// User: Lam Nguyen

using maui_music_application.Helpers;
using maui_music_application.Services;

namespace maui_music_application.Views.Fragments;

public partial class SongPageShowMore
{
    private string? _songName, _singerName, _thumbnail;
    private bool _isClick = false;
    private bool _like;

    public SongPageShowMore()
    {
        InitializeComponent();
        BindingContext = this;
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

    public string SongThumbnail
    {
        get => _thumbnail ?? string.Empty;
        set
        {
            _thumbnail = value;
            OnPropertyChanged();
        }
    }

    public long SongId { get; set; }

    public bool Like
    {
        get => _like;
        set
        {
            _like = value;
            OnPropertyChanged();
        }
    }

    private async void Back_OnClicked(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
        OnBack?.Invoke(sender, e);
    }

    private async void Heart_OnTapped(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
        var service = ServiceHelper.GetService<ISongService>();
        if (service == null || _isClick) return;
        _isClick = true;
        service.Like(Like, SongId)
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    _isClick = false;
                    AndroidHelper.ShowToast("Failed");
                    return;
                }

                if (!task.IsCompleted) return;
                _isClick = false;
                AndroidHelper.ShowToast(task.Result.Message);
                ServiceHelper.GetService<IAudioPlayerService>()!.CurrentMusic.Like = !Like;
                Like = !Like;
            }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public event EventHandler? OnBack;

    private void OnAddToPlaylist(object? sender, EventArgs e)
    {
    }

    private void OnAddToQueue(object? sender, EventArgs e)
    {
    }

    private void OnRemoveFromPlaylist(object? sender, EventArgs e)
    {
    }

    private void OnModifyTags(object? sender, EventArgs e)
    {
    }

    private void OnViewArtist(object? sender, EventArgs e)
    {
    }

    private void OnViewAlbum(object? sender, EventArgs e)
    {
    }

    private void OnChowCredits(object? sender, EventArgs e)
    {
    }

    private void OnDownload(object? sender, EventArgs e)
    {
    }

    private void OnShare(object? sender, EventArgs e)
    {
    }

    private void OnGenerateQRCode(object? sender, EventArgs e)
    {
    }

    private void OnSleepTimer(object? sender, EventArgs e)
    {
    }

    private void OnHideSong(object? sender, EventArgs e)
    {
    }

    private void OnGoToSongRadio(object? sender, EventArgs e)
    {
    }
}