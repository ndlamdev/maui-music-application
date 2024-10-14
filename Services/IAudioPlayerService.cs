// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 09:10:09 - 14/10/2024
// User: Lam Nguyen

namespace maui_music_application.Services;

public interface IAudioPlayerService
{
    void Play(string url);
    void Pause();
    void Stop();
}
