// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 08:09:10 - 23/09/2024
// User: Lam Nguyen

using maui_music_application.Helpers;

namespace maui_music_application.Views.Components.Buttons;

public partial class ButtonSign
{
    public event EventHandler? Clicked;

    public ButtonSign()
    {
        InitializeComponent();
    }

    public Action Action
    {
        set
        {
            var action = new TapGestureRecognizer();
            action.Tapped += async (sender, args) =>
            {
                value?.Invoke();
                await OpacityEffect.RunOpacity(this, 100);
            };
            Frame.GestureRecognizers.Add(action);
        }
    }

    private async void Tapped(object? o, EventArgs e)
    {
        Clicked?.Invoke(this, e);
        await OpacityEffect.RunOpacity(this, 100);
    }

    public ImageSource Icon
    {
        set => Image.Source = value;
    }

    public string Title
    {
        set => Label.Text = value;
    }
}