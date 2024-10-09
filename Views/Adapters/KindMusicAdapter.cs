// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:56 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Views.Components.Categories;
using maui_music_application.Views.Layouts;

namespace maui_music_application.Views.Adapters;

using KindMusicView = KindMusic;
using KindMusicModel = Models.KindMusic;

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