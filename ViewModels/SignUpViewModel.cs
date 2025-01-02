// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 18:11:49 - 10/11/2024
// User: Lam Nguyen

using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Maui.Views;
using maui_music_application.Attributes;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Validation;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Components.Popup;
using maui_music_application.Views.Pages.User;

namespace maui_music_application.ViewModels;

public class SignUpViewModel(INavigation navigation, bool validateOnChanged = true)
    : AObservableValidator(validateOnChanged)
{
    private INavigation Navigation { get; set; } = navigation;
    private string _email = string.Empty;
    private string _password = string.Empty;
    private string _fullName = string.Empty;
    private string _confirmPassword = string.Empty;
    private string _phoneNumber = string.Empty;
    private DateTime _birthday;
    private bool _isInputConfirmPassword;

    [EmailAddress(ErrorMessage = "Vui lòng nhập email hợp lệ!")]
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value, true);
    }

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

    [NotBlank(ErrorMessage = "Vui lòng nhập mật khẩu!")]
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

    [NotBlank(ErrorMessage = "Vui lòng nhập họ và tên!")]
    public string FullName
    {
        get => _fullName;
        set => SetProperty(ref _fullName, value, validate: true);
    }

    [Phone(ErrorMessage = "Vui lòng nhập số điện thoại!")]
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => SetProperty(ref _phoneNumber, value, validate: true);
    }

    public DateTime Birthday
    {
        get => _birthday;
        set => SetProperty(ref _birthday, value, validate: true);
    }

    public bool Sex { get; set; }

    public void OnSubmit(Page page)
    {
        ValidateAllProperties();
        if (HasErrors)
            return;

        SignUp(page);
    }

    [Todo("Handle action button Sign up")]
    private void SignUp(Page page)
    {
        TodoAttribute.PrintTask<SignUpViewModel>();
        var userService = ServiceHelper.GetService<IUserService>();
        var popup = LoadingPopup.GetInstance();
        page.ShowPopup(popup);
        userService?.Register(new RequestRegister(Email, Password, FullName, PhoneNumber, Birthday, Sex))
            .ContinueWith(
                task =>
                {
                    if (task.IsFaulted)
                    {
                        ShowToastErrorHelper.ShowToast<SignUpViewModel>(task, popup, "Sign up failed: ");
                        return;
                    }

                    if (!task.IsCompleted) return;
                    popup.Close();
                    AndroidHelper.ShowToast(task.Result.Message);
                    Navigation.PushAsync(new VerifyCodePage(OnVerify));
                }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    [Todo("Handle OnVerify Sign up")]
    private void OnVerify(VerifyActionProps action)
    {
        var userService = ServiceHelper.GetService<IUserService>();
        var popup = LoadingPopup.GetInstance();
        action.Page.ShowPopup(popup);
        userService?.VerifyRegister(Email, new CodeVerify(action.Code)).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                ShowToastErrorHelper.ShowToast<SignUpViewModel>(task, popup, "Verify error: ");
                return;
            }

            if (!task.IsCompleted) return;
            OnVerifySuccess(popup);
            AndroidHelper.ShowToast(task.Result.Message);
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void OnVerifySuccess(Popup popup)
    {
        var navigationStack = Navigation.NavigationStack;
        var pagesToKeep = new HashSet<Type>
            { typeof(LoginPage) };
        for (var i = navigationStack.Count - 1; i >= 0; i--)
        {
            var page = navigationStack[i];
            if (page == null) continue;
            if (pagesToKeep.Contains(page.GetType())) continue;
            Navigation.RemovePage(page);
        }

        popup.Close();
    }

    public DateTime MinDate { get; } = new(1980, 01, 01);
}