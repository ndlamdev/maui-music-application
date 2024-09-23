// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:47 - 23/09/2024
// User: Lam Nguyen

using maui_music_application.Model;

namespace maui_music_application.Views.Categories;

public partial class TopMixes
{
    public TopMixes()
    {
        InitializeComponent();
        FrameColor.BackgroundColor = RandomColorGenerator.GetRandomColor();
    }

    public string Title
    {
        set => Label.Text = value;
    }

    public ImageSource Source
    {
        set => Image.Source = value;
    }

    public Action Clicked
    {
        set
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => value?.Invoke();
            Frame1.GestureRecognizers.Add(tapGestureRecognizer);
            Frame2.GestureRecognizers.Add(tapGestureRecognizer);
            RootView.GestureRecognizers.Add(tapGestureRecognizer);
            FrameColor.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}