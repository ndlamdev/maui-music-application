using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Helpers;
using maui_music_application.ViewModels;

namespace maui_music_application.Views.Pages;

public partial class ResetPasswordPage
{
    private readonly ResetPasswordViewModel _viewModel;

    public ResetPasswordPage()
    {
        InitializeComponent();
        _viewModel = new ResetPasswordViewModel(Navigation);
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

    [Todo("Handle action click button log in")]
    private async void SignInTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<SignUpPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
        var navigationStack = Navigation.NavigationStack;
        var pagesToKeep = new HashSet<Type> { typeof(WelcomePage), typeof(LaunchPage), typeof(LoginPage) };
        for (var i = navigationStack.Count - 2; i >= 0; i--)
        {
            var page = navigationStack[i];
            if (page == null) continue;
            if (pagesToKeep.Contains(page.GetType())) continue;
            Navigation.RemovePage(page);
        }

        await Navigation.PopAsync();
    }

    [Todo("Handle action click button back")]
    private async void BackTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<SignUpPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PopAsync();
    }


    [Todo("Handle action click button reset password")]
    private void ResetPassword_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<ResetPasswordPage>();
        _viewModel.OnSubmit();
    }

    private void EntryPassword_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _viewModel.Password = e.NewTextValue;
    }

    private void EntryConfirmPassword_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _viewModel.ConfirmPassword = e.NewTextValue;
    }
}