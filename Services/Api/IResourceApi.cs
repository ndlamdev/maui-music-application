using maui_music_application.Dto;
using Refit;

namespace maui_music_application.Services.Api;

public interface IResourceApi
{
    [Post("/resource/signature-key")]
    Task<APIResponse<ResponseSignature>> GetSignature([Body] RequestSignature request);

}