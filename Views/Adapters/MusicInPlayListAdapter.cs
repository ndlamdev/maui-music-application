// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 11:09:01 - 26/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Models;
using maui_music_application.Views.Components.Musics;
using maui_music_application.Views.Layouts;

namespace maui_music_application.Views.Adapters;

public class MusicInPlayListAdapter(Music[] listData) : GridLayoutAdapter<Music>(listData)
{
    public override IView LoadContentView(int position, Music data)
    {
        return new MusicInPlayList
        {
            Index = position,
            Name = data.Name,
            Singer = data.Signer,
            Action = () => { Log.Info("MusicInPlayList", $"Click {data.Name}"); }
        };
    }
}