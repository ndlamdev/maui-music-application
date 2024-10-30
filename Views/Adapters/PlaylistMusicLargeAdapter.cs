// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:21 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Models;
using maui_music_application.Views.Components.Categories;
using maui_music_application.Views.Layouts;
using maui_music_application.Views.Pages;
using PlaylistMusic = maui_music_application.Models.PlaylistMusic;
using PlaylistMusicLarge = maui_music_application.Views.Components.Categories.PlaylistMusicLarge;

namespace maui_music_application.Views.Adapters;

public class PlaylistMusicLargeAdapter(PlaylistMusic[] listData, INavigation navigation)
    : GridLayoutAdapter<PlaylistMusic>(listData)
{
    public override IView LoadContentView(int _, PlaylistMusic data)
    {
        var view = new PlaylistMusicLarge
        {
            Title = data.Title,
            SubTitle = $"{data.Musics!.Count} songs",
            Source = data.Thumbnail,
            Clicked = Clicked
        };
        return view;

        async void Clicked()
        {
            await navigation.PushAsync(new PlaylistMusicPage(data.Id));
        }
    }
}