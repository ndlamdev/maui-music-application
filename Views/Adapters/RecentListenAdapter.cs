// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 06:10:35 - 18/10/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Views.Layouts;
using RecentListenModel = maui_music_application.Models.RecentListen;
using RecentListenView = maui_music_application.Views.Components.Categories.RecentListen;

namespace maui_music_application.Views.Adapters;

public class RecentListenAdapter(RecentListenModel[] recentListens)
    : GridLayoutAdapter<RecentListenModel>(recentListens)
{
    public override IView LoadContentView(int position, RecentListenModel data)
    {
        return new RecentListenView()
        {
            Source = data.Thumbnail,
            Action = () => { Log.Info("RecentListenAdapter", data.Id); }
        };
    }
}