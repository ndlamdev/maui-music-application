using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Helpers;
using maui_music_application.ViewModels;
using maui_music_application.Views.Components.Form;

namespace maui_music_application.Views.Pages;

using static System.Text.RegularExpressions.Regex;

public partial class VerifyCodePage
{
    private readonly List<Input> _list;
    private readonly VerifyCodeViewModel _viewModel;


    public VerifyCodePage(Action<string> callback, string code)
    {
        InitializeComponent();
        _list =
        [
            Code1,
            Code2,
            Code3,
            Code4,
            Code5,
            Code6
        ];
        _viewModel = new VerifyCodeViewModel(Navigation, callback, code, true);
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

    [Todo("Handle action click button resend code")]
    private async void ResendTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<VerifyCodePage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    [Todo("Handle action click button back")]
    private async void BackTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<VerifyCodePage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
        await Navigation.PopAsync();
    }


    [Todo("Handle action click button verify")]
    private void Verify_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<VerifyCodePage>();
        var code = string.Join("", _list.Select(input => input.EntryText).ToArray());
        _viewModel.CodeVerify = code;
        _viewModel.OnSubmit();
    }

    private void Code_OnTextChangeEvent(object sender, TextChangedEventArgs e)
    {
        var inputSender = (Input)sender;
        var index = _list.IndexOf(inputSender);
        var oldValue = e.OldTextValue ?? "";
        var newValue = e.NewTextValue ?? "";
        // paste or input in cell have value
        if (newValue.Length > oldValue.Length && newValue.Length > 1)
        {
            var length = Math.Min(newValue.Length, _list.Count - index);
            for (var indexC = 0; indexC < length; indexC++)
                _list[index++].EntryText = $"{newValue[indexC]}";

            return;
        }

        // input new value
        if (newValue.Length > oldValue.Length && newValue.Length == 1)
        {
            if (!IsMatch(newValue, "[0-9]"))
            {
                _list[index].EntryText = "";
                return;
            }

            for (; index < _list.Count; index++)
            {
                var input = _list[index];
                if (!string.IsNullOrEmpty(input.EntryText)) continue;
                input.Focus(true);
                return;
            }

            return;
        }

        for (; index >= 0; index--)
        {
            var input = _list[index];
            if (string.IsNullOrEmpty(input.EntryText)) continue;
            input.Focus(true);
            break;
        }
    }
}