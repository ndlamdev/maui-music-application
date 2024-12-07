using maui_music_application.Dto;
using maui_music_application.Helpers;
using Refit;

namespace maui_music_application.Services.Api;

public interface IPlaylistApi
{
    [Post("/playlist")]
    Task<APIResponse<ResponseCreatePlaylist>> CreatePlaylist([Body] RequestCreatePlaylist request);

    [Get("/playlist")]
    Task<APIResponse<ApiPaging<ResponsePlaylistCard>>> GetPlaylistCards([Query] Pageable request);

    [Get("/playlist/{id}")]
    Task<APIResponse<ResponsePlaylistDetail>> GetPlaylistDetail([AliasAs("id")] long playlistId,
        [Query] Pageable pageable);
}