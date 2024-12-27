using maui_music_application.Dto;
using Refit;

namespace maui_music_application.Services.Api;

public interface IGenreApi
{
    [Get("/genre")]
    Task<APIResponse<ApiPaging<ResponseGenre>>> GetGenres([Query] int page, [Query] int size, [Query] string sortBy);
}