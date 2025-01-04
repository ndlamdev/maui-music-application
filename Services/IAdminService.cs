using maui_music_application.Dto;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface IAdminService
{

    Task CreateMusic(RequestCreateSong request);

    Task<List<string>> GetAllArtists();
    Task<List<string>> GetAllAlbums();
    Task<List<string>> GetAllGenre();
}