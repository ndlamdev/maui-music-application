// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using maui_music_application.Views.Adapters;
using maui_music_application.Views.Components.Buttons;
using maui_music_application.Views.Layouts;

namespace maui_music_application.Views.Pages;

public partial class LibraryPage
{
    private ButtonBorder[] _buttons;
    private GridLayout? _layout;

    public LibraryPage()
    {
        InitializeComponent();
        _buttons = [Folders, Playlists, Artists, Albums, Podcasts];
        Init();
    }

    private void Init()
    {
        // RecentPlaylist.Adapter(new PlayListMusicLargeAdapter(DataDemo.PlayListLarges));
    }

    private void Search_OnTapped(object? sender, TappedEventArgs e)
    {
    }

    private void SetBackgroundButtonSelected(object? sender)
    {
        foreach (var button in _buttons)
        {
            button.Selected = button.Equals(sender);
        }
    }

    private void InitLayout<T>(GridLayoutAdapter<T> adapter)
    {
        if (_layout != null) MainLayout.Children.Remove(_layout);
        _layout = new GridLayout()
        {
            RowSpacing = 25,
            Columns = 1,
        };
    }

    private void Folders_OnClicked(object? sender, EventArgs e)
    {
        SetBackgroundButtonSelected(sender);
        InitLayout(new FolderPlayListMusicAdapter(DataDemo.FolderPlayList));
        MainLayout.Children.Add(_layout);
    }


    private void Playlists_OnClicked(object? sender, EventArgs e)
    {
        SetBackgroundButtonSelected(sender);
        InitLayout(new PlayListMusicLargeAdapter(DataDemo.PlayListLarges));
        MainLayout.Children.Add(_layout);
    }

    private void Artists_OnClicked(object? sender, EventArgs e)
    {
        SetBackgroundButtonSelected(sender);
    }

    private void Albums_OnClicked(object? sender, EventArgs e)
    {
        SetBackgroundButtonSelected(sender);
    }

    private void Podcasts_OnClicked(object? sender, EventArgs e)
    {
        SetBackgroundButtonSelected(sender);
    }
}