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
    event EventHandler<MediaPositionChangedEventArgs>? PositionChanged;
    event EventHandler<MediaStateChangedEventArgs>? StateChanged;
    event EventHandler<MediaFailedEventArgs>? MediaFailed;
    event EventHandler? MediaEnded;
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
    PlaylistMusic? Playlist { get; set; }
    Music? CurrentMusic { get; protected set; }
}