using Java.Lang;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface ISongService
{
    Task<Music> GetMusic(long id);
}