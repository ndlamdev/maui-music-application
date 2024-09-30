// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 11:09:43 - 23/09/2024
// User: Lam Nguyen

namespace maui_music_application.Helpers;

public class ScreenHelper
{
    private static readonly DisplayInfo MainDisplayInfo = DeviceDisplay.MainDisplayInfo;
    private static readonly double Density = MainDisplayInfo.Density;

    public static double GetScreenWidthInDips()
    {
        var widthInPixels = MainDisplayInfo.Width;
        var widthInDips = widthInPixels / Density;
        return widthInDips;
    }

    public static double GetScreenHeightInDips()
    {
        var heightInPixels = MainDisplayInfo.Height;
        var heightInDips = heightInPixels / Density;
        return heightInDips;
    }
}