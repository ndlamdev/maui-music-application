using Android.Util;
using CommunityToolkit.Maui.Core.Primitives;
using maui_music_application.Helpers;
using maui_music_application.Services;
using maui_music_application.Services.impl;

namespace maui_music_application.Views.Pages;

public partial class SongPage
{
    private string _playlistName = "Lofi Loft",
        _songName = "grainy days",
        _singerName = "moody.",
        _thumbnail = "song_image.png";

    private bool _isPans = false;

    private const string UrlTest =
        "https://res.cloudinary.com/yourstyle/video/upload/ac_aac/v1/music-media/audio/bau-troi-moi-dalab.m3u8";

    public SongPage()
    {
        InitializeComponent();
        BindingContext = this;
        MediaElement.Source = UrlTest;
    }

    public string PlayListName
    {
        get => _playlistName;
        set
        {
            _playlistName = value;
            OnPropertyChanged();
        }
    }

    public string SongName
    {
        get => _songName;
        set
        {
            _songName = value;
            OnPropertyChanged();
        }
    }

    public string SingerName
    {
        get => _singerName;
        set
        {
            _singerName = value;
            OnPropertyChanged();
        }
    }

    public string SongThumbnail
    {
        get => _thumbnail;
        set
        {
            _thumbnail = value;
            OnPropertyChanged();
        }
    }


    private async void Option_OnTapped(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private async void Playlist_OnTapped(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private async void Share_OnTapped(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private async void Heart_OnTapped(object sender, TappedEventArgs e)
    {
        var image = (Image)sender;
        await OpacityEffect.RunOpacity(image, 100);
    }

    private void PlayMusicClicked(object? sender, EventArgs e)
    {
        MediaElement.Play();
        PlayButton.Icon = "pause_white.svg";
        PlayButton.Clicked -= PlayMusicClicked;
        PlayButton.Clicked += PauseMusicClicked;
    }


    private void PauseMusicClicked(object? sender, EventArgs e)
    {
        MediaElement.Pause();
        PlayButton.Icon = "play_white.svg";
        PlayButton.Clicked -= PauseMusicClicked;
        PlayButton.Clicked += PlayMusicClicked;
    }

    private void MediaElement_OnMediaEnded(object? sender, EventArgs e)
    {
    }

    private void MediaElement_OnMediaFailed(object? sender, MediaFailedEventArgs e)
    {
    }

    private void MediaElement_OnMediaOpened(object? sender, EventArgs e)
    {
        Process.Duration = MediaElement.Duration.Seconds;
        PlayMusicClicked(sender, e);
    }

    private void MediaElement_OnSeekCompleted(object? sender, EventArgs e)
    {
    }

    private void MediaElement_OnPositionChanged(object? sender, MediaPositionChangedEventArgs e)
    {
        Process.TimeProgress = e.Position.Seconds;
        Log.Info("SongPage", $"Seconds: {e.Position.Seconds}");
    }

    private void Process_OnOnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        MediaElement.SeekTo(new TimeSpan((long)e.NewValue));
    }

    private void PanGestureRecognizer_OnPanUpdated(object? sender, PanUpdatedEventArgs e)
    {
        if (e.StatusType == GestureStatus.Completed)
        {
            _isPans = false;
        }

        if (_isPans) Log.Info("SongPage", $"Keo ne {e.TotalX}");
    }

    private void Process_OnOnDragStarted(object? sender, EventArgs e)
    {
        _isPans = true;
    }
}
