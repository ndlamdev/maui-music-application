using CommunityToolkit.Maui;
using maui_music_application.Configuration;
using maui_music_application.Handlers;
using maui_music_application.Helpers;
using Microsoft.Extensions.Logging;

namespace maui_music_application;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Mulish-Italic-VariableFont.ttf", "MulishItalicVariableFont");
                fonts.AddFont("Mulish-VariableFont.ttf", "MulishVariableFont");
                fonts.AddFont("Century-Gothic-Italic.otf", "CenturyGothicItalic");
                fonts.AddFont("Century-Gothic-Bold-Italic.otf", "CenturyGothicBoldItalic");
                fonts.AddFont("Century-Gothic-Bold.otf", "CenturyGothicBold");
                fonts.AddFont("Century-Gothic.otf", "CenturyGothic");
            });
        builder.AddMappers();
        builder.AddHttpClientConfig();
        builder.AddServices();
        FormHandler.RemoveBorders();

        builder.Services.AddLogging(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Information);
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        var app = builder.Build();
        ServiceHelper.Initialize(app.Services);
        return app;
    }
}