// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 11:09:01 - 26/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Data;
using maui_music_application.Models;
using maui_music_application.Views.Components.Musics;
using maui_music_application.Views.Layouts;
using maui_music_application.Views.Pages;

namespace maui_music_application.Views.Adapters;

public class MusicInPlaylistAdapter(PlaylistMusic playlistMusic, INavigation navigation)
    : GridLayoutAdapter<Music>(playlistMusic.Musics!.ToArray())
{
    private bool _isSelected;

    public override IView LoadContentView(int position, Music data)
    {
        return new MusicInPlaylist()
        {
            SongName = data.Name,
            SingerName = data.Signer,
            SongThumbnail = data.Thumbnail,
            Action = Action
        };

        async void Action()
        {
            if (_isSelected) return;
            _isSelected = true;
            await navigation.PushAsync(new SongPage(playlistMusic, position));
            _isSelected = false;
        }
    }
}