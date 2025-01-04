using maui_music_application.Dto;
using maui_music_application.Models;
using Refit;

namespace maui_music_application.Services.Api;

public interface IAdminApi
{
    [Multipart]
    [Post("/admin/song/create")]
    Task<APIResponse> CreateMusic(
        [AliasAs("title")] string title,
        [AliasAs("artist")] string artist,
        [AliasAs("genre")] string genre,
        [AliasAs("album")] string album,
        [AliasAs("file_cover")] StreamPart filePart,
        [AliasAs("file_source")] StreamPart fileSource
    );

    [Get("/admin/album")]
    Task<APIResponse<List<string>>> GetAllAlbum();

    [Get("/admin/artist")]
    Task<APIResponse<List<string>>> GetAllArtist();
    
    [Get("/admin/genre")]
    Task<APIResponse<List<string>>> GetAllGenre();
}