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

    private const string UrlTest =
        "https://res.cloudinary.com/dsap10o2q/video/upload/v1728828855/musium_maui/audio/neu_nhung_tiec_nuoi.mp3";

    public SongPage()
    {
        InitializeComponent();
        BindingContext = this;
        MediaElement.Source = UrlTest;
        Process.Duration = 100;
        //FileHelper.GetDurationFileM3u8(UrlTest).Result
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

    private async void MediaElement_OnMediaOpened(object? sender, EventArgs e)
    {
        var duration = await FileHelper.GetDurationFileM3U8(UrlTest);
        Process.Duration = duration;
        PlayMusicClicked(sender, e);
    }

    private void MediaElement_OnSeekCompleted(object? sender, EventArgs e)
    {
    }

    private void MediaElement_OnPositionChanged(object? sender, MediaPositionChangedEventArgs e)
    {
        Process.TimeProgress = e.Position.Seconds;
    }

    private void Random_OnClicked(object? sender, EventArgs e)
    {
    }

    private void Previous_OnClicked(object? sender, EventArgs e)
    {
    }

    private void Next_OnClicked(object? sender, EventArgs e)
    {
    }

    private void Equalizer_OnClicked(object? sender, EventArgs e)
    {
    }

    private void Add_OnClicked(object? sender, EventArgs e)
    {
    }

    private void Download_OnClicked(object? sender, EventArgs e)
    {
    }

    private void Process_OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        if ((int)MediaElement.Position.TotalSeconds == (int)e.NewValue) return;
        MediaElement.SeekTo(TimeSpan.FromSeconds(e.NewValue));
    }
}