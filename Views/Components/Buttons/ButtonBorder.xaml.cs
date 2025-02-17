// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 12:09:21 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Views.Components.Buttons;

public partial class ButtonBorder
{
    private string _text = "";
    public event EventHandler? Clicked;
    private Color _colorButton = Colors.White;
    private double _fontSize = 12;
    private bool _selected;

    public ButtonBorder()
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

    public Thickness PaddingButton
    {
        set => Button.Padding = value;
    }

    public Color ColorButton
    {
        get => _colorButton;
        set
        {
            _colorButton = value;
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

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        Clicked?.Invoke(this, e);
    }

    public bool Selected
    {
        get => _selected;
        set
        {
            _selected = value;
            OnPropertyChanged();
        }
    }
}