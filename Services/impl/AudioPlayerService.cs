// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 09:10:15 - 14/10/2024
// User: Lam Nguyen

using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using maui_music_application.Models;
using Exception = Java.Lang.Exception;

namespace maui_music_application.Services.impl;

public class AudioPlayerService : IAudioPlayerService
{
    public event EventHandler<MediaPositionChangedEventArgs>? PositionChanged;
    public event EventHandler<MediaStateChangedEventArgs>? StateChanged;
    public event EventHandler<MediaFailedEventArgs>? MediaFailed;
    public event EventHandler? MediaEnded;
    private static AudioPlayerService? _instance;
    private int _indexCurrentSongInPlaylist = -1, _indexPreviousSongInPlaylist;
    private MediaElement MediaElement { get; }
    private Layout? _content;

    private AudioPlayerService()
    {
        MediaElement = new MediaElement
        {
            ShouldAutoPlay = true,
            ShouldLoopPlayback = false,
            IsVisible = false,
            WidthRequest = 0,
            HeightRequest = 0,
        };
        MediaElement.PositionChanged += (sender, args) =>
        {
            if (!Duration.Equals(MediaElement.Duration.TotalSeconds)) Duration = MediaElement.Duration.TotalSeconds;
            PositionChanged?.Invoke(sender, args);
        };
        MediaElement.StateChanged += (sender, args) => StateChanged?.Invoke(sender, args);
        MediaElement.MediaEnded += (sender, args) => MediaEnded?.Invoke(sender, args);
        MediaElement.MediaFailed += (sender, args) => MediaFailed?.Invoke(sender, args);
    }

    public static AudioPlayerService GetInstance()
    {
        return _instance ??= new AudioPlayerService();
    }

    public PlaylistMusic? Playlist { get; set; }
    public bool PlayRandom { get; set; }
    public double Duration { get; set; }
    public Music? CurrentMusic { get; set; }

    public void Play(int position)
    {
        if (Playlist == null) throw new Exception("List nhạc đang bị rỗng. Hãy set playlist nhạc trước!");
        if (position == _indexCurrentSongInPlaylist ||
            (position < 0 && position >= Playlist.Musics!.Count)) return;
        _indexPreviousSongInPlaylist = _indexCurrentSongInPlaylist;
        _indexCurrentSongInPlaylist = position;
        CurrentMusic = Playlist.Musics!.ElementAt(position);

        MediaElement.MetadataTitle = CurrentMusic.Name;
        MediaElement.MetadataArtist = CurrentMusic.Signer;
        MediaElement.MetadataArtworkUrl = CurrentMusic.Thumbnail;
        MediaElement.Source = CurrentMusic.Uri;
    }

    public void Play()
    {
        MediaElement.Play();
    }

    public void Pause()
    {
        MediaElement.Pause();
    }

    public void Stop()
    {
        MediaElement.Stop();
    }

    public void Next()
    {
        if (!PlayRandom)
        {
            Play(_indexCurrentSongInPlaylist + 1);
            return;
        }

        _indexCurrentSongInPlaylist = Random.Shared.Next(Playlist!.Musics?.Count ?? -1);
        Play(_indexCurrentSongInPlaylist);
    }

    public void Previous()
    {
        Play(_indexPreviousSongInPlaylist);
    }

    MediaElementState IAudioPlayerService.CurrentState()
    {
        return MediaElement.CurrentState;
    }

    public bool Loop()
    {
        return MediaElement.ShouldLoopPlayback = !MediaElement.ShouldLoopPlayback;
    }

    public async void SeekTo(double position)
    {
        await MediaElement.SeekTo(TimeSpan.FromSeconds(position));
        Play();
    }

    public void SetContent(Layout content)
    {
        if (_content != null) return;
        _content = content;
        content.Add(MediaElement);
    }

    public string SongName => CurrentMusic!.Name;

    public string SongThumbnail => CurrentMusic!.Thumbnail;

    public string SingerName => CurrentMusic!.Signer;
}