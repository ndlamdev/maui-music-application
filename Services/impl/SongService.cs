using Android.Util;
using Java.Lang;
using maui_music_application.Dto;
using maui_music_application.Models;
using maui_music_application.Services.Api;
using Exception = System.Exception;

namespace maui_music_application.Services.impl;

public class SongService(ISongApi api) : ISongService
{
    public async Task<Music> GetMusic(long id)
    {
        var response = await api.GetMusic(id);
        if (response.StatusCode != 200) throw new Exception();
        return response.Data;
    }

    public Task<APIResponse> Like(bool currentStatus, long id)
    {
        return currentStatus ? api.Unlike(id) : api.Like(id);
    }

    public async Task<ApiPaging<MusicCard>> GetMusics(int page, int size)
    {
        try
        {
            APIResponse<ApiPaging<MusicCard>> reponse = await api.GetMusics(page, size);
            return reponse.Data;
        }
        catch (Exception e)
        {
            Log.Error("SongService", $"{e.Message}");
            throw;
        }
    }
}