// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 08:09:43 - 22/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Model;
using maui_music_application.Utils;

namespace maui_music_application.Views.Buttons;

public partial class ButtonIconCircle : ContentView
{
    public event EventHandler? Clicked;

    public ButtonIconCircle()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public double SizeIcon
    {
        set
        {
            Image.WidthRequest = value;
            Image.HeightRequest = value;
        }
    }

    public double PaddingButton
    {
        set => FrameImage.Padding = value;
    }

    public string Title
    {
        set => Label.Text = value;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, e);
        await OpacityEffect.RunOpacity(this, 100);
    }

    public ImageSource Icon
    {
        set => Image.Source = value;
    }
}