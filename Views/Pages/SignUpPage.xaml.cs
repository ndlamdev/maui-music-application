using System.ComponentModel.Design;
using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Helpers;
using maui_music_application.Services;
using maui_music_application.ViewModels;

namespace maui_music_application.Views.Pages;

public partial class SignUpPage
{
    private readonly SignUpViewModel _viewModel;

    public SignUpPage()
    {
        InitializeComponent();
        _viewModel = new SignUpViewModel(Navigation);
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


    [Todo("Handle action click button sign up")]
    private void SignUp_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<SignUpPage>();
        _viewModel.OnSubmit(this);
    }

    private void EntryEmail_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _viewModel.Email = e.NewTextValue;
    }

    private void EntryPassword_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _viewModel.Password = e.NewTextValue;
    }

    private void EntryConfirmPassword_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _viewModel.ConfirmPassword = e.NewTextValue;
    }

    private void EntryFullName_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _viewModel.FullName = e.NewTextValue;
    }

    private void EntryPhoneNumber_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _viewModel.PhoneNumber = e.NewTextValue;
    }

    private void SexPicker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
            _viewModel.Sex = picker.Items[selectedIndex] == "Male";
    }
}