using System.ComponentModel;
using System.Runtime.CompilerServices;
using Android.Util;
using maui_music_application.Configuration;
using maui_music_application.Data;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Services.impl;
using Newtonsoft.Json;

namespace maui_music_application.ViewModels;

public class HeaderViewModel : INotifyPropertyChanged
{
    private readonly IUserService _userService;
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

    private User? _user =
        JsonConvert.DeserializeObject<User>
            (Preferences.Get(AppConstraint.User, string.Empty));

    public User? User
    {
        get => _user;
        set
        {
            if (_user != value)
            {
                _user = value;
                OnPropertyChanged();
            }
        }
    }


    public HeaderViewModel()
    {
        _userService = ServiceHelper.GetService<IUserService>();
        _ = LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            await _userService.CheckIfUserHasAccount();
            HasUser = true;
        }
        catch (Exception ex)
        {
            HasUser = false;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}