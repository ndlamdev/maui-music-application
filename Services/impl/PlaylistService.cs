using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Services.Api;

namespace maui_music_application.Services.impl;

public class PlaylistService(IPlaylistApi api) : IPlaylistService
{
    public async Task<ResponseCreatePlaylist> CreatePlaylist(RequestCreatePlaylist request)
    {
        var response = await api.CreatePlaylist(request);
        if (response.StatusCode != 200) throw new Exception();
        return response.Data;
    }

    public async Task<ApiPaging<ResponsePlaylistCard>> GetPlaylistCards(Pageable? pageable = null)
    {
        var response = await api.GetPlaylistCards(pageable ?? new Pageable());
        if (response.StatusCode != 200) throw new Exception();
        return response.Data;
    }

    public async Task<ResponsePlaylistDetail> GetPlaylistDetail(long playlistId, Pageable? pageable = null)
    {
        var response = await api.GetPlaylistDetail(playlistId, pageable ?? new Pageable());
        if (response.StatusCode != 200) throw new Exception();
        if (string.IsNullOrEmpty(response.Data.CoverUrl)) response.Data.CoverUrl = "main_logo.svg";
        return response.Data;
    }
}