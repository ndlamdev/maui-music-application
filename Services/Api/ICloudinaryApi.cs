using maui_music_application.Dto;
using Refit;

namespace maui_music_application.Services.Api;

public interface ICloudinaryApi
{

    [Multipart]
    [Post("/resource/upload")]
    Task<ApiResponse<ResponseCloudinaryUpload>> UploadFileAsync(
        [AliasAs("file")] StreamPart file,
        [AliasAs("folder")] string folder,
        [AliasAs("public_id")] string publicId,
        [AliasAs("timestamp")] string timestamp,
        [AliasAs("signature")] string signature,
        [AliasAs("api_key")] string apiKey
    );
}