// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:00 - 22/09/2024
// User: Lam Nguyen

using Java.Security;

namespace maui_music_application.Utils;

public class RandomColorGenerator
{
    private static readonly SecureRandom _random = new SecureRandom();

    public static Color GetRandomColor()
    {
        return Color.FromRgb(_random.NextInt(256), _random.NextInt(256), _random.NextInt(256));
    }
}