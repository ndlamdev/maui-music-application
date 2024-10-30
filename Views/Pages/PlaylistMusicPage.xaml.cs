// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 12:10:05 - 26/10/2024
// User: Lam Nguyen

using maui_music_application.Data;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Views.Adapters;

namespace maui_music_application.Views.Pages;

public partial class PlaylistMusicPage
{
    private readonly PlaylistMusic _playlistMusic = SongPageData.Playlist;

    public PlaylistMusicPage(string dataId)
    {
        InitializeComponent();
        BindingContext = this;
        GridLayoutMusic.Rows = _playlistMusic.Musics!.Count;
        GridLayoutMusic.Adapter(new MusicInPlaylistAdapter(_playlistMusic, Navigation));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
    }

    public string PlayListThumbnail => _playlistMusic.Thumbnail;

    public string PlayListName => _playlistMusic.Title;

    public string PlayListType => _playlistMusic.Type;

    private async void OnBack(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
        await Navigation.PopAsync();
    }

    private async void OnOption(object? sender, EventArgs e)
    {
        await OpacityEffect.RunOpacity((View)sender!, 100);
    }
}