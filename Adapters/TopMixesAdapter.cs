// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:49 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Views.Custom_Components;
using TopMixesModel = maui_music_application.Model.TopMixes;
using TopMixesView = maui_music_application.Views.Categories.TopMixes;

namespace maui_music_application.Adapters;

public class TopMixesAdapter(TopMixesModel[] listData) : GridLayoutAdapter<TopMixesModel>(listData)
{
    public override IView LoadContentView(int _,TopMixesModel data)
    {
        var view = new TopMixesView
        {
            Title = data.Title,
            Source = data.Image,
            Clicked = () => { Log.Info("KindMusicAdapter", $"Action {data.Id}"); }
        };
        return view;
    }
}