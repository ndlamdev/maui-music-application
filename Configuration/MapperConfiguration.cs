using maui_music_application.Helpers.Mapper;

namespace maui_music_application.Configuration;

public static class MapperConfiguration
{
    public static void AddMappers(this MauiAppBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(PlaylistProfile).Assembly);
    }
}