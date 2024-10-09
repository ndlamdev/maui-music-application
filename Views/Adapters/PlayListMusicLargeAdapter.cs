// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:21 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Views.Components.Categories;
using maui_music_application.Views.Layouts;

namespace maui_music_application.Views.Adapters;

using PlayListMusicLargeModel = Models.PlayListMusicLarge;
using PlayListMusicLargeView = PlayListMusicLarge;

public class PlayListMusicLargeAdapter(PlayListMusicLargeModel[] listData)
    : GridLayoutAdapter<PlayListMusicLargeModel>(listData)
{
    public override IView LoadContentView(int _,PlayListMusicLargeModel data)
    {
        var view = new PlayListMusicLargeView
        {
            Title = data.Title,
            SubTitle = data.SubTitle,
            Source = data.Image,
            Clicked = () => { Log.Info("KindMusicAdapter", $"Action {data.Id}"); }
        };
        return view;
    }
}