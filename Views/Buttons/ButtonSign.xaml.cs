// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 08:09:10 - 23/09/2024
// User: Lam Nguyen

namespace maui_music_application.Views.Buttons;

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
            action.Tapped += (sender, args) => value?.Invoke();
            Frame.GestureRecognizers.Add(action);
        }
    }

    private void Tapped(object? o, EventArgs e)
    {
        Clicked?.Invoke(this, e);
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