using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services.Api;

namespace maui_music_application.Services.impl;

public class PlaylistService(IPlaylistApi api) : IPlaylistService
{
    public Task<APIResponse<ResponseCreatePlaylist>> CreatePlaylist(RequestCreatePlaylist request)
    {
        return api.CreatePlaylist(request);
    }

    public async Task<ApiPaging<PlaylistCard>> GetPlaylistCards(Pageable? pageable = null)
    {
        var response = await api.GetPlaylistCards(pageable ?? new Pageable());
        if (response.StatusCode != 200) throw new Exception();
        return response.Data;
    }

    public async Task<PlaylistDetail> GetPlaylistDetail(long playlistId, Pageable? pageable = null)
    {
        var response = await api.GetPlaylistDetail(playlistId, pageable ?? new Pageable());
        if (string.IsNullOrEmpty(response.Data.CoverUrl)) response.Data.CoverUrl = "main_logo.svg";
        return response.Data;
    }

    public async Task<PlaylistDetail> GetFavorite(Pageable? pageable = null)
    {
        var response = await api.GetFavorite(pageable ?? new Pageable());
        if (string.IsNullOrEmpty(response.Data.CoverUrl)) response.Data.CoverUrl = "main_logo.svg";
        return response.Data;
    }

    public Task<APIResponse> RemovePlayList(long id)
    {
        return api.RemovePlayList(id);
    }

    public Task<APIResponse> RemoveSongIntoPlayList(long playlistId, long songId)
    {
        return api.RemoveSongIntoPlayList(playlistId, songId);
    }

    public Task<APIResponse> AddSongIntoPlayList(long playlistId, long songId)
    {
        return api.AddSongIntoPlayList(playlistId, songId);
    }

    public async Task<ApiPaging<PlaylistCard>> GetPlaylistCardsNotHasSong(string name, long id,
        Pageable? pageable = null)
    {
        var response = await api.GetPlaylistCardsNotHasSong(name, id, pageable ?? new Pageable());
        return response.Data;
    }
}