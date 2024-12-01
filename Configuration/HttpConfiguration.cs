using System.Net.Http.Headers;
using System.Text.Json;
using maui_music_application.Services.Api;
using Refit;

namespace maui_music_application.Configuration;

public static class HttpConfiguration
{
    public static void AddHttpClientConfig(this MauiAppBuilder builder)
    {
        builder.Services.AddRefitClient<IAuthApi>(
            baseUrl: AppConstraint.BaseUrl);
    }

    private static IServiceCollection AddRefitClient<TInterface>(
        this IServiceCollection services,
        string baseUrl,
        string? bearerToken = null)
        where TInterface : class
    {
        if (string.IsNullOrWhiteSpace(baseUrl))
            throw new ArgumentException("Base URL must not be null or empty", nameof(baseUrl));

        // Config json
        var refitSettings = new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                })
        };


        services.AddRefitClient<TInterface>(refitSettings)
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(baseUrl);

                if (!string.IsNullOrEmpty(bearerToken))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", bearerToken);
                }
            }).AddHttpMessageHandler<AuthHttpClientHandler>();

        return services;
    }
}

public class AuthHttpClientHandler : DelegatingHandler
{
    private readonly IAuthApi _authApi;
    private readonly List<string> _excludedPaths;

    public AuthHttpClientHandler(IAuthApi authApi)
    {
        _authApi = authApi;
        _excludedPaths =
        [
            "/auth/login",
            "/auth/register",
            "/auth/refresh-token"
        ];
        InnerHandler = new HttpClientHandler();
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Check if the request URL matches any excluded paths
        if (!IsExcludedPath(request.RequestUri))
        {
            var accessToken = await GetAccessTokenAsync();

            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }

    private async Task<string> GetAccessTokenAsync()
    {
        // Logic to get the access token (same as before)
        var accessToken = "your-access-token"; // Replace with your actual logic

        // if (string.IsNullOrEmpty(accessToken) || IsTokenExpired(accessToken))
        // {
        //     var refreshToken = "your-refresh-token"; // Replace with actual refresh token logic
        //     var response = await _authApi.RefreshToken(new RefreshRequest { RefreshToken = refreshToken });
        //
        //     accessToken = response.AccessToken;
        //
        //     SaveAccessToken(accessToken);
        // }

        return accessToken;
    }

    private bool IsExcludedPath(Uri? requestUri)
    {
        if (requestUri == null)
            return false;

        // Check if the path matches any excluded paths
        return _excludedPaths.Any(excludedPath =>
            requestUri.AbsolutePath.StartsWith(excludedPath, StringComparison.OrdinalIgnoreCase));
    }

    private bool IsTokenExpired(string token)
    {
        // Logic to check if the token is expired
        return false; // Replace with your actual token expiration logic
    }

    private void SaveAccessToken(string accessToken)
    {
        // Logic to save the access token securely
    }
}