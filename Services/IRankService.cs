// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 21:12:31 - 26/12/2024
// User: Lam Nguyen

using maui_music_application.Models;

namespace maui_music_application.Services;

public interface IRankService
{
    Task<List<MusicCardInTop>> GetTracks();
    Task<List<Album>> GetAlbums();
    Task<List<Artist>> GetArtist();
}