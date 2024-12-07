using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface IPlaylistService
{
    Task<ResponseCreatePlaylist> CreatePlaylist(RequestCreatePlaylist id);
    Task<ApiPaging<ResponsePlaylistCard>> GetPlaylistCards(Pageable? pageable = null);

    Task<ResponsePlaylistDetail> GetPlaylistDetail(long playlistId, Pageable? pageable = null);
}