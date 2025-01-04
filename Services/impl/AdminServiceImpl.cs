using System.Net;
using Android.Util;
using maui_music_application.Dto;
using maui_music_application.Models;
using maui_music_application.Services.Api;
using Refit;

namespace maui_music_application.Services.impl;

public class AdminServiceImpl(IAdminApi api) : IAdminService
{
    public async Task CreateMusic(RequestCreateSong request)
    {
        try
        {
            await api.CreateMusic(
                request.Title,
                request.Artist,
                request.Genre,
                request.Album,
                request.FileThumbnail,
                request.FileSource
            );
        }
        catch (ApiException e)
        {
            Log.Error("AdminService", e.Message);
            if (e.StatusCode == HttpStatusCode.Conflict)
            {
                throw new Exception("Nhạc với tên bạn đặt đã tồn tại", e);
            }
            if (e.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new Exception("Tạo bài hát không thành công! Máy chủ có vấn đề", e);
            }
        }
        catch (Exception e)
        {

            throw new Exception("Exception", e);
        }
    }

    public async Task<List<string>> GetAllArtists()
    {
        APIResponse<List<string>> response = await api.GetAllArtist();
        return response.Data;
    }

    public async Task<List<string>> GetAllAlbums()
    {
        APIResponse<List<string>> response = await api.GetAllAlbum();
        return response.Data;
    }

    public async Task<List<string>> GetAllGenre()
    {
        APIResponse<List<string>> response = await api.GetAllGenre();
        return response.Data;
    }
}