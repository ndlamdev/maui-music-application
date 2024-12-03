// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 14:12:50 - 01/12/2024
// User: Lam Nguyen

using System.ComponentModel.DataAnnotations;
using maui_music_application.Attributes;
using maui_music_application.Models;
using maui_music_application.Views.Pages;
using Microsoft.Maui.Controls;

namespace maui_music_application.ViewModels;

public class ForgetPasswordViewModel(INavigation navigation, bool validateOnChanged = true)
    : AObservableValidator(validateOnChanged)
{
    private INavigation Navigation { get; set; } = navigation;
    private string _email = string.Empty;


    [EmailAddress(ErrorMessage = "Vui lòng nhập email hợp lệ!")]
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value, true);
    }


    public void OnSubmit()
    {
        // ValidateAllProperties();
        // OnErrorChanged(nameof(Email));
        // if (HasErrors)
        //     return;

        FindAccount();
    }

    [Todo("Handle FindAccount")]
    private void FindAccount()
    {
        TodoAttribute.PrintTask<ForgetPasswordViewModel>();
    
        //if success => Navigation.PushAsync(new VerifyCodePage(code));
    }

    [Todo("Handle OnVerify ForgetPassword")]
    private void OnVerify(string code)
    {
        TodoAttribute.PrintTask<ForgetPasswordViewModel>();
        //if success =>  Navigation.PushAsync(new ResetPasswordPage());
    }
}