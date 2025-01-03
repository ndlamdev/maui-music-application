// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:04 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Models;
using maui_music_application.Views.Layouts;

namespace maui_music_application.Views.Adapters;

public class PlaylistMusicAdapter(PlaylistDetail[] listData) : GridLayoutAdapter<PlaylistDetail>(listData)
{
    public override IView LoadContentView(int _, PlaylistDetail data)
    {
        var view = new Components.Categories.PlaylistMusic
        {
            Title = data.Name,
            Source = data.CoverUrl,
            Clicked = () => { Log.Info("KindMusicAdapter", $"Action {data.Id}"); }
        };
        return view;
    }
}