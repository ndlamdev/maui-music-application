using maui_music_application.Dto;
using maui_music_application.Helpers;

namespace maui_music_application.Services;

public interface IPlaylistService
{
    Task<APIResponse<ResponseCreatePlaylist>> CreatePlaylist(RequestCreatePlaylist request);

    Task<ApiPaging<ResponsePlaylistCard>> GetPlaylistCards(Pageable? pageable = null);

    Task<APIResponse<ResponsePlaylistDetail>> GetPlaylistDetail(long playlistId, Pageable? pageable = null);

    Task<APIResponse> RemovePlayList(long id);
    
    Task<APIResponse> RemoveSongIntoPlayList(long playlistId, long songId);
    
    Task<APIResponse> AddSongIntoPlayList(long playlistId, long songId);
    
    Task<ApiPaging<ResponsePlaylistCard>> GetPlaylistCardsNotHasSong(string name, long id, Pageable? pageable = null);
}