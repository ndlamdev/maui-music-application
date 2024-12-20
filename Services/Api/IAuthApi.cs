using maui_music_application.Dto;
using maui_music_application.Models;
using Refit;

namespace maui_music_application.Services.Api;

public interface IAuthApi
{
    [Post("/auth/login")]
    Task<APIResponse<ResponseAuthentication>> Login([Body] RequestLogin request, CancellationToken cancellationToken);

    // Sử dụng để test
    [Get("/hello")]
    public Task<APIResponse<int>> Hello();

    [Post("/auth/register")]
    public Task<APIResponse> Register([Body] RequestRegister request);

    [Post("/auth/verify")]
    public Task<APIResponse> Verify([Body] RequestVerify request);

    [Post("/auth/logout")]
    public Task<APIResponse> Logout();

    [Post("/auth/verify")]
    public Task<APIResponse> VerifyRegister([Header("email")] string email, [Body] CodeVerify code);
}