// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 08:09:43 - 22/09/2024
// User: Lam Nguyen

using maui_music_application.Helpers;

namespace maui_music_application.Components.Buttons;

public partial class ButtonIconCircle
{
    public event EventHandler? Clicked;
    private double _sizeIcon = 24;
    private double _paddingButton = 16;

    public ButtonIconCircle()
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
            OnPropertyChanged();
        }
    }

    public double PaddingButton
    {
        get => _paddingButton;
        set
        {
            _paddingButton = value;
            OnPropertyChanged();
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