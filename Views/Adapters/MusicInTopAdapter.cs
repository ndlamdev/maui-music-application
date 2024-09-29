// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:35 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Layouts;
using MusicInTop = maui_music_application.Models.MusicInTop;

namespace maui_music_application.Adapters;

using MusicInTopModel = MusicInTop;
using MusicInTopView = Components.Musics.MusicInTop;

public class MusicInTopAdapter(MusicInTopModel[] listData) : GridLayoutAdapter<MusicInTopModel>(listData)
{
    public override IView LoadContentView(int _,MusicInTopModel data)
    {
        return new MusicInTopView
        {
            Name = data.Name,
            Singer = data.Signer,
            Top = data.Top,
            Source = data.Thumbnail,
            Action = () =>
            {
                Log.Info("MusicInTopView", $"Click {data.Name}");
            }
        };
    }
}