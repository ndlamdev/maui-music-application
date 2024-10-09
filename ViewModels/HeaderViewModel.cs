using System.ComponentModel;
using Android.Util;
using maui_music_application.Data;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services;

namespace maui_music_application.ViewModels;

public class HeaderViewModel : INotifyPropertyChanged
{
    UserService _userService;
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private bool _hasUser;

    public bool HasUser
    {
        get => _hasUser;
        set
        {
            _hasUser = value;
            OnPropertyChanged(nameof(HasUser)); // Notify the UI about the change
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
                OnPropertyChanged(nameof(User)); // Notify the UI about the change
            }
        }
    }


    public HeaderViewModel()
    {
        _userService = new UserService();
        LoadDataAsync();
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
            Log.Error($"Error checking user account status: {ex.Message}", ex.StackTrace);
        }
    }
}