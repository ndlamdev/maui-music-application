using maui_music_application.Dto;
using maui_music_application.Models;
using Refit;

namespace maui_music_application.Services.Api;

public interface ISongApi
{
    [Get("/song/detail/{id}")]
    Task<APIResponse<Music>> GetMusic([AliasAs("id")] long id);

    [Post("/song/like/{id}")]
    Task<APIResponse> Like([AliasAs("id")] long id);

    [Post("/song/unlike/{id}")]
    Task<APIResponse> Unlike([AliasAs("id")] long id);

    [Get("/song/list")]
    Task<APIResponse<ApiPaging<MusicCard>>> GetMusics([AliasAs("page")] int page, [AliasAs("size")] int size = 10);

  
}