// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 14:09:40 - 23/09/2024
// User: Lam Nguyen

namespace maui_music_application.Utils;

public class OpacityEffect
{
    public static async Task RunOpacity(View view, uint duration)
    {
        await view.FadeTo(0.5, duration);
        await view.FadeTo(1, duration);
    }
}