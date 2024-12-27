using Android.Util;
using maui_music_application.Dto;
using maui_music_application.Services.Api;
using Newtonsoft.Json;

namespace maui_music_application.Services.impl;

public class HomeServiceImpl(IHomeApi homeApi) : IHomeService
{
    public async Task<List<ResponsePlaylistCard>> GetPlayList()
    {
        try
        {
            APIResponse<List<ResponsePlaylistCard>> response = await homeApi.GetPlayList();
            if (response.StatusCode == 200)
            {
                List<ResponsePlaylistCard> cards = response.Data;
                return cards;
            }
            return null;
        }
        catch (Refit.ApiException ex)
        {
            Log.Error("Call Api Home Page", "Error {0} , {1}", ex.StatusCode, ex.Message);
            throw;
        }
        catch (JsonException ex)
        {
            Log.Error("Call Api Home Page", "Parse failed, {0}", ex.Message);
            throw;
        }
    }

    public async Task<List<ResponseAlbumCard>> GetAlbumPopular()
    {
        try
        {
            APIResponse<List<ResponseAlbumCard>> response = await homeApi.GetPopularAlbum();
            if (response.StatusCode == 200)
            {
                List<ResponseAlbumCard> cards = response.Data;
                return cards;
            }
            return null;
        }
        catch (Refit.ApiException ex)
        {
            Log.Error("Call Api Home Page", "Error {0} , {1}", ex.StatusCode, ex.Message);
            throw;
        }
        catch (JsonException ex)
        {
            Log.Error("Call Api Home Page", "Parse failed, {0}", ex.Message);
            throw;
        }
    }

    public async Task<List<ResponseSongCard>> GetRecentSong()
    {
        try
        {
            APIResponse<List<ResponseSongCard>> response = await homeApi.GetRecentSong();
            if (response.StatusCode == 200)
            {
                List<ResponseSongCard> cards = response.Data;
                return cards;
            }
            return null;
        }
        catch (Refit.ApiException ex)
        {
            Log.Error("Call Api Home Page", "Error {0} , {1}", ex.StatusCode, ex.Message);
            throw;
        }
        catch (JsonException ex)
        {
            Log.Error("Call Api Home Page", "Parse failed, {0}", ex.Message);
            throw;
        }
    }
}