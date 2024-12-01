using maui_music_application.Dto;
using Refit;

namespace maui_music_application.Services.Api;

public interface IAuthApi
{
    [Post("/auth/login")]
    Task<APIResponse<ResponseAuthDTO>> Login(RequestAuthDTO request);

    // Sử dụng để test
    [Get("/hello")]
    public Task<APIResponse<int>> Hello();

}