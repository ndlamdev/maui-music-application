using maui_music_application.Dto;
using maui_music_application.Models;

namespace maui_music_application.Services;

public interface IGenreServices
{
    Task<List<KindMusic>> GetCategories();
}