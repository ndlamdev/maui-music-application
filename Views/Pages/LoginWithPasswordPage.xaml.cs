using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Helpers;
using maui_music_application.Services;
using maui_music_application.ViewModels;
using maui_music_application.Views.Components.Form;

namespace maui_music_application.Views.Pages;

public partial class LoginWithPasswordPage
{
    private readonly LoginWithPasswordViewModel _viewModel;

    public LoginWithPasswordPage()
    {
        InitializeComponent();

        _viewModel = new LoginWithPasswordViewModel(Navigation);
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
    }

    [Todo("Handle action click button Sign up")]
    private async void SignUpTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<LoginWithPasswordPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PushAsync(new SignUpPage());
    }

    [Todo("Handle action click button back")]
    private async void BackTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<LoginWithPasswordPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PopAsync();
    }


    [Todo("Handle action click button login with password")]
    private void LoginWithPassword_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<LoginWithPasswordPage>();
        _viewModel.OnSubmit();
    }

    [Todo("Handle action click button forget password")]
    private async void ForgetPassword_OnTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<LoginWithPasswordPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PushAsync(new ForgetPasswordPage());
    }

    private void RememberMe_OnTapped(object? sender, TappedEventArgs e)
    {
        CheckBoxRememberMe.IsChecked = !CheckBoxRememberMe.IsChecked;
    }

    private void EntryEmail_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _viewModel.Email = e.NewTextValue;
    }


    private void EntryPassword_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _viewModel.Password = e.NewTextValue;
    }

    private void CheckBoxRememberMe_OnCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        _viewModel.RememberMe = e.Value;
    }
}