// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 17:09:27 - 28/09/2024
// User: Lam Nguyen

using maui_music_application.Helpers;

namespace maui_music_application.Components.Buttons;

public partial class ButtonIcon
{
    public event EventHandler? Clicked;

    public ButtonIcon()
    {
        InitializeComponent();
    }

    public double SizeIcon
    {
        set
        {
            Image.WidthRequest = value;
            Image.HeightRequest = value;
        }
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