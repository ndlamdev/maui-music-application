// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 22:12:53 - 26/12/2024
// User: Lam Nguyen

using maui_music_application.Models;
using maui_music_application.Services.Api;

namespace maui_music_application.Services.impl;

public class TopService(ITopPlayApi api) : ITopService
{
    public async Task<List<MusicCardInTop>> GetTracks()
    {
        var result = await api.GetTracks();
        return result.Data.Content;
    }

    public async Task<List<Album>> GetAlbums()
    {
        var result = await api.GetAlbums();
        return result.Data.Content;
    }

    public async Task<List<Artist>> GetArtist()
    {
        var result = await api.GetArtist();
        return result.Data.Content;
    }
}