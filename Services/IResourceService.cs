using maui_music_application.Dto;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface IResourceService
{
    Task CreateResource(
        ResourceApp resource);

    public Task UploadFileToCloudinary(string filePath);

    Task UploadFileToBackend(Stream fileStream, string fileName);
}