// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:21 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Models;
using maui_music_application.Views.Components.Categories;
using maui_music_application.Views.Layouts;
using PlaylistMusic = maui_music_application.Models.PlaylistMusic;
using PlaylistMusicLarge = maui_music_application.Views.Components.Categories.PlaylistMusicLarge;

namespace maui_music_application.Views.Adapters;

public class AlbumAdapter(Album[] listData, INavigation navigation)
    : GridLayoutAdapter<Album>(listData)
{
    public override IView LoadContentView(int _, Album data)
    {
        var view = new PlaylistMusicLarge
        {
            Title = data.Title,
            SubTitle = data.Singer,
            Source = data.Thumbnail,
            Clicked = () => { Log.Info("KindMusicAdapter", $"Action {data.Id}"); }
        };
        return view;
    }
}