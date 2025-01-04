// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 13:01:20 - 04/01/2025
// User: Lam Nguyen

using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Enum;

namespace maui_music_application.Services;

public interface ISearchService
{
    Task<ApiPaging<ResponseSearch>> Search(string name, SearchTypeEntry type, Pageable page);
}