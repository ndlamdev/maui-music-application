// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using Java.Lang;
using maui_music_application.Data;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Enum;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;
using maui_music_application.Views.Components.Buttons;
using maui_music_application.Views.Pages;
using Exception = System.Exception;
using PlaylistDetail = maui_music_application.Models.PlaylistDetail;

namespace maui_music_application.Views.Fragments;

public partial class LibraryPage
{
    private readonly ButtonBorder[] _buttons;
    private bool _isSelected;
    private ApiPaging<PlaylistCard> _playlists = new();

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
    }


    private void OnContentViewLoaded(object sender, EventArgs e)
    {
        LoadPlaylist();
    }

    public void Reload()
    {
        LoadPlaylist();
    }

    private void LoadPlaylist()
    {
        var service = ServiceHelper.GetService<IPlaylistService>();
        if (service == null) throw new NullPointerException();
        service.GetPlaylistCards().ContinueWith(task =>
        {
            if (!task.IsCompleted) return;
            var result = task.Result;
            _playlists = result;
            RootGridLayout.Adapter(new PlaylistCardAdapter(result.Content.ToArray(), Navigation));
        }, TaskScheduler.FromCurrentSynchronizationContext());
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

    private async void Playlists_OnClicked(object? sender, EventArgs e)
    {
        SetBackgroundButtonSelected(sender);
        SetUpButtonAddAndHeart(sender);
        RootGridLayout.Adapter(new PlaylistCardAdapter(_playlists.Content.ToArray(), Navigation));
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
            // RootGridLayout.Adapter(new PlaylistCardAdapter(data, Navigation));
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
                ? RootGridLayout.GetData<PlaylistDetail>().OrderByDescending(music => music.Name).ToArray()
                : RootGridLayout.GetData<PlaylistDetail>().OrderBy(music => music.Name).ToArray();
            // RootGridLayout.Adapter(new PlaylistCardAdapter(data, Navigation));
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
        try
        {
            var userService = ServiceHelper.GetService<IUserService>();
            if (userService == null || _isSelected) return;
            _isSelected = true;
            await userService.Logout();
            await Navigation.PushAsync(new LoginPage(), true);
            _isSelected = false;
        }
        catch (Exception exception)
        {
            AndroidHelper.ShowToast(exception.Message);
        }
    }

    private async void Favorites_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new PlaylistMusicPage(TypePlaylist.Favorite), true);
    }
}