// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 08:10:23 - 21/10/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Views.Layouts;

namespace maui_music_application.Views.Adapters;

using ArtistModel = Models.Artist;
using ArtistView = Components.Categories.Artist;

public class ArtistsAdapter(ArtistModel[] listData) : GridLayoutAdapter<ArtistModel>(listData)
{
    public override IView LoadContentView(int position, ArtistModel data)
    {
        return new ArtistView
        {
            Avatar = data.Avatar,
            Name = data.Name,
            Clicked = () => { Log.Info("KindMusicAdapter", $"Action {data.Id}"); }
        };
    }
}