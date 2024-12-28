// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 09:10:09 - 14/10/2024
// User: Lam Nguyen

using CommunityToolkit.Maui.Core.Primitives;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface IAudioPlayerService
{
    Action<MediaPositionChangedEventArgs>? PositionChanged { get; set; }
    Action<MediaStateChangedEventArgs>? StateChanged { get; set; }
    Action<MediaFailedEventArgs>? MediaFailed { get; set; }
    Action? MediaEnded { get; set; }
    void Play(int position);
    void Play();
    void Pause();
    void Stop();
    void Next();
    void Previous();
    double Duration { get; protected set; }
    bool PlayRandom { get; set; }
    MediaElementState CurrentState();
    bool Loop();
    void SeekTo(double position);
    void SetContent(Layout content);
    string SongName { get; }
    string SongThumbnail { get; }
    string SingerName { get; }
    PlaylistDetail? Playlist { get; set; }
    MusicCard? CurrentMusicCard { get; protected set; }
    Music? CurrentMusic { get; protected set; }
    void PlaySingleSong(long songId);
}