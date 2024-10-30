// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:21 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Models;
using maui_music_application.Views.Layouts;
using PlaylistMusicLarge = maui_music_application.Views.Components.Categories.PlaylistMusicLarge;

namespace maui_music_application.Views.Adapters;

public class FolderPlaylistMusicAdapter(FolderPlaylistMusic[] listData)
    : GridLayoutAdapter<FolderPlaylistMusic>(listData)
{
    public override IView LoadContentView(int _, FolderPlaylistMusic data)
    {
        var view = new PlaylistMusicLarge
        {
            Title = data.Title,
            SubTitle = $"{data.Playlists.Count} playlists",
            Source = data.Thumbnail,
            Clicked = () => { Log.Info("KindMusicAdapter", $"Action {data.Id}"); }
        };
        return view;
    }
}