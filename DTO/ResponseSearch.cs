// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 13:01:50 - 04/01/2025
// User: Lam Nguyen

using maui_music_application.Helpers.Enum;

namespace maui_music_application.Dto;

public class ResponseSearch
{
    public object Data { get; set; }

    public SearchTypeEntry Type { get; set; } = SearchTypeEntry.All;
}