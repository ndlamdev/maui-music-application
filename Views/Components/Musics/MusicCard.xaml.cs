// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:00 - 26/09/2024
// User: Lam Nguyen

using Android.Util;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using maui_music_application.Helpers;
using maui_music_application.Views.Components.Popup;

namespace maui_music_application.Views.Components.Musics;

public partial class MusicCard
{
    private string? _songName, _singerName, _songThumbnail;

    public MusicCard()
    {
        InitializeComponent();
        BindingContext = this;
    }


    public Action<object?>? Action { get; set; }

    public string SongName
    {
        get => _songName ?? string.Empty;
        set
        {
            _songName = value;
            OnPropertyChanged();
        }
    }

    public string SingerName
    {
        get => _singerName ?? string.Empty;
        set
        {
            _singerName = value;
            OnPropertyChanged();
        }
    }

    public long SongId { get; set; }

    public string SongThumbnail
    {
        get => _songThumbnail ?? string.Empty;
        set
        {
            _songThumbnail = value;
            OnPropertyChanged();
        }
    }

    public Page Page { get; set; } = new();

    public Command? LongPressCommand { get; set; }

    private async void ImageButton_OnClicked(object sender, TappedEventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender, 100);
        var contextMenuPopup = new ContextMenuPopup();
        contextMenuPopup.SetMenuItems(["Xóa bài hát"],
        [
            (_, _) => { }
        ]);
        contextMenuPopup.SetPoint(e.GetPosition(Page)?.X - 165 ?? 0,
            e.GetPosition(Page)?.Y + 10 ?? 0);
        Page.ShowPopup(contextMenuPopup);
    }

    public bool IsLongPress { get; set; }

    public Action<MusicCard>? OnLongPressCompleted;

    private void TouchBehavior_OnLongPressCompleted(object? sender, LongPressCompletedEventArgs e)
    {
        IsLongPress = true;
        OnLongPressCompleted?.Invoke(this);
    }

    private void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        if (IsLongPress) return;
        Action?.Invoke(this);
    }
}