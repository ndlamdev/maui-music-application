// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 18:11:44 - 09/11/2024
// User: Lam Nguyen

using maui_music_application.Helpers;
using maui_music_application.ViewModels;

namespace maui_music_application.Views.Pages.User;

public partial class CreatePlaylistPage
{
    private readonly CreatePlayListViewModel _model;
    private bool _onClick;

    public CreatePlaylistPage()
    {
        InitializeComponent();
        _model = new CreatePlayListViewModel(this, true);
        BindingContext = _model;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
    }

    private async void OnBack(object? sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View?)sender, 100);
        await Navigation.PopAsync(true);
    }

    private void Picker_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
        if (MyPicker.SelectedIndex != -1)
            _model.IsPublic = MyPicker.Items[MyPicker.SelectedIndex] == "Public";
    }

    private async void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        if (_onClick) return;
        _onClick = true;
        await OpacityEffect.RunOpacity((View?)sender, 100);
        MyPicker.Unfocus();
        MyPicker.Focus();
        _onClick = false;
    }

    private async void Cancel_OnClicked(object? sender, EventArgs e)
    {
        if (_onClick) return;
        _onClick = true;
        await OpacityEffect.RunOpacity((View?)sender, 100);
        await Navigation.PopAsync(true);
        _onClick = false;
    }

    private void Create_OnClicked(object? sender, EventArgs e)
    {
        if (_onClick) return;
        _onClick = true;
        _model.OnSubmit(async () =>
        {
            await OpacityEffect.RunOpacity((View?)sender, 100);
            await Navigation.PopAsync(true);
        });
        _onClick = false;
    }
}