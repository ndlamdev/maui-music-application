// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 13:01:05 - 04/01/2025
// User: Lam Nguyen

using maui_music_application.Dto;
using maui_music_application.Helpers.Enum;
using Refit;

namespace maui_music_application.Services.Api;

public interface ISearchApi
{
    [Get("/search")]
    Task<APIResponse<ApiPaging<ResponseSearch>>> Search(string name, SearchTypeEntry type, int page);
}