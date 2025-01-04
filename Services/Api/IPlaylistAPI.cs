using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Models;
using Refit;

namespace maui_music_application.Services.Api;

public interface IPlaylistApi
{
    [Post("/playlist")]
    Task<APIResponse<ResponseCreatePlaylist>> CreatePlaylist([Body] RequestCreatePlaylist request);

    [Get("/playlist")]
    Task<APIResponse<ApiPaging<PlaylistCard>>> GetPlaylistCards([Query] int page);

    [Get("/playlist/playlist-to-add-song")]
    Task<APIResponse<ApiPaging<PlaylistCard>>> GetPlaylistCardsNotHasSong(
        [AliasAs("name")] string name,
        [AliasAs("id")] long id,
        [Query] int page);

    [Get("/playlist/playlist-to-remove-song")]
    Task<APIResponse<ApiPaging<PlaylistCard>>> GetPlaylistCardsHasSong(
        [AliasAs("name")] string name,
        [AliasAs("id")] long id,
        [Query] int page);

    [Get("/playlist/detail/{id}")]
    Task<APIResponse<PlaylistDetail>> GetPlaylistDetail([AliasAs("id")] long playlistId,
        [Query] int page);

    [Get("/playlist/favorite")]
    Task<APIResponse<PlaylistDetail>> GetFavorite([Query] int page);

    [Delete("/playlist/{id}")]
    Task<APIResponse> RemovePlayList([AliasAs("id")] long id);

    [Put("/playlist/remove/{playlist-id}/{song-id}")]
    Task<APIResponse> RemoveSongIntoPlayList([AliasAs("playlist-id")] long playlistId,
        [AliasAs("song-id")] long songId);

    [Put("/playlist/add/{playlist-id}/{song-id}")]
    Task<APIResponse> AddSongIntoPlayList([AliasAs("playlist-id")] long playlistId,
        [AliasAs("song-id")] long songId);
}