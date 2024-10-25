// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 15:10:03 - 25/10/2024
// User: Lam Nguyen

namespace maui_music_application.Views.Fragments;

public partial class SongPageShowMore
{
    private string? _songName, _singerName, _thumbnail;

    public SongPageShowMore()
    {
        InitializeComponent();
        BindingContext = this;
    }

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
        get => _thumbnail ?? "";
        set
        {
            _thumbnail = value;
            OnPropertyChanged();
        }
    }

    private void Back_OnClicked(object? sender, EventArgs e)
    {
        OnBack?.Invoke(sender, e);
    }

    private void Heart_OnTapped(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public event EventHandler? OnBack;
}