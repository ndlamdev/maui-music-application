// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 14:09:05 - 23/09/2024
// User: Lam Nguyen

using maui_music_application.Helpers;

namespace maui_music_application.Views.Components.Musics;

public partial class MusicInTop
{
    public MusicInTop()
    {
        InitializeComponent();
    }

    public ImageSource Source
    {
        set => Image.Source = value;
    }

    public string Name
    {
        set => NameMusic.Text = value;
    }

    public string Singer
    {
        set => NameSinger.Text = value;
    }

    public int Top
    {
        set => TopMusic.Text = $"#{value}";
    }

    public Action Action
    {
        set
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (_, _) =>
            {
                value.Invoke();
                await OpacityEffect.RunOpacity(this, 100);
            };
            RootView.GestureRecognizers.Add(tapGestureRecognizer);
            ImageView.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}