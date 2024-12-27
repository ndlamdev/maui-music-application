using maui_music_application.Dto;

namespace maui_music_application.Services;

public interface IHomeService
{
    Task<List<ResponsePlaylistCard>> GetPlayList();

    Task<List<ResponseAlbumCard>> GetAlbumPopular();

    Task<List<ResponseSongCard>> GetRecentSong();
}