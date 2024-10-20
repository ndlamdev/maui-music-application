using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using maui_music_application.Helpers;
using maui_music_application.Models;
using Random = Java.Util.Random;

namespace maui_music_application.Views.Pages;

public partial class SongPage
{
    private readonly PlayListMusic _playlist = new("", "My playlist", "")
    {
        Musics =
        [
            new Music("", "Bầu trời mới", "Dalab", "song_image.png",
                "https://res.cloudinary.com/yourstyle/video/upload/sp_hd/music-media/audio/bau-troi-moi-dalab.m3u8"),
            new Music("", "Mùa mưa ấy", "Vũ", "song_image.png",
                "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/mua_mua_ay.mp3"),
            new Music("", "Những lời hứa bỏ quên", "Vũ", "song_image.png",
                "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/nhung_loi_hua_bo_quen.mp3"),
            new Music("", "Và em sẽ là người tôi yêu nhất", "Vũ", "song_image.png",
                "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/va_em_se_la_nguoi_toi_yeu_nhat.mp3"),
            new Music("", "Những chuyến bay", "Vũ", "song_image.png",
                "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/nhung_chuyen_bay.mp3"),
            new Music("", "Nếu những tiếc nuối", "Vũ", "song_image.png",
                "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/neu_nhung_tiec_nuoi.mp3"),
            new Music("", "Mây khóc vì điều gì", "Vũ", "song_image.png",
                "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/may_khoc_vi_dieu_gi.mp3"),
            new Music("", "Ngồi trong vấn vương", "Vũ", "song_image.png",
                "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/ngoi_cho_trong_van_vuong.mp3"),
            new Music("", "Danh hết xuân thì để chờ nhau", "Vũ", "song_image.png",
                "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/danh_het_xuan_thi_de_cho_nhau.mp3"),
            new Music("", "Không yêu em thì yêu ai", "Vũ", "song_image.png",
                "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/khong_yeu_em_thi_yeu_ai.mp3"),
            new Music("", "Bình yên", "Vũ", "song_image.png",
                "https://res.cloudinary.com/dsap10o2q/video/upload/v1729425154/musium_maui/audio/binh_yen.mp3"),
        ]
    };

    private int _indexCurrentMusic, _previousIndexMusic;
    private int _degree;
    private bool _random;
    private MediaSource? _mediaSource;

    public SongPage()
    {
        InitializeComponent();
        BindingContext = this;
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
        get => _mediaSource ?? MediaSource.FromUri(_playlist.Musics![0].Uri);
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
}