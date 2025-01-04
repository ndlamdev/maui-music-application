using Android.Util;
using Microsoft.Extensions.Logging;

namespace maui_music_application.Configuration;

public class LoggingHandler : DelegatingHandler
{


    public LoggingHandler(HttpMessageHandler innerHandler)
        : base(innerHandler)
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Log the request URL
        Log.Info("Refit", $"Request: {request.Method} {request.RequestUri}");

        // Log the request headers
        foreach (var header in request.Headers)
        {
            Log.Info("Refit", $"{header.Key}: {string.Join(", ", header.Value)}");
        }

        // Log the request body (for multipart, we can't directly print the content, but you can print headers or inspect it)
        if (request.Content != null)
        {
            var content = await request.Content.ReadAsStringAsync();
            Log.Info("Refit",
                $"Request Body: {content}"); // Print a truncated body (first 500 characters)
        }

        return await base.SendAsync(request, cancellationToken);
    }
}