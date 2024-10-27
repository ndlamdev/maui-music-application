using System.Collections;
using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Helpers;
using maui_music_application.Views.Components.Form;

namespace maui_music_application.Views.Pages;

public partial class VerifyCodePage
{
    private readonly List<Input> _list;

    public VerifyCodePage()
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
    }

    [Todo("Handle action click button resend code")]
    private async void ResendTapped(object sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<VerifyCodePage>();
        await OpacityEffect.RunOpacity((View)sender, 100);
    }

    [Todo("Handle action click button back")]
    private void BackTapped(object? sender, TappedEventArgs e)
    {
        TodoAttribute.PrintTask<VerifyCodePage>();
    }


    [Todo("Handle action click button verify")]
    private void Verify_OnClicked(object? sender, EventArgs e)
    {
        TodoAttribute.PrintTask<VerifyCodePage>();
        var code = string.Join("", _list.Select(input => input.Text).ToArray());
    }

    private void Code_OnTextChangeEvent(object sender, TextChangedEventArgs e)
    {
        var inputSender = (Input)sender;
        var index = _list.IndexOf(inputSender);
        var oldValue = e.OldTextValue ?? "";
        var newValue = e.NewTextValue ?? "";
        if (newValue.Length > oldValue.Length)
        {
            for (; index < _list.Count; index++)
            {
                var input = _list[index];
                if (input.Text.Length != 0) continue;
                input.Focus(true);
                return;
            }

            inputSender.Text = inputSender.Text[..1];
            return;
        }

        for (; index >= 0; index--)
        {
            var input = _list[index];
            if (input.Text.Length == 0) continue;
            input.Focus(true);
            break;
        }
    }
}
