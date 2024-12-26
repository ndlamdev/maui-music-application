// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 08:12:29 - 21/12/2024
// User: Lam Nguyen

using Android.Util;
using CommunityToolkit.Maui.Views;
using maui_music_application.Dto;
using Newtonsoft.Json;

namespace maui_music_application.Helpers;

public class ShowToastErrorHelper
{
    public static void ShowToast<T>(Task<APIResponse> task, Popup popup, string subject)
    {
        var exception = task.Exception.GetBaseException();
        Log.Error(nameof(T), $"{subject}: " + exception);

        if (exception is Refit.ApiException apiException)
        {
            var responseContent = apiException.Content;

            try
            {
                popup.Close();
                var errorResponse = JsonConvert.DeserializeObject<APIResponse>(responseContent);
                AndroidHelper.ShowToast($"{subject}: {errorResponse?.Message ?? "Unknown error"}");
            }
            catch
            {
                popup.Close();
                AndroidHelper.ShowToast($"{subject}: Invalid error response.");
            }
        }
        else
        {
            popup.Close();
            AndroidHelper.ShowToast($"{subject}: {exception.Message}");
        }
    }

    public static void ShowToast<T, R>(Task<APIResponse<R>> task, Popup popup, string subject)
    {
        var exception = task.Exception.GetBaseException();
        Log.Error(nameof(T), $"{subject}: " + exception);

        if (exception is Refit.ApiException apiException)
        {
            var responseContent = apiException.Content;

            try
            {
                popup.Close();
                var errorResponse = JsonConvert.DeserializeObject<APIResponse>(responseContent);
                AndroidHelper.ShowToast($"{subject}: {errorResponse?.Message ?? "Unknown error"}");
            }
            catch
            {
                popup.Close();
                AndroidHelper.ShowToast($"{subject}: Invalid error response.");
            }
        }
        else
        {
            popup.Close();
            AndroidHelper.ShowToast($"{subject}: {exception.Message}");
        }
    }


    public static void ShowToast<T>(Task<APIResponse> task, string subject)
    {
        var exception = task.Exception.GetBaseException();
        Log.Error(nameof(T), $"{subject}: " + exception);

        if (exception is Refit.ApiException apiException)
        {
            var responseContent = apiException.Content;

            try
            {
                var errorResponse = JsonConvert.DeserializeObject<APIResponse>(responseContent);
                AndroidHelper.ShowToast($"{subject}: {errorResponse?.Message ?? "Unknown error"}");
            }
            catch
            {
                AndroidHelper.ShowToast($"{subject}: Invalid error response.");
            }
        }
        else
        {
            AndroidHelper.ShowToast($"{subject}: {exception.Message}");
        }
    }

    public static void ShowToast<T, R>(Task<APIResponse<R>> task, string subject)
    {
        var exception = task.Exception.GetBaseException();
        Log.Error(nameof(T), $"{subject}: " + exception);

        if (exception is Refit.ApiException apiException)
        {
            var responseContent = apiException.Content;

            try
            {
                var errorResponse = JsonConvert.DeserializeObject<APIResponse>(responseContent);
                AndroidHelper.ShowToast($"{subject}: {errorResponse?.Message ?? "Unknown error"}");
            }
            catch
            {
                AndroidHelper.ShowToast($"{subject}: Invalid error response.");
            }
        }
        else
        {
            AndroidHelper.ShowToast($"{subject}: {exception.Message}");
        }
    }
}