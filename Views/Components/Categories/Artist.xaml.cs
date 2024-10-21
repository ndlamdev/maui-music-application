// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 14:09:39 - 22/09/2024
// User: Lam Nguyen

using maui_music_application.Helpers;

namespace maui_music_application.Views.Components.Categories;

public partial class Artist
{
    public Artist()
    {
        InitializeComponent();
    }

    public ImageSource Avatar
    {
        set => Image.Source = value;
    }

    public string Name
    {
        set => Label.Text = value;
    }

    public Action Clicked
    {
        set
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (_, _) =>
            {
                value.Invoke();
                await OpacityEffect.RunOpacity(this, 100);
            };
            Frame.GestureRecognizers.Add(tapGestureRecognizer);
            FrameImage.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}