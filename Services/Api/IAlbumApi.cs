// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 07:12:29 - 27/12/2024
// User: Lam Nguyen

using maui_music_application.Dto;
using maui_music_application.Helpers;
using Refit;

namespace maui_music_application.Services.Api;

public interface IAlbumApi
{
    [Get("/album/{id}")]
    Task<APIResponse<ResponsePlaylistDetail>> GetAlbumDetail([AliasAs("id")] long playlistId,
        [Query] Pageable pageable);
}