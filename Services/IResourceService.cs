using maui_music_application.Dto;
using maui_music_application.Helpers.Enum;

namespace maui_music_application.Services;

public interface IResourceService
{
    ResponseSignature CreateResource(
        String nameFile,
        Tag tag);
}