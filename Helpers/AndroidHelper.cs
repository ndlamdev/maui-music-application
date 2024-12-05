using Android.Widget;
using Application = Android.App.Application;

namespace maui_music_application.Helpers;

public class AndroidHelper
{
    public static void ShowToast(string message)
    {
        Toast.MakeText(Application.Context, message, Android.Widget.ToastLength.Short)!.Show();
    }
}