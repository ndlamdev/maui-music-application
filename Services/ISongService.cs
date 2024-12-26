using maui_music_application.Dto;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface ISongService
{
    Task<Music> GetMusic(long id);
    Task<APIResponse> Like(bool currentStatus, long id);
    Task<List<MusicCard>> GetSongsFavorite();
}