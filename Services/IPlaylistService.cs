using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface IPlaylistService
{
    Task<APIResponse<ResponseCreatePlaylist>> CreatePlaylist(RequestCreatePlaylist request);

    Task<ApiPaging<PlaylistCard>> GetPlaylistCards(Pageable? pageable = null);

    Task<PlaylistDetail> GetPlaylistDetail(long playlistId, Pageable? pageable = null);
    
    Task<PlaylistDetail> GetFavorite(Pageable? pageable = null);

    Task<APIResponse> RemovePlayList(long id);

    Task<APIResponse> RemoveSongIntoPlayList(long playlistId, long songId);

    Task<APIResponse> AddSongIntoPlayList(long playlistId, long songId);

    Task<ApiPaging<PlaylistCard>> GetPlaylistCardsNotHasSong(string name, long id, Pageable? pageable = null);
}