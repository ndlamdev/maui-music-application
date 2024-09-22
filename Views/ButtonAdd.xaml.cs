// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 08:09:43 - 22/09/2024
// User: Lam Nguyen

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_music_application.Views;

public partial class ButtonAdd : ContentView, INotifyPropertyChanged
{
    public event EventHandler? Clicked;
    private double _sizeIcon = 24;
    private double _paddingButton = 16;
    public double SizeButton => _sizeIcon + _paddingButton;

    public ButtonAdd()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public double SizeIcon
    {
        get => _sizeIcon;
        set
        {
            _sizeIcon = value;
            OnPropertyChanged(nameof(SizeButton));
        }
    }

    public double PaddingButton
    {
        get => _paddingButton;
        set
        {
            _paddingButton = value;
            OnPropertyChanged(nameof(PaddingButton));
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, e);
    }
}