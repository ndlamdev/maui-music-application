using maui_music_application.Attributes;
using maui_music_application.Helpers;
using maui_music_application.ViewModels;

namespace maui_music_application.Views.Pages.User;

public partial class ForgetPasswordPage
{
    private readonly ForgetPasswordViewModel _viewModel;

    public ForgetPasswordPage()
    {
        InitializeComponent();
        _viewModel = new ForgetPasswordViewModel(Navigation);
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

    [Todo("Handle action click button back")]
    private async void BackTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<ForgetPasswordPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PopAsync();
    }


    [Todo("Handle action click button find account")]
    private void FindAccount_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<ForgetPasswordPage>();
        _viewModel.OnSubmit();
    }


    [Todo("Handle action click button sign up")]
    private async void SignUpTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<ForgetPasswordPage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PushAsync(new SignUpPage());
    }

    private void EntryEmail_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _viewModel.Email = e.NewTextValue;
    }
}