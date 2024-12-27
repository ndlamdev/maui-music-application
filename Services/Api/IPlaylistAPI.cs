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

    [Delete("/playlist/{id}")]
    Task<APIResponse> RemovePlayList([AliasAs("id")] long id);

    [Put("/playlist/remove/{playlist-id}/{song-id}")]
    Task<APIResponse> RemoveSongIntoPlayList([AliasAs("playlist-id")] long playlistID, [AliasAs("song-id")] long songID);
}