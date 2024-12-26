using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Services.Api;

namespace maui_music_application.Services.impl;

public class PlaylistService(IPlaylistApi api) : IPlaylistService
{
    public Task<APIResponse<ResponseCreatePlaylist>> CreatePlaylist(RequestCreatePlaylist request)
    {
        return api.CreatePlaylist(request);
    }

    public async Task<ApiPaging<ResponsePlaylistCard>> GetPlaylistCards(Pageable? pageable = null)
    {
        var response = await api.GetPlaylistCards(pageable ?? new Pageable());
        if (response.StatusCode != 200) throw new Exception();
        return response.Data;
    }

    public async Task<APIResponse<ResponsePlaylistDetail>> GetPlaylistDetail(long playlistId, Pageable? pageable = null)
    {
        var response = await api.GetPlaylistDetail(playlistId, pageable ?? new Pageable());
        if (string.IsNullOrEmpty(response.Data.CoverUrl)) response.Data.CoverUrl = "main_logo.svg";
        return response;
    }

    public Task<APIResponse> RemovePlayList(long id)
    {
        return api.RemovePlayList(id);
    }

    public Task<APIResponse> RemoveSongIntoPlayList(long playlistId, long songId)
    {
        return api.RemoveSongIntoPlayList(playlistId, songId);
    }
}