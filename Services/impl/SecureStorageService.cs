using System.Text.Json;
using Android.Util;
using maui_music_application.Helpers;

namespace maui_music_application.Services.impl;

public class SecureStorageService : ISecureStorageService

{
    public async Task SaveAsync(string key, string value)
    {
        try
        {
            await SecureStorage.SetAsync(key, value);
            AndroidHelper.ShowToast("Data saved successfully");
        }
        catch (Exception ex)
        {
            // Handle any exceptions (e.g., secure storage not available)
            Log.Error($"Error saving to secure storage: {ex.Message}", ex.StackTrace ?? "");
        }
    }

    public async Task<string?> GetAsync(string key)
    {
        var result = await SecureStorage.GetAsync(key);

        if (string.IsNullOrEmpty(result))
        {
            return default;
        }

        return result;
    }

    public async Task<bool> isKeyPresent(string key)
    {
        var value = await SecureStorage.GetAsync(key);

        return value != null;
    }

    public void Remove(string key)
    {
        try
        {
            SecureStorage.Remove(key);
        }
        catch (Exception ex)
        {
            // Handle any exceptions (e.g., secure storage not available)
            Log.Error($"Error removing to secure storage: {ex.Message}", ex.StackTrace ?? "");
        }
    }

    public void RemoveAll()
    {
        try
        {
            SecureStorage.RemoveAll();
        }
        catch (Exception ex)
        {
            // Handle any exceptions (e.g., secure storage not available)
            Log.Error($"Error removing all to secure storage: {ex.Message}", ex.StackTrace ?? "");
        }
    }
}