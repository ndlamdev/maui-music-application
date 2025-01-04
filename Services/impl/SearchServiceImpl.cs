// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 13:01:20 - 04/01/2025
// User: Lam Nguyen

using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Enum;
using maui_music_application.Services.Api;

namespace maui_music_application.Services.impl;

public class SearchServiceImpl(ISearchApi api) : ISearchService
{
    public async Task<ApiPaging<ResponseSearch>> Search(string name, SearchTypeEntry type, Pageable page)
    {
        var task = await api.Search(name, type, page.Page);
        return task.Data;
    }
}