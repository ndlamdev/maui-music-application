// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 14:09:12 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Views.Components.Buttons;

public partial class ButtonBorderShadow
{
    private string _text = "";
    public event EventHandler? Clicked;
    private double _fontSize = 12;
    private Thickness _paddingButton = new(14, 18);
    private Color _textColor = Colors.White;

    public ButtonBorderShadow()
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
            OnPropertyChanged();
        }
    }

    public double FontSize
    {
        get => _fontSize;
        set
        {
            _fontSize = value;
            OnPropertyChanged();
        }
    }

    public Thickness PaddingButton
    {
        get => _paddingButton;
        set
        {
            _paddingButton = value;
            OnPropertyChanged();
        }
    }

    public Color TextColor
    {
        get => _textColor;

        set
        {
            _textColor = value;
            OnPropertyChanged();
        }
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        Clicked?.Invoke(this, e);
    }
}