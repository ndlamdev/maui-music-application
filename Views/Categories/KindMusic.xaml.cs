// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 14:09:39 - 22/09/2024
// User: Lam Nguyen

using maui_music_application.Model;

namespace maui_music_application.Views.Categories;

public partial class KindMusic : ContentView
{
    public KindMusic()
    {
        InitializeComponent();
        ButtonBackgroundColor = RandomColorGenerator.GetRandomColor();
    }

    public ImageSource Source
    {
        set => Image.Source = value;
    }

    public Color ButtonBackgroundColor
    {
        set => Frame.BackgroundColor = value;
    }

    public string Kind
    {
        set => Label.Text = value;
    }

    public Action Clicked
    {
        set
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => value?.Invoke();
            Frame.GestureRecognizers.Add(tapGestureRecognizer);
            FrameImage.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}