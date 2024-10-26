// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 12:10:05 - 26/10/2024
// User: Lam Nguyen

using maui_music_application.Data;
using maui_music_application.Models;
using maui_music_application.Views.Adapters;

namespace maui_music_application.Views.Pages;

public partial class PlayListMusicPage
{
    private readonly PlayListMusic _playListMusic = SongPageData.Playlist;

    public PlayListMusicPage()
    {
        InitializeComponent();
        BindingContext = this;
        GridLayoutMusic.Rows = _playListMusic.Musics!.Count;
        GridLayoutMusic.Adapter(new MusicInPlayListAdapter(_playListMusic, Navigation));
    }

    public string PlayListThumbnail => _playListMusic.Thumbnail;
    public string PlayListName => _playListMusic.Title;
    public string PlayListType => _playListMusic.Type;

    private void OnBack(object? sender, EventArgs e)
    {
    }

    private void OnOption(object? sender, EventArgs e)
    {
    }
}