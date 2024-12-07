using maui_music_application.Dto;
using maui_music_application.Models;
using Refit;

namespace maui_music_application.Services.Api;

public interface ISongApi
{
    [Get("/song/detail/{id}")]
    Task<APIResponse<Music>> GetMusic([AliasAs("id")] long id);
}