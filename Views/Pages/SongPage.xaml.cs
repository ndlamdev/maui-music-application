using Android.Util;
using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using maui_music_application.Data;
using maui_music_application.Helpers;
using maui_music_application.Models;
using Random = Java.Util.Random;

namespace maui_music_application.Views.Pages;

public partial class SongPage
{
    private PlaylistMusic _playlist = SongPageData.Playlist;

    private int _indexCurrentMusic, _previousIndexMusic;
    private int _degree;
    private bool _random;
    private MediaSource? _mediaSource;

    public SongPage()
    {
        InitializeComponent();
        BindingContext = this;
        ShowMoreMenu.TranslationY = DeviceDisplay.Current.MainDisplayInfo.Height;
    }

    public SongPage(PlaylistMusic playlistMusic, int position)
    {
        _indexCurrentMusic = position;
        _previousIndexMusic = position;
        _playlist = playlistMusic;
        InitializeComponent();
        BindingContext = this;
        ShowMoreMenu.TranslationY = DeviceDisplay.Current.MainDisplayInfo.Height;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
    }

    public string PlayListName => _playlist.Title;

    public string SongName => _playlist.Musics![_indexCurrentMusic].Name;

    public string SingerName
        => _playlist.Musics![_indexCurrentMusic].Signer;

    public string SongThumbnail
        => _playlist.Musics![_indexCurrentMusic].Thumbnail;

    private async void Option_OnTapped(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private async void Playlist_OnTapped(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PopAsync();
    }

    private async void Share_OnTapped(object? sender, EventArgs eventArgs)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    private void Heart_OnTapped(object? sender, EventArgs eventArgs)
    {
    }

    private void PlayPauseMusicClicked(object? sender, EventArgs e)
    {
        switch (RootMediaElement.CurrentState)
        {
            case MediaElementState.Stopped or MediaElementState.Paused:
                PlayPauseMusic.Icon = "play_white.svg";
                RootMediaElement.Play();
                break;
            case MediaElementState.Playing:
                PlayPauseMusic.Icon = "pause_white.svg";
                RootMediaElement.Pause();
                break;
        }
    }

    private void Random_OnClicked(object? sender, EventArgs e)
    {
        Random = !_random;
    }

    private void Previous_OnClicked(object? sender, EventArgs e)
    {
        PlayMusic(ActionMusic.Previous);
    }

    private void Next_OnClicked(object? sender, EventArgs e)
    {
        PlayMusic(ActionMusic.Next);
    }

    private void RootMediaElement_OnMediaEnded(object? sender, EventArgs e)
    {
        PlayMusic(ActionMusic.Next);
    }

    private void RootMediaElement_OnPositionChanged(object? sender, MediaPositionChangedEventArgs e)
    {
        if (!Process.Duration.Equals(RootMediaElement.Duration.TotalSeconds))
            Process.Duration = RootMediaElement.Duration.TotalSeconds;
        Process.TimeProgress = e.Position.TotalSeconds;
        ImageSongThumbnail.RotateTo(_degree++);
    }

    private void RootMediaElement_OnMediaFailed(object? sender, MediaFailedEventArgs e)
    {
        PlayMusic(ActionMusic.Next);
    }

    private void RootMediaElement_OnStateChanged(object? sender, MediaStateChangedEventArgs e)
    {
        PlayPauseMusic.Icon = RootMediaElement.CurrentState switch
        {
            MediaElementState.Playing => "pause_white.svg",
            _ => "play_white.svg",
        };
    }

    private void Equalizer_OnClicked(object? sender, EventArgs e)
    {
    }

    private void Add_OnClicked(object? sender, EventArgs e)
    {
        ShowMoreMenu.SongName = SongName;
        ShowMoreMenu.SingerName = SingerName;
        ShowMoreMenu.SongThumbnail = SongThumbnail;
        ShowMoreMenu.TranslateTo(0, 0, 500);
    }

    private void Download_OnClicked(object? sender, EventArgs e)
    {
    }

    private void Process_OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        if (RootMediaElement.CurrentState == MediaElementState.Playing) RootMediaElement.Pause();
    }

    private void PlayMusic(ActionMusic action)
    {
        InitIndexCurrentMusic(action);
        _degree = 0;
        MusicMediaSource = MediaSource.FromFile(_playlist.Musics![_indexCurrentMusic].Uri);
        OnPropertyChanged(nameof(SongThumbnail));
        OnPropertyChanged(nameof(SongName));
        OnPropertyChanged(nameof(SingerName));
    }

    public bool Random
    {
        get => _random;
        set
        {
            _random = value;
            OnPropertyChanged();
        }
    }

    public MediaSource? MusicMediaSource
    {
        get => _mediaSource ?? MediaSource.FromUri(_playlist.Musics![_indexCurrentMusic].Uri);
        set
        {
            _mediaSource = value;
            OnPropertyChanged();
        }
    }


    private void ContentPage_Unloaded(object? sender, EventArgs e)
    {
        RootMediaElement.Handler?.DisconnectHandler();
    }

    private void InitIndexCurrentMusic(ActionMusic action)
    {
        if (action == ActionMusic.Previous) _indexCurrentMusic = _previousIndexMusic;
        else
        {
            _previousIndexMusic = _indexCurrentMusic;
            switch (_random)
            {
                case true:
                    var random = new Random();
                    _indexCurrentMusic = random.NextInt(_playlist.Musics!.Count);
                    break;
                case false when _indexCurrentMusic < _playlist.Musics!.Count - 1:
                    _indexCurrentMusic++;
                    break;
                default:
                    _indexCurrentMusic = 0;
                    break;
            }
        }
    }

    private enum ActionMusic
    {
        Next,
        Previous
    }

    private void RootMediaElement_OnSeekCompleted(object? sender, EventArgs e)
    {
        RootMediaElement.Play();
    }

    private async void Process_OnOnValueChangeCompleted(object? sender, double e)
    {
        await RootMediaElement.SeekTo(TimeSpan.FromSeconds(e));
    }

    private void ShowMoreMenu_OnOnBack(object? sender, EventArgs e)
    {
        ShowMoreMenu.TranslateTo(0, DeviceDisplay.Current.MainDisplayInfo.Height, 500);
    }
}