// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:04 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Views.Custom_Components;

namespace maui_music_application.Adapters;

using PlayListMusicModel = Model.PlayListMusic;
using PlayListMusicView = Views.Categories.PlayListMusic;
public class PlayListMusicAdapter(PlayListMusicModel[] listData) : GridLayoutAdapter<PlayListMusicModel>(listData)
{
    public override IView LoadContentView(int _,PlayListMusicModel data)
    {
        var view = new PlayListMusicView
        {
            Title = data.Title,
            Source = data.Image,
            Clicked = () => { Log.Info("KindMusicAdapter", $"Action {data.Id}"); }
        };
        return view;
    }
}