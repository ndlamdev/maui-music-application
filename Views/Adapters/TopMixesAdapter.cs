// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:49 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Views.Layouts;
using TopMixesModel = maui_music_application.Models.TopMixes;
using TopMixesView = maui_music_application.Views.Components.Categories.TopMixes;

namespace maui_music_application.Views.Adapters;

public class TopMixesAdapter(TopMixesModel[] listData) : GridLayoutAdapter<TopMixesModel>(listData)
{
    public override IView LoadContentView(int _, TopMixesModel data)
    {
        var view = new TopMixesView
        {
            Title = data.Name,
            Source = data.CoverUrl,
            Clicked = () => { Log.Info("KindMusicAdapter", $"Action {data.Id}"); }
        };
        return view;
    }
}