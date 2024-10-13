using maui_music_application.Data;

namespace maui_music_application.Services;

public class UserService : IUserService
{
    private ISecureStorageService _secureStorageService = new SecureStorageService();

    public Task<bool> CheckIfUserHasAccount()
    {
        try
        {
            // Về sau sẽ thay thế bằng kiểm tra token
            // return await _secureStorageService.isKeyPresent(AppConstraint.User);
            return Task.FromResult(HeaderData.Logined);
        }
        catch (Exception)
        {
            return Task.FromResult(false);
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
