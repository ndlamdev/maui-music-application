using Refit;

namespace maui_music_application.Services.Api;

public interface IServerApi
{
    [Head("/status")]
    Task Status();
}