using Android.Util;
using maui_music_application.Configuration;
using maui_music_application.Dto;
using maui_music_application.Models;
using maui_music_application.Services.Api;

namespace maui_music_application.Services.impl;

public class GenreServicesImpl(IGenreApi genreApi) : IGenreServices
{
    private const int DefaultPage = 1;
    private const int DefaultPageSize = 10;
    private const string DefaultSortBy = "id";

    public async Task<List<KindMusic>> GetCategories()
    {
        try
        {
            APIResponse<ApiPaging<ResponseGenre>> response = await genreApi.GetGenres(
                DefaultPage, DefaultPageSize, DefaultSortBy
            );
            Log.Info("Genre Service", $"{response.Data} {response.Data.Size}");
            if (response.Data.Size != 0)
            {
                List<KindMusic> result = new List<KindMusic>();
                foreach (var item in response.Data.Content)
                {
                    result.Add(new KindMusic(
                        item.Id,
                        item.Name,
                        item.Cover == null ? AppConstraint.DefaultCoverGenre : item.Cover
                    ));
                }

                return result;
            }

            return [];
        }
        catch (Exception e)
        {
            throw;
        }
    }
}