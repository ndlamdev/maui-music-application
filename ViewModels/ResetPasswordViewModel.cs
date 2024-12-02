// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 18:11:49 - 10/11/2024
// User: Lam Nguyen

using System.ComponentModel.DataAnnotations;
using maui_music_application.Attributes;
using maui_music_application.Helpers.Validation;
using maui_music_application.Models;
using maui_music_application.Views.Pages;

namespace maui_music_application.ViewModels;

public class ResetPasswordViewModel(INavigation navigation, bool validateOnChanged = true)
    : AObservableValidator(validateOnChanged)
{
    private INavigation Navigation { get; set; } = navigation;
    private string _password = string.Empty;
    private string _confirmPassword = string.Empty;
    private bool _isInputConfirmPassword;


    [NotBlank(ErrorMessage = "Vui lòng nhập mật khẩu!")]
    [MinLength(8, ErrorMessage = "Mật khẩu ít nhất 8 ký tự!")]
    [HasNumber(ErrorMessage = "Mật khẩu phải bao gồm ít nhất 1 ký tự số!")]
    [HasLowerCharacter(ErrorMessage = "Mật khẩu phải bao gồm ít nhất 1 ký tự chữ thường!")]
    [HasUpperCharacter(ErrorMessage = "Mật khẩu phải bao gồm ít nhất 1 ký tự chữ hoa!")]
    [HasSpecialCharacter(ErrorMessage = "Mật khẩu phải bao gồm ít nhất 1 ký tự đặt biệt!")]
    public string Password
    {
        get => _password;
        set
        {
            SetProperty(ref _password, value, true);
            if (_isInputConfirmPassword)
                ValidateProperty(ConfirmPassword, nameof(ConfirmPassword));
        }
    }

    [NotBlank(ErrorMessage = "Vui lòng nhập lại mật khẩu!")]
    [Equals(nameof(Password), ErrorMessage = "Mật khẩu không khớp!")]
    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            _isInputConfirmPassword = true;
            SetProperty(ref _confirmPassword, value, validate: true);
        }
    }

    public void OnSubmit()
    {
        ValidateAllProperties();
        OnErrorChanged(nameof(Password));
        OnErrorChanged(nameof(ConfirmPassword));
        if (HasErrors)
            return;

        SignUp();
    }

    [Todo("Handle action button Sign up")]
    private void SignUp()
    {
        TodoAttribute.PrintTask<ResetPasswordViewModel>();

        //if success => OnVerifySuccess();
    }

    private async void OnVerifySuccess()
    {
        var navigationStack = Navigation.NavigationStack;
        var pagesToKeep = new HashSet<Type>
            { typeof(WelcomePage), typeof(LaunchPage), typeof(LoginPage), typeof(LoginWithPasswordPage) };
        for (var i = navigationStack.Count - 2; i >= 0; i--)
        {
            var page = navigationStack[i];
            if (page == null) continue;
            if (pagesToKeep.Contains(page.GetType())) continue;
            Navigation.RemovePage(page);
        }

        await Navigation.PopAsync();
    }
}