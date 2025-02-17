using maui_music_application.Dto;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface IHomeService
{
    Task<List<PlaylistCard>> GetPlayList();

    Task<List<Album>> GetAlbumPopular();

    Task<List<MusicCard>> GetRecentSong();
}