using Android.Util;
using maui_music_application.Services.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace maui_music_application.Configuration;

public static class HttpConfiguration
{
    public static void AddHttpClientConfig(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<AuthHandlingDelegatingHandler>();
        builder.Services.AddRefitClient<IAuthApi>();
        builder.Services.AddRefitClient<IPlaylistApi>();
        builder.Services.AddRefitClient<ISongApi>();
        builder.Services.AddRefitClient<IRankPlayApi>();
        builder.Services.AddRefitClient<IAlbumApi>();
        builder.Services.AddRefitClient<IHomeApi>();
        builder.Services.AddRefitClient<IServerApi>();
        builder.Services.AddRefitClient<IGenreApi>();
    }

    private static void AddRefitClient<TInterface>(
        this IServiceCollection services)
        where TInterface : class
    {
        var refitSettings = new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                }
            )
        };

        services.AddRefitClient<TInterface>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(AppConstraint.BaseUrl))
            .AddHttpMessageHandler<AuthHandlingDelegatingHandler>();
    }
}