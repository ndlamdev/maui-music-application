// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using maui_music_application.Data;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;
using maui_music_application.Views.Components.Buttons;
using maui_music_application.Views.Layouts;
using maui_music_application.Views.Pages;

namespace maui_music_application.Views.Fragments;

public partial class LibraryPage
{
    private ButtonBorder[] _buttons;
    private GridLayout? _layout;
    private bool _isSelected;

    private enum SortStatus
    {
        Asc,
        Desc,
        Null,
    }

    private SortStatus _sortStatus = SortStatus.Null;

    public LibraryPage()
    {
        InitializeComponent();
        _buttons = [Folders, Playlists, Artists, Albums, Podcasts];
        RootGridLayout.Adapter(new PlaylistMusicLargeAdapter(DataDemoGridLayout.PlaylistLarges, Navigation));
    }

    /*Call request here!*/
    private async void OnContentViewLoaded(object sender, EventArgs e)
    {
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

    private void Playlists_OnClicked(object? sender, EventArgs e)
    {
        SetBackgroundButtonSelected(sender);
        SetUpButtonAddAndHeart(sender);
        RootGridLayout.Adapter(new PlaylistMusicLargeAdapter(DataDemoGridLayout.PlaylistLarges, Navigation));
    }

    private void Folders_OnClicked(object? sender, EventArgs e)
    {
        SetBackgroundButtonSelected(sender);
        SetUpButtonAddAndHeart(sender);
        RootGridLayout.Adapter(new FolderPlaylistMusicAdapter(DataDemoGridLayout.FolderPlaylist));
    }

    private void Artists_OnClicked(object? sender, EventArgs e)
    {
        SetBackgroundButtonSelected(sender);
        SetUpButtonAddAndHeart(sender);
        RootGridLayout.Adapter(new ArtistsAdapter(DataDemoGridLayout.Artists));
    }

    private void Albums_OnClicked(object? sender, EventArgs e)
    {
        SetBackgroundButtonSelected(sender);
        SetUpButtonAddAndHeart(sender);
        RootGridLayout.Adapter(new AlbumAdapter(DataDemoGridLayout.Albums, Navigation));
    }

    private void Podcasts_OnClicked(object? sender, EventArgs e)
    {
        SetUpButtonAddAndHeart(sender);
        SetBackgroundButtonSelected(sender);
        RootGridLayout.Adapter(new PodcastAndShowAdapter(DataDemoGridLayout.PodcastsAndShows, Navigation));
    }

    private void SetUpButtonAddAndHeart(object? sender)
    {
        _sortStatus = SortStatus.Null;
        if (sender == Folders || sender == Playlists)
        {
            ButtonAdd.IsVisible = true;
            ButtonHeart.IsVisible = true;
            ButtonAdd.Title = "Add New Playlist";
            ButtonHeart.Title = "Your Liked Songs";
            SwapButton.Text = "Recently played";
            return;
        }

        if (sender == Albums)
        {
            SwapButton.Text = "Recently played";
            return;
        }

        if (sender == Artists)
        {
            SwapButton.Text = "A - Z";
            return;
        }

        {
            SwapButton.Text = "A - Z";
        }
    }

    private void SortButton_OnClicked(object? sender, EventArgs e)
    {
        _sortStatus = _sortStatus != SortStatus.Asc ? SortStatus.Asc : SortStatus.Desc;
        if (Playlists.Selected || Albums.Selected)
        {
            var data = _sortStatus is SortStatus.Null or SortStatus.Desc
                ? RootGridLayout.GetData<PlaylistMusic>().OrderByDescending(music => music.TimeCreate).ToArray()
                : RootGridLayout.GetData<PlaylistMusic>().OrderBy(music => music.TimeCreate).ToArray();
            RootGridLayout.Adapter(new PlaylistMusicLargeAdapter(data, Navigation));
            return;
        }

        if (Folders.Selected)
        {
            var data = _sortStatus is SortStatus.Null or SortStatus.Desc
                ? RootGridLayout.GetData<FolderPlaylistMusic>().OrderByDescending(music => music.TimeCreate).ToArray()
                : RootGridLayout.GetData<FolderPlaylistMusic>().OrderBy(music => music.TimeCreate).ToArray();
            RootGridLayout.Adapter(new FolderPlaylistMusicAdapter(data));
            return;
        }

        if (Artists.Selected)
        {
            var data = _sortStatus is SortStatus.Null or SortStatus.Desc
                ? RootGridLayout.GetData<Artist>().OrderByDescending(artist => artist.Name).ToArray()
                : RootGridLayout.GetData<Artist>().OrderBy(artist => artist.Name).ToArray();
            RootGridLayout.Adapter(new ArtistsAdapter(data));
            return;
        }

        {
            var data = _sortStatus is SortStatus.Null or SortStatus.Desc
                ? RootGridLayout.GetData<PlaylistMusic>().OrderByDescending(music => music.Title).ToArray()
                : RootGridLayout.GetData<PlaylistMusic>().OrderBy(music => music.Title).ToArray();
            RootGridLayout.Adapter(new PlaylistMusicLargeAdapter(data, Navigation));
        }
    }

    private async void ButtonAdd_OnClicked(object? sender, EventArgs e)
    {
        if (_isSelected) return;
        _isSelected = true;
        await Navigation.PushAsync(new CreatePlaylistPage(), true);
        _isSelected = false;
    }

    private async void ButtonLogout_OnClicked(object? sender, EventArgs e)
    {
        IUserService userService = ServiceHelper.GetService<IUserService>();
        if (_isSelected) return;
        _isSelected = true;
        await userService.Logout();
        // Chưa xử lý lỗi redicrect
        await Navigation.PushAsync(new MainPage(), true);
        _isSelected = false;
    }
}