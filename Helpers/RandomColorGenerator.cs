// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:00 - 22/09/2024
// User: Lam Nguyen

using Java.Security;

namespace maui_music_application.Helpers;

public static class RandomColorGenerator
{
    private static readonly SecureRandom Random = new SecureRandom();

    public static Color GetRandomColor()
    {
        return Color.FromRgb(Random.NextInt(256), Random.NextInt(256), Random.NextInt(256));
    }
}