using Android.Util;
using maui_music_application.Dto;
using maui_music_application.Models;
using maui_music_application.Services.Api;
using Newtonsoft.Json;

namespace maui_music_application.Services.impl;

public class HomeServiceImpl(IHomeApi homeApi) : IHomeService
{
    public async Task<List<PlaylistCard>> GetPlayList()
    {
        try
        {
            APIResponse<List<PlaylistCard>> response = await homeApi.GetPlayList();
            if (response.StatusCode == 200)
            {
                List<PlaylistCard> cards = response.Data;
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

    public async Task<List<Album>> GetAlbumPopular()
    {
        try
        {
            APIResponse<List<Album>> response = await homeApi.GetPopularAlbum();
            if (response.StatusCode == 200)
            {
                List<Album> cards = response.Data;
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

    public async Task<List<MusicCard>> GetRecentSong()
    {
        try
        {
            APIResponse<List<MusicCard>> response = await homeApi.GetRecentSong();
            if (response.StatusCode == 200)
            {
                List<MusicCard> cards = response.Data;
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