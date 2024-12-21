// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 14:12:42 - 01/12/2024
// User: Lam Nguyen

using System.ComponentModel.DataAnnotations;
using maui_music_application.Attributes;
using maui_music_application.Helpers.Validation;
using maui_music_application.Models;
using maui_music_application.Views.Pages;

namespace maui_music_application.ViewModels;

public class VerifyCodeViewModel(
    Page page,
    Action<VerifyActionProps> callback,
    string? code,
    bool validateOnChanged = false)
    : AObservableValidator(validateOnChanged)
{
    private string _codeVerify = "0";


    [MinLength(6, ErrorMessage = "Vui lòng nhập mã xác thực")]
    public string CodeVerify
    {
        get => _codeVerify;
        set
        {
            SetProperty(ref _codeVerify, value, true);
            if (code != null)
                ValidateProperty(Code, nameof(Code));
        }
    }

    [Equals(nameof(CodeVerify), ErrorMessage = "Mã xác thực không hợp lệ!")]
    public string? Code => code;


    public void OnSubmit()
    {
        if (HasErrors)
            return;

        VerifySuccess();
    }

    private void VerifySuccess()
    {
        TodoAttribute.PrintTask<VerifyCodeViewModel>();
        callback.Invoke(new VerifyActionProps(page, CodeVerify));
    }
}