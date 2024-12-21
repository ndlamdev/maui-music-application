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

public class MusicInQueueAdapter(MusicCard[] listData) : GridLayoutAdapter<MusicCard>(listData)
{
    public override IView LoadContentView(int position, MusicCard data)
    {
        return new MusicInQueue
        {
            Index = position,
            Name = data.Title,
            Singer = data.Artist,
            Action = () => { Log.Info("MusicInPlayList", $"Click {data.Title}"); }
        };
    }
}