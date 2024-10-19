// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 01:10:52 - 19/10/2024
// User: Lam Nguyen

using System.Globalization;
using Android.Util;
using Java.Net;

namespace maui_music_application.Helpers;

public static class FileHelper
{
    public static async Task<double> GetDurationFileM3U8(string url)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var duration = 0.0;
        await using var stream = await response.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(stream);
        while (await reader.ReadLineAsync() is { } line)
        {
            if (!line.StartsWith("#EXTINF:")) continue;
            var durationStr = line.Substring("#EXTINF:".Length, 8);
            duration += double.Parse(durationStr, CultureInfo.InvariantCulture);
        }

        reader.Close();
        stream.Close();
        return duration;
    }
}