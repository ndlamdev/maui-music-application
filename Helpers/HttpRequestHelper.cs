namespace maui_music_application.Helpers;

public static class HttpRequestHelper
{
    public static void AddCookie(this HttpRequestMessage request, string cookieName, string? cookieValue)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (string.IsNullOrWhiteSpace(cookieName))
            throw new ArgumentException("Cookie name cannot be null or whitespace.", nameof(cookieName));
        if (cookieValue == null) throw new ArgumentNullException(nameof(cookieValue));

        var cookieHeader = $"{cookieName}={cookieValue}";

        // Check if the Cookie header already exists
        if (request.Headers.Contains("Cookie"))
        {
            var existingCookies = string.Join("; ", request.Headers.GetValues("Cookie"));
            request.Headers.Remove("Cookie");
            request.Headers.Add("Cookie", $"{existingCookies}; {cookieHeader}");
        }
        else
        {
            request.Headers.Add("Cookie", cookieHeader);
        }
    }

    public static void RemoveCookie(this HttpRequestMessage request, string cookieName)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (string.IsNullOrWhiteSpace(cookieName))
            throw new ArgumentException("Cookie name cannot be null or whitespace.", nameof(cookieName));

        // Check if the request contains the "Cookie" header
        if (!request.Headers.Contains("Cookie")) return;

        // Retrieve existing cookies
        var existingCookies = request.Headers.GetValues("Cookie").FirstOrDefault();
        if (string.IsNullOrEmpty(existingCookies)) return;

        // Split cookies into key-value pairs
        var cookies = existingCookies.Split(';')
            .Select(cookie => cookie.Trim())
            .Where(cookie => !cookie.StartsWith($"{cookieName}=")) // Filter out the cookie to be removed
            .ToArray();

        // Update the "Cookie" header
        request.Headers.Remove("Cookie");
        if (cookies.Any())
        {
            request.Headers.Add("Cookie", string.Join("; ", cookies));
        }
    }
}