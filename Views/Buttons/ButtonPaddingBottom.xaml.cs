// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 13:09:40 - 22/09/2024
// User: Lam Nguyen

using System.ComponentModel;

namespace maui_music_application.Views.Buttons;

public partial class ButtonPaddingBottom
{
    private string _text = "";
    public event EventHandler? Clicked;
    private double _fontSize = 12;
    private Color _textColor = Colors.White;

    public ButtonPaddingBottom()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChanged(nameof(Text));
        }
    }

    public double FontSize
    {
        get => _fontSize;
        set
        {
            _fontSize = value;
            OnPropertyChanged(nameof(FontSize));
        }
    }

    public double PaddingBottom
    {
        set => Button.Padding = Button.Padding with { Bottom = value };
    }

    public Color TextColor
    {
        get => _textColor;
        set
        {
            this._textColor = value;
            OnPropertyChanged(nameof(TextColor));
        }
    }


    private void Button_OnClicked(object? sender, EventArgs e)
    {
        Clicked?.Invoke(this, e);
    }
}