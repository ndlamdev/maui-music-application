using maui_music_application.Dto;
using maui_music_application.Models;
using Refit;

namespace maui_music_application.Services.Api;

public interface IHomeApi
{
    [Get("/home/playlist")]
    Task<APIResponse<List<PlaylistCard>>> GetPlayList();

    [Get("/home/mixes")]
    Task<APIResponse<List<Album>>> GetPopularAlbum();

    [Get("/home/recent")]
    Task<APIResponse<List<MusicCard>>> GetRecentSong();
}