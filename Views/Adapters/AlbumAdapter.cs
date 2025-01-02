// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:21 - 23/09/2024
// User: Lam Nguyen

using maui_music_application.Helpers.Enum;
using maui_music_application.Models;
using maui_music_application.Views.Layouts;
using maui_music_application.Views.Pages.User;
using PlaylistCard = maui_music_application.Views.Components.Categories.PlaylistCard;

namespace maui_music_application.Views.Adapters;

public class AlbumAdapter(Album[] listData, INavigation navigation)
    : GridLayoutAdapter<Album>(listData)
{
    public override IView LoadContentView(int _, Album data)
    {
        var view = new PlaylistCard
        {
            Title = data.Name,
            SubTitle = data.Artist,
            Source = data.CoverUrl,
            Clicked = () => { navigation.PushAsync(new PlaylistMusicPage(data.Id, TypePlaylist.Album)); }
        };
        return view;
    }
}