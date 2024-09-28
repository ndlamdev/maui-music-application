// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:56 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Views.Custom_Components;

namespace maui_music_application.Adapters;

using KindMusicView = Views.Categories.KindMusic;
using KindMusicModel = Model.KindMusic;

public class KindMusicAdapter(KindMusicModel[] listData) : GridLayoutAdapter<KindMusicModel>(listData)
{
    public override IView LoadContentView(int _,KindMusicModel data)
    {
        var view = new KindMusicView
        {
            Kind = data.Title,
            Source = data.Image,
            Clicked = () => { Log.Info("KindMusicAdapter", $"Action {data.Title}"); }
        };
        return view;
    }
}