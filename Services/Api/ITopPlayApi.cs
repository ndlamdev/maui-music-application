// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 22:12:28 - 26/12/2024
// User: Lam Nguyen

using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Models;
using Refit;

namespace maui_music_application.Services.Api;

public interface ITopPlayApi
{
    [Get("/filter/song/popular")]
    Task<APIResponse<ApiPaging<MusicCardInTop>>> GetTracks();

    [Get("/filter/artist/popular")]
    Task<APIResponse<ApiPaging<Artist>>> GetArtist();

    [Get("/filter/album/popular")]
    Task<APIResponse<ApiPaging<Album>>> GetAlbums();
}