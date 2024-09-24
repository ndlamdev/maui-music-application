// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 13:09:27 - 24/09/2024
// User: Lam Nguyen

namespace maui_music_application.Utils;

public class AnimationTranslate
{
    public static async void OnPageAppearing(ContentPage page, object? sender, EventArgs e)
    {
        await page.TranslateTo(1000, 0, 0);
        await page.TranslateTo(0, 0, 200);
    }
}