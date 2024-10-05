using maui_music_application.Data;
using maui_music_application.Helpers;
using maui_music_application.Models;

namespace maui_music_application.Services;

public class UserService : IUserService
{
    private ISecureStorageService _secureStorageService;

    public UserService()
    {
        _secureStorageService = new SecureStorageService();
    }

    public async Task<bool> CheckIfUserHasAccount()
    {
        try
        {
            // Về sau sẽ thay thế bằng kiểm tra token
            // return await _secureStorageService.isKeyPresent(AppConstraint.User);
            return HeaderData.Logined;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public Task<bool> Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Register(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Logout()
    {
        throw new NotImplementedException();
    }
}