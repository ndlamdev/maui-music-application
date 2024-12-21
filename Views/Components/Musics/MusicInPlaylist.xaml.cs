// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:00 - 26/09/2024
// User: Lam Nguyen

using maui_music_application.Helpers;
using maui_music_application.Views.Components.Popup;

namespace maui_music_application.Views.Components.Musics;

public partial class MusicInPlaylist
{
    private string? _songName, _singerName, _songThumbnail;

    public MusicInPlaylist()
    {
        InitializeComponent();
        BindingContext = this;
    }


    public Action Action
    {
        set
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (_, _) =>
            {
                await OpacityEffect.RunOpacity(this, 100);
                value.Invoke();
            };
            GestureRecognizers.Add(tapGestureRecognizer);
        }
    }

    public Action<CommunityToolkit.Maui.Views.Popup>? OptionAction { get; set; }

    public string SongName
    {
        get => _songName ?? "";
        set
        {
            _songName = value;
            OnPropertyChanged();
        }
    }

    public string SingerName
    {
        get => _singerName ?? "";
        set
        {
            _singerName = value;
            OnPropertyChanged();
        }
    }

    public string SongThumbnail
    {
        get => _songThumbnail ?? "";
        set
        {
            _songThumbnail = value;
            OnPropertyChanged();
        }
    }

    private void ImageButton_OnClicked(object? sender, EventArgs e)
    {
        var button = sender as Button;
        var popup = new ContextMenuPopup();
        popup.SetAnchor(button.AnchorX - 100, button.AnchorY);
        OptionAction?.Invoke(popup);
    }

    public class ShowPopupArgs
    {
    }
}