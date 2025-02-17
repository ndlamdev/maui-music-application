// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 09:10:15 - 14/10/2024
// User: Lam Nguyen

using Android.Util;
using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using maui_music_application.Models;
using Exception = Java.Lang.Exception;

namespace maui_music_application.Services.impl;

public class AudioPlayerService : IAudioPlayerService
{
    public Action<MediaPositionChangedEventArgs>? PositionChanged { get; set; }
    public Action<MediaStateChangedEventArgs>? StateChanged { get; set; }
    public Action<MediaFailedEventArgs>? MediaFailed { get; set; }
    public Action? MediaEnded { get; set; }

    private int _indexCurrentSongInPlaylist, _indexPreviousSongInPlaylist;
    private MediaElement MediaElement { get; }
    private Layout? _content;
    private PlaylistDetail? _playlistDetail;
    private bool _endPlayList;
    private long _singleSongId = -1;

    private readonly ISongService _api;

    public AudioPlayerService(ISongService api)
    {
        _api = api;
        MediaElement = new MediaElement
        {
            ShouldAutoPlay = true,
            ShouldLoopPlayback = false,
            IsVisible = false,
            WidthRequest = 0,
            HeightRequest = 0,
        };
        MediaElement.PositionChanged += (_, args) =>
        {
            if (!Duration.Equals(MediaElement.Duration.TotalSeconds)) Duration = MediaElement.Duration.TotalSeconds;
            PositionChanged?.Invoke(args);
        };
        MediaElement.StateChanged += (_, args) => StateChanged?.Invoke(args);
        MediaElement.MediaEnded += (_, _) =>
        {
            if (!MediaElement.ShouldLoopPlayback)
            {
                if (IsSingleSong())
                {
                    _endPlayList = _indexCurrentSongInPlaylist == (Playlist?.TotalSong ?? 0) - 1;
                    Next();
                }
                else _endPlayList = true;
            }
            else
                Play();

            MediaEnded?.Invoke();
        };
        MediaElement.MediaFailed += (_, args) => MediaFailed?.Invoke(args);
    }

    public PlaylistDetail? Playlist
    {
        get => _playlistDetail;
        set
        {
            if (_playlistDetail != null && (value == null || value.Equals(_playlistDetail))) return;
            _singleSongId = -1;
            _indexCurrentSongInPlaylist = -1;
            _indexPreviousSongInPlaylist = -1;
            _playlistDetail = value;
        }
    }

    public bool PlayRandom { get; set; }

    public double Duration { get; set; }

    public MusicCard? CurrentMusicCard { get; set; }

    public Music? CurrentMusic { get; set; }

    public void PlaySingleSong(long songId)
    {
        _singleSongId = songId;
        LoadSong(songId);
    }

    public bool IsSingleSong()
    {
        return _singleSongId != -1;
    }

    public int Position()
    {
        return _indexCurrentSongInPlaylist;
    }

    public void ClearData()
    {
        Pause();
        Playlist = null;
        _singleSongId = -1;
        CurrentMusic = null;
        CurrentMusicCard = null;
    }

    public void Play(int position)
    {
        if (Playlist == null) throw new Exception("List nhạc đang bị rỗng. Hãy set playlist nhạc trước!");
        if (position == _indexCurrentSongInPlaylist ||
            position < 0 || position >= Playlist.TotalSong)
            return;

        _indexPreviousSongInPlaylist = _indexCurrentSongInPlaylist;
        _indexCurrentSongInPlaylist = position;
        LoadSong(Playlist.AllSongId.ElementAt(position));
    }

    private void LoadSong(long id)
    {
        if (id == (CurrentMusicCard?.Id ?? -1) && !_endPlayList)
        {
            MediaElement.Play();
            return;
        }

        _api.GetMusic(id).ContinueWith(task =>
        {
            if (!task.IsCompleted) return;
            CurrentMusic = task.Result;
            CurrentMusicCard =
                new MusicCard(CurrentMusic.Id, CurrentMusic.Title, CurrentMusic.Artist, CurrentMusic.Cover);
            MediaElement.Source = CurrentMusic.Url;
            MediaElement.MetadataTitle = CurrentMusic.Title;
            MediaElement.MetadataArtist = CurrentMusic.Artist;
            MediaElement.MetadataArtworkUrl = CurrentMusic.Cover;
            MediaElement.Source = CurrentMusic.Url;
            _endPlayList = false;
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void Play()
    {
        if (_endPlayList)
        {
            if (_singleSongId != -1)
            {
                LoadSong(_singleSongId);
                return;
            }

            _indexCurrentSongInPlaylist = -1;
            Play(0);
            _endPlayList = false;
        }
        else
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

        Play(Random.Shared.Next(Playlist?.TotalSong ?? -1));
    }

    public void Previous()
    {
        if (_indexPreviousSongInPlaylist < 0) return;
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

    public string SongName => CurrentMusicCard?.Title ?? "";

    public string SongThumbnail => CurrentMusicCard?.Cover ?? "";

    public string SingerName => CurrentMusicCard?.Artist ?? "";
}