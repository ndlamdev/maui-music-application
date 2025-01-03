// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:35 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Models;
using maui_music_application.Views.Layouts;
using maui_music_application.Views.Pages.User;

namespace maui_music_application.Views.Adapters;

using MusicInTopView = Components.Musics.MusicInTop;

public class MusicInTopAdapter(MusicCardInTop[] listData, INavigation navigation)
    : GridLayoutAdapter<MusicCardInTop>(listData)
{
    public override IView LoadContentView(int position, MusicCardInTop data)
    {
        return new MusicInTopView
        {
            Name = data.Title,
            Singer = data.Artist,
            Top = position + 1,
            Source = data.Cover,
            Action = () => { navigation.PushAsync(new SingleSongPage(data.Id)); }
        };
    }
}