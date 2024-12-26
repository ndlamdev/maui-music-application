using maui_music_application.Dto;
using Refit;

namespace maui_music_application.Services.Api;

public interface IHomeApi
{
    [Get("/home/playlist")]
    Task<APIResponse<List<ResponsePlaylistCard>>> GetPlayList();

    [Get("/home/mixes")]
    Task<APIResponse<List<ResponseAlbumCard>>> GetPopularAlbum();

    [Get("/home/recent")]
    Task<APIResponse<List<ResponseSongCard>>> GetRecentSong();
}