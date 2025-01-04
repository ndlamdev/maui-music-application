using CommunityToolkit.Maui.Core.Primitives;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Enum;
using maui_music_application.Models;
using maui_music_application.Services;

namespace maui_music_application.Views.Pages.User;

public partial class SongInPlaylistPage
{
    private int _degree;
    private bool _playRandom;
    private IAudioPlayerService AudioService { get; set; } = null!;
    private bool _isClick;
    private bool _like;

    public SongInPlaylistPage(PlaylistDetail playlistDetail, int position = 0)
    {
        var service = ServiceHelper.GetService<IAudioPlayerService>();
        if (service is null)
        {
            Navigation.PopAsync();
            return;
        }

        AudioService = service;
        InitializeComponent();

        ShowMoreMenu.TranslationY = DeviceDisplay.Current.MainDisplayInfo.Height;
        SetIconButtonPlayPause();
        PlayRandom = AudioService.PlayRandom;

        AudioService.Playlist = playlistDetail;
        AudioService.SetContent(RootView);
        AudioService.PositionChanged = OnPositionChanged;
        AudioService.StateChanged = OnStateChanged;
        AudioService.MediaFailed = OnMediaFailed;
        AudioService.MediaEnded = OnMediaEnded;
        AudioService.Play(position);
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
    }

    public string PlayListName => AudioService.Playlist?.Name ?? string.Empty;

    public string SongName => AudioService.SongName;

    public bool Like
    {
        get => _like;
        set
        {
            _like = value;
            OnPropertyChanged();
            if (AudioService.IsSingleSong() || AudioService.Playlist is not { Type: TypePlaylist.Favorite }) return;
            AudioService.Playlist.AllSongId.Remove(SongId);
        }
    }

    public string SingerName => AudioService.SingerName;

    public string SongThumbnail => AudioService.SongThumbnail;

    public long SongId => AudioService.CurrentMusicCard?.Id ?? -1;

    private async void Option_OnTapped(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private async void Playlist_OnTapped(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PopAsync();
    }

    private async void Share_OnTapped(object sender, EventArgs eventArgs)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private async void Heart_OnTapped(object sender, EventArgs eventArgs)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        var service = ServiceHelper.GetService<ISongService>();
        if (service == null || _isClick) return;
        _isClick = true;
        await service.Like(Like, SongId)
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
                if (AudioService.CurrentMusic == null) return;
                Like = !Like;
                AudioService.CurrentMusic.Like = Like;
            }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void PlayPauseMusicClicked(object? sender, EventArgs e)
    {
        var current = AudioService.CurrentState();
        switch (current)
        {
            case MediaElementState.Stopped or MediaElementState.Paused:
                AudioService.Play();
                break;
            case MediaElementState.Playing:
                AudioService.Pause();
                break;
        }
    }

    private async void Random_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        PlayRandom = !PlayRandom;
    }

    private async void Previous_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        AudioService.Previous();
    }

    private async void Next_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        AudioService.Next();
    }


    private void OnPositionChanged(MediaPositionChangedEventArgs e)
    {
        if (!Process.Duration.Equals(AudioService.Duration))
            Process.Duration = AudioService.Duration;
        Process.TimeProgress = e.Position.TotalSeconds;
        ImageSongThumbnail.RotateTo(_degree += 2);
    }

    private void OnMediaFailed(MediaFailedEventArgs e)
    {
        AudioService.Next();
        MusicChanged();
    }

    private void OnStateChanged(MediaStateChangedEventArgs e)
    {
        SetIconButtonPlayPause();
        ShowMoreMenu.BindingContext ??= AudioService.CurrentMusicCard;
        if (AudioService.CurrentState() == MediaElementState.Opening)
            MusicChanged();
    }

    private void OnMediaEnded()
    {
        MusicChanged();
    }

    private void SetIconButtonPlayPause()
    {
        PlayPauseMusic.Icon = AudioService.CurrentState() switch
        {
            MediaElementState.Playing => "pause_white.svg",
            _ => "play_white.svg",
        };
    }

    private async void Equalizer_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private async void Add_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        ShowMoreMenu.SongName = SongName;
        ShowMoreMenu.SingerName = SingerName;
        ShowMoreMenu.SongThumbnail = SongThumbnail;
        ShowMoreMenu.SongId = SongId;
        ShowMoreMenu.Like = Like;
        await ShowMoreMenu.TranslateTo(0, 0, 500);
    }

    private async void Download_OnClicked(object sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private void Process_OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        if (AudioService.CurrentState() == MediaElementState.Playing) AudioService.Pause();
        _degree = (int)e.NewValue * 10;
        ImageSongThumbnail.Rotation = _degree;
    }

    public bool PlayRandom
    {
        get => _playRandom;
        set
        {
            _playRandom = value;
            AudioService.PlayRandom = value;
            OnPropertyChanged();
        }
    }

    private void Process_OnValueChangeCompleted(object? sender, double e)
    {
        AudioService.SeekTo(e);
    }

    private void ShowMoreMenu_OnOnBack(object? sender, EventArgs e)
    {
        ShowMoreMenu.TranslateTo(0, DeviceDisplay.Current.MainDisplayInfo.Height, 500);
        MusicChanged(false);
    }

    private void MusicChanged(bool resetDegree = true)
    {
        if (resetDegree)
            _degree = 0;
        OnPropertyChanged(nameof(SongName));
        OnPropertyChanged(nameof(SingerName));
        OnPropertyChanged(nameof(SongThumbnail));
        Like = AudioService.CurrentMusic?.Like ?? false;
    }

    private void ShowMoreMenu_OnRemoveFromPlaylistEvent(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new EditSongIntoPlaylistPage(SongId, false));
    }

    private void ShowMoreMenu_OnAddToPlaylistEvent(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new EditSongIntoPlaylistPage(SongId));
    }
}