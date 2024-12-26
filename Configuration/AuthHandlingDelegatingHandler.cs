using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Android.Util;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Services;

namespace maui_music_application.Configuration;

public class AuthHandlingDelegatingHandler : DelegatingHandler
{
    private readonly List<string> _excludedPaths;

    public AuthHandlingDelegatingHandler()
    {
        _excludedPaths =
        [
            "/api/v1/auth/login",
            "/api/v1/auth/register",
            "/api/v1/auth/refresh-token",
            "/api/v1/status"
        ];
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var tokenService = ServiceHelper.GetService<ITokenService>();
        if (tokenService == null)
            throw new NullReferenceException(nameof(tokenService));

        Log.Info("Call api", $"Call to -> {request.RequestUri?.AbsoluteUri}");
        // Check if the path is excluded from authentication
        if (!IsExcludedPath(request.RequestUri))
        {
            var accessToken = await tokenService.GetAccessToken();

            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }

        var response = await base.SendAsync(request, cancellationToken);

        // If the response is 401 Unauthorized => the token is expired
        if (response.StatusCode != HttpStatusCode.Unauthorized) return response;
        {
            await GetNewAccessTokenAsync();
            var accessToken = await tokenService.GetAccessToken();
            if (string.IsNullOrEmpty(accessToken)) return response;
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            response = await base.SendAsync(request, cancellationToken);
        }

        return response;
    }

    private async Task GetNewAccessTokenAsync()
    {
        var tokenService = ServiceHelper.GetService<ITokenService>();
        if (tokenService == null)
            throw new NullReferenceException(nameof(tokenService));
        var request = new HttpRequestMessage(HttpMethod.Post, AppConstraint.BaseUrl + "/auth/refresh-token");
        string? refreshToken = await tokenService.GetRefreshToken();
        request.Headers.Add("Accept", "application/json");
        request.AddCookie("refresh-token", refreshToken);

        using var httpClient = new HttpClient();
        var response = await httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return;
        }

        var responseJson = await response.Content.ReadAsStringAsync();

        var tokenResponse = JsonSerializer.Deserialize<APIResponse<ResponseAuthentication>>(responseJson);

        await tokenService.SaveAccessToken(tokenResponse?.Data.AccessToken ?? "");
    }

    private bool IsExcludedPath(Uri? requestUri)

    {
        if (requestUri == null)
            return false;

        // Check if the path matches any excluded paths
        return _excludedPaths.Any(excludedPath =>
            requestUri.AbsolutePath.StartsWith(excludedPath, StringComparison.OrdinalIgnoreCase));
    }
}