// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:35 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Models;
using maui_music_application.Views.Layouts;

namespace maui_music_application.Views.Adapters;

using MusicInTopView = Components.Musics.MusicInTop;

public class MusicInTopAdapter(MusicCardInTop[] listData) : GridLayoutAdapter<MusicCardInTop>(listData)
{
    public override IView LoadContentView(int _,MusicCardInTop data)
    {
        return new MusicInTopView
        {
            Name = data.Title,
            Singer = data.Artist,
            Top = data.Top,
            Source = data.Cover,
            Action = () =>
            {
                Log.Info("MusicInTopView", $"Click {data.Title}");
            }
        };
    }
}