// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 18:11:49 - 10/11/2024
// User: Lam Nguyen

using System.ComponentModel.DataAnnotations;
using Android.Util;
using CommunityToolkit.Maui.Views;
using maui_music_application.Attributes;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Validation;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Services.Api;
using maui_music_application.Views.Components.Popup;
using maui_music_application.Views.Pages;

namespace maui_music_application.ViewModels;

public class LoginWithPasswordViewModel(INavigation navigation, bool validateOnChanged = true)
    : AObservableValidator(validateOnChanged)
{
    private IUserService? _userService = ServiceHelper.GetService<IUserService>();

    // Log.Info("ViewModel", "UserService: {}", userService);

    private INavigation Navigation { get; set; } = navigation;
    private string _email = string.Empty;
    private string _password = string.Empty;

    [EmailAddress(ErrorMessage = "Vui lòng nhập email hợp lệ!")]
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value, true);
    }

    [NotBlank(ErrorMessage = "Vui lòng nhập lại mật khẩu!")]
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value, true);
    }

    public bool RememberMe { get; set; }

    public void OnSubmit(Page page)
    {
        ValidateAllProperties();
        OnErrorChanged(nameof(Email));
        OnErrorChanged(nameof(Password));
        if (HasErrors)
            return;

        Login(page);
    }

    [Todo("Handle Login")]
    private async void Login(Page page)
    {
        TodoAttribute.PrintTask<LoginWithPasswordViewModel>();
        var popup = LoadingPopup.GetInstance();
        try
        {
            if (_userService == null) throw new NullReferenceException(nameof(_userService));
            page.ShowPopup(popup);
            await _userService.Login(Email, Password);
            popup.Close();
            AndroidHelper.ShowToast("Login success");
            await Navigation.PushAsync(new MainPage());
        }
        catch (Exception e)
        {
            popup.Close();
            AndroidHelper.ShowToast(e.Message);
        }
    }
}