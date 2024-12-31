// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 23:12:18 - 31/12/2024
// User: Lam Nguyen

using maui_music_application.ViewModels;

namespace maui_music_application.Views.Fragments;

public partial class SongInfo
{
    public SongInfo()
    {
        InitializeComponent();
        BindingContext = new MusicInfoManager(1, "", "", "", "", "");
    }

    public event EventHandler<TappedEventArgs>? BackClicked;

    private void Back_OnClicked(object? sender, TappedEventArgs e)
    {
        BackClicked?.Invoke(sender, e);
    }
}