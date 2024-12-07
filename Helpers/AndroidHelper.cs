using Android.Widget;
using Application = Android.App.Application;

namespace maui_music_application.Helpers;

public static class AndroidHelper
{
    public static void ShowToast(string message)
    {
        Toast.MakeText(Application.Context, message, ToastLength.Short)!.Show();
    }
}