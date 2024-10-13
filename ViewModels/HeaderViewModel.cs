using System.ComponentModel;
using System.Runtime.CompilerServices;
using Android.Util;
using maui_music_application.Data;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services;

namespace maui_music_application.ViewModels;

public class HeaderViewModel : INotifyPropertyChanged
{
    private readonly UserService _userService;

    private bool _hasUser;

    public bool HasUser
    {
        get => _hasUser;
        set
        {
            _hasUser = value;
            OnPropertyChanged(); // Notify the UI about the change
        }
    }

    // Data example
    private User _user =
        HeaderData.UserData;

    public User User
    {
        get => _user;
        set
        {
            if (_user != value)
            {
                _user = value;
                OnPropertyChanged(); // Notify the UI about the change
            }
        }
    }


    public HeaderViewModel()
    {
        _userService = new UserService();
        _ = LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            HasUser = await _userService.CheckIfUserHasAccount();
        }
        catch (Exception ex)
        {
            // Log the error for debugging purposes
            Log.Error($"Error checking user account status: {ex.Message}", ex.StackTrace ?? "");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
