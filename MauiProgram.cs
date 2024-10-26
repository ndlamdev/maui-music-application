using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

namespace maui_music_application;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
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
        builder.Services.AddSingleton(AudioManager.Current);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}