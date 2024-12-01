using System.Text.Json;
using Android.Util;

namespace maui_music_application.Services.impl;

public class SecureStorageService : ISecureStorageService

{
    public async Task SaveAsync(string key, string value)
    {
        try
        {
            await SecureStorage.SetAsync(key, value);
        }
        catch (Exception ex)
        {
            // Handle any exceptions (e.g., secure storage not available)
            Log.Error($"Error saving to secure storage: {ex.Message}", ex.StackTrace ?? "");
        }
    }

    public async Task<T> GetAsync<T>(string key)
    {
        try
        {
            // Retrieve the string from SecureStorage asynchronously
            var result = await SecureStorage.GetAsync(key);

            // Check if the result is null or empty, indicating the key doesn't exist
            if (string.IsNullOrEmpty(result))
            {
                throw new KeyNotFoundException($"The key '{key}' was not found in secure storage.");
            }

            // Attempt to deserialize the string to the specified type T
            return JsonSerializer.Deserialize<T>(result) ?? throw new Exception("Failed to deserialize data");
        }
        catch (Exception ex)
        {
            // Log the error for debugging purposes
            Log.Error($"Error retrieving data from secure storage: {ex.Message}", ex.StackTrace ?? "");

            // Rethrow the exception to propagate the error
            throw new Exception($"Failed to retrieve data for key '{key}'", ex);
        }
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
