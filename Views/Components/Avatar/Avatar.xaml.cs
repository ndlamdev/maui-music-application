using maui_music_application.Helpers;
using Microsoft.Maui.Controls.Shapes;

namespace maui_music_application.Views.Components.Avatar;

public partial class Avatar : ContentView
{
    public event EventHandler? Clicked;

    public Avatar()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, e);
        await OpacityEffect.RunOpacity(this, 100);
    }


    public static readonly BindableProperty ImageUrlProperty =
        BindableProperty.Create(nameof(ImageUrl), typeof(string), typeof(Avatar), default(string),
            propertyChanged: OnImageUrlChanged);

    public string ImageUrl
    {
        get => (string)GetValue(ImageUrlProperty);
        set => SetValue(ImageUrlProperty, value);
    }

    private static void OnImageUrlChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (Avatar)bindable;
        if (newValue is string url)
        {
            control.AvatarImage.Source = url;
        }
    }


    public new double Width
    {
        set => Border.WidthRequest = value;
    }

    public new double Height
    {
        set => Border.HeightRequest = value;
    }

    public double Radius
    {
        set => Border.StrokeShape = new RoundRectangle() { CornerRadius = value };
    }

    public double Size
    {
        set
        {
            Border.WidthRequest = value;
            Border.HeightRequest = value;
        }
    }
}
