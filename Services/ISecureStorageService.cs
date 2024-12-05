namespace maui_music_application.Services;

public interface ISecureStorageService
{
    Task SaveAsync(string key, string value);
    Task<string?> GetAsync(string key);
    Task<bool> isKeyPresent(string key);
    void Remove(string key);
    void RemoveAll();
}