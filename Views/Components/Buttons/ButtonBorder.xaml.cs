// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 12:09:21 - 22/09/2024
// User: Lam Nguyen

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Util;
using maui_music_application.Helpers;

namespace maui_music_application.Views.Components.Buttons;

public partial class ButtonBorder
{
    private string _text = "";
    public event EventHandler? Clicked;
    private Color _colorButton = Colors.White;
    private double _fontSize = 12;

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
            OnPropertyChanged(nameof(Text));
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
            OnPropertyChanged(nameof(ColorButton));
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

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        Clicked?.Invoke(this, e);
    }
}