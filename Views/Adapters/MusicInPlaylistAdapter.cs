// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 11:09:01 - 26/09/2024
// User: Lam Nguyen

using maui_music_application.Dto;
using maui_music_application.Models;
using maui_music_application.Views.Components.Musics;
using maui_music_application.Views.Layouts;
using maui_music_application.Views.Pages;

namespace maui_music_application.Views.Adapters;

public class MusicInPlaylistAdapter(
    ResponsePlaylistDetail playlistDetail,
    INavigation navigation,
    Action<MusicInPlaylist.ShowPopupArgs>? optionAction = null)
    : GridLayoutAdapter<MusicCard>(playlistDetail.Songs.Content.ToArray())
{
    private bool _isSelected;

    public override IView LoadContentView(int position, MusicCard data)
    {
        return new MusicInPlaylist()
        {
            SongName = data.Title,
            SingerName = data.Artist,
            SongThumbnail = data.Cover,
            Action = Action,
            OptionAction = optionAction
        };

        async void Action()
        {
            if (_isSelected) return;
            _isSelected = true;
            await navigation.PushAsync(new SongPage(playlistDetail, position));
            _isSelected = false;
        }
    }
}