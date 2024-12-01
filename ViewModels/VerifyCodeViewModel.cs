// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 14:12:42 - 01/12/2024
// User: Lam Nguyen

using System.ComponentModel.DataAnnotations;
using maui_music_application.Attributes;
using maui_music_application.Helpers.Validation;
using maui_music_application.Models;

namespace maui_music_application.ViewModels;

public class VerifyCodeViewModel(INavigation navigation, Action<string> callback, string code, bool validateOnChanged = false)
    : AObservableValidator(validateOnChanged)
{
    private INavigation Navigation { get; set; } = navigation;
    private string _codeVerify = "0";

    public string Code { get; set; } = code;

    [MinLength(6, ErrorMessage = "Vui lòng nhập mã xác thực")]
    [Equals(nameof(Code), ErrorMessage = "Mã xác thực không chính xác!")]
    public string CodeVerify
    {
        get => _codeVerify;
        set => SetProperty(ref _codeVerify, value, true);
    }


    public void OnSubmit()
    {
        if (HasErrors)
            return;

        VerifySuccess();
    }

    private void VerifySuccess()
    {
        TodoAttribute.PrintTask<VerifyCodeViewModel>();
        callback.Invoke(CodeVerify);
    }
}