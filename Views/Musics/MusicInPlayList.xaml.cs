// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:00 - 26/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Utils;

namespace maui_music_application.Views.Musics;

public partial class MusicInPlayList
{
    private const string KeyDrag = "ElementIsDragging";
    private int _index, _initIndex = -1;

    public MusicInPlayList()
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
                value.Invoke();
                await OpacityEffect.RunOpacity(this, 100);
            };
            GestureRecognizers.Add(tapGestureRecognizer);
        }
    }

    public string Name
    {
        set => NameLabel.Text = value;
    }

    public string Singer
    {
        set => SingerLabel.Text = value;
    }

    private void DragGestureRecognizer_OnDragStarting(object? sender, DragStartingEventArgs e)
    {
        e.Data.Properties.Add(KeyDrag, this);
        Vibration.Vibrate(TimeSpan.FromMilliseconds(100));
        Opacity = 0;
    }

    private void DropGestureRecognizer_OnDragOver(object? sender, DragEventArgs e)
    {
        if (GetElementDragging(e) is not { } element) return;
        var index = CurrentIndexWithTranslationY(element);
        Log.Info("Index MusicInPlayList", index.ToString());
        (element.Index, Index) = (Index, element.Index);
    }

    private double GetRealHeight() => Height + Margin.Bottom;

    private double GetTranslationYInitWithParent()
    {
        return _initIndex * GetRealHeight();
    }

    public int Index
    {
        get => _index;
        set
        {
            _index = value;
            if (_initIndex.Equals(-1))
                _initIndex = value;
            else this.TranslateTo(0, _index * GetRealHeight() - GetTranslationYInitWithParent(), 100, Easing.SinInOut);
        }
    }

    private async void DragGestureRecognizer_OnDropCompleted(object? sender, DropCompletedEventArgs e)
    {
        await this.TranslateTo(0, _index * GetRealHeight() - GetTranslationYInitWithParent(), 200, Easing.SinInOut);
        Opacity = 1;
    }

    private static MusicInPlayList? GetElementDragging(DragEventArgs e)
    {
        if (!e.Data.Properties.TryGetValue(KeyDrag, out var valueElementIsDragging)
            || valueElementIsDragging is not MusicInPlayList element) return null;

        return element;
    }

    private int CurrentIndexWithTranslationY(MusicInPlayList element)
    {
        return (int)Math.Floor((element.TranslationY + element.GetTranslationYInitWithParent()) / GetRealHeight());
    }
}