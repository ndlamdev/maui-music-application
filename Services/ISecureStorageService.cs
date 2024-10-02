namespace maui_music_application.Services;

public interface ISecureStorageService
{
    Task SaveAsync(string key, string value);
    Task<T> GetAsync<T>(string key);
    Task<bool> isKeyPresent(string key);
    void Remove(string key);
    void RemoveAll();
}