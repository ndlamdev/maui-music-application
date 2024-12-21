// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:21 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Models;
using maui_music_application.Views.Components.Categories;
using maui_music_application.Views.Layouts;

namespace maui_music_application.Views.Adapters;

public class PodcastAndShowAdapter(PodcastAndShow[] listData, INavigation navigation)
    : GridLayoutAdapter<PodcastAndShow>(listData)
{
    public override IView LoadContentView(int _, PodcastAndShow data)
    {
        var view = new PlaylistCard
        {
            Title = data.Title,
            SubTitle = data.Author,
            Source = data.Thumbnail,
            Clicked = () => { Log.Info("KindMusicAdapter", $"Action {data.Id}"); }
        };
        return view;
    }
}