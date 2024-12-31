// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 11:09:01 - 26/09/2024
// User: Lam Nguyen

using maui_music_application.Helpers.Enum;
using maui_music_application.Models;
using maui_music_application.Views.Components.Musics;
using maui_music_application.Views.Layouts;
using maui_music_application.Views.Pages.User;

namespace maui_music_application.Views.Adapters;

public class MusicInPlaylistAdapter(
    PlaylistDetail playlistDetail,
    INavigation navigation,
    Page page = null,
    bool canRemove = true,
    TypePlaylist type = TypePlaylist.Playlist)
    : GridLayoutAdapter<MusicCard>(playlistDetail.Songs.Content.ToArray())
{
    private bool _isSelected;

    public override IView LoadContentView(int position, MusicCard data)
    {
        return new MusicInPlaylist
        {
            PlaylistId = playlistDetail.Id,
            SongId = data.Id,
            SongName = data.Title,
            SingerName = data.Artist,
            SongThumbnail = data.Cover,
            Action = Action,
            Page = page,
            Type = type,
            CanRemove = canRemove
        };

        async void Action()
        {
            if (_isSelected) return;
            _isSelected = true;
            await navigation.PushAsync(new SongInPlaylistPage(playlistDetail, position));
            _isSelected = false;
        }
    }
}