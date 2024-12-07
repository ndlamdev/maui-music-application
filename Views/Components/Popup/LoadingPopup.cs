namespace maui_music_application.Views.Components.Popup;

using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;

public sealed class LoadingPopup : Popup
{
    private LoadingPopup()
    {
        Content = new Grid
        {
            BackgroundColor = Color.FromRgba(0, 0, 0, 0.7),
            Children =
            {
                new ActivityIndicator
                {
                    IsRunning = true,
                    Color = Colors.White,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    BackgroundColor = Color.FromRgba(0, 0, 0, 0.0),
                }
            }
        };

        CanBeDismissedByTappingOutsideOfPopup = false;
    }

    public static LoadingPopup GetInstance()
    {
        return new LoadingPopup();
    }
}