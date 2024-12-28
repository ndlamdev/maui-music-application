// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 07:12:43 - 27/12/2024
// User: Lam Nguyen

using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface IAlbumService
{
    public Task<PlaylistDetail> GetAlbumDetail(long id, Pageable? pageable = null);
}