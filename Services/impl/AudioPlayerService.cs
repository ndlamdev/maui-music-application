// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 09:10:15 - 14/10/2024
// User: Lam Nguyen

using System.Timers;
using CommunityToolkit.Maui.Views;
using Timer = System.Timers.Timer;

namespace maui_music_application.Services.impl;

public class AudioPlayerService : IAudioPlayerService
{
    public event EventHandler? PositionChanged;
    private readonly MediaElement _mediaElement;

    public AudioPlayerService(MediaElement mediaElement)
    {
        _mediaElement = mediaElement;
        _mediaElement.PositionChanged += (sender, args) => PositionChanged?.Invoke(sender, args);
    }


    public void Play(string url)
    {
        _mediaElement.Source = url;
    }

    public void Pause()
    {
        _mediaElement.Pause();
    }

    public void Stop()
    {
        _mediaElement.Stop();
    }
}
