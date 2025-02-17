// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 18:11:49 - 10/11/2024
// User: Lam Nguyen

using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Maui.Views;
using maui_music_application.Attributes;
using maui_music_application.Configuration;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Enum;
using maui_music_application.Helpers.Validation;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Components.Popup;
using maui_music_application.Views.Pages.Admin;
using maui_music_application.Views.Pages.User;
using Newtonsoft.Json;

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
            var user = JsonConvert.DeserializeObject<User>(Preferences.Get(AppConstraint.User, string.Empty));
            if (user?.Role != Role.ADMIN)
                await Navigation.PushAsync(new MainPage());
            else
                await Navigation.PushAsync(new SongManagerPage());
        }
        catch (Exception e)
        {
            popup.Close();
            AndroidHelper.ShowToast(e.Message);
        }
    }
}