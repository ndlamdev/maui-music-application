// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 07:12:47 - 27/12/2024
// User: Lam Nguyen

using maui_music_application.Helpers;
using maui_music_application.Helpers.Enum;
using maui_music_application.Models;
using maui_music_application.Services.Api;

namespace maui_music_application.Services.impl;

public class AlbumService(IAlbumApi api) : IAlbumService
{
    public async Task<PlaylistDetail> GetAlbumDetail(long id, Pageable? pageable = null)
    {
        var result = await api.GetAlbumDetail(id, pageable ?? new Pageable());
        var data = result.Data;
        data.Type = TypePlaylist.Album;
        data.TotalSong = data.Songs.Content.Count;
        return data;
    }
}