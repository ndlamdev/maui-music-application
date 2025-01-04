// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 14:01:06 - 04/01/2025
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Dto;
using maui_music_application.Helpers.Enum;
using maui_music_application.Models;
using maui_music_application.Views.Layouts;
using maui_music_application.Views.Pages.User;
using Newtonsoft.Json;
using Artist = maui_music_application.Views.Components.Categories.Artist;
using MusicCard = maui_music_application.Views.Components.Musics.MusicCard;
using PlaylistCard = maui_music_application.Views.Components.Categories.PlaylistCard;

namespace maui_music_application.Views.Adapters;

using ArtistView = Artist;
using MusicCardView = MusicCard;
using PlaylistCard = PlaylistCard;

public class SearchAdapter(ResponseSearch[] searches, INavigation navigation)
    : GridLayoutAdapter<ResponseSearch>(searches)
{
    public override IView LoadContentView(int position, ResponseSearch data)
    {
        IView? result = null;
        switch (data.Type)
        {
            case SearchTypeEntry.All:
                break;
            case SearchTypeEntry.Artist:
                var artist = MapToArtist(data.Data);
                result = new ArtistView()
                {
                    Avatar = artist.Avatar,
                    Name = artist.Name,
                    Clicked = () => { Log.Info("KindMusicAdapter", $"Action {artist.Id}"); }
                };
                break;
            case SearchTypeEntry.Album:
                var album = MapToAlbum(data.Data);
                result = new PlaylistCard
                {
                    Title = album.Name,
                    SubTitle = album.Artist,
                    Source = album.CoverUrl,
                    Clicked = () => { navigation.PushAsync(new PlaylistMusicPage(album.Id, TypePlaylist.Album)); }
                };
                break;
            case SearchTypeEntry.Song:
                var song = MapToSong(data.Data);
                result = new MusicCardView
                {
                    SongId = song.Id,
                    SongName = song.Title,
                    SingerName = song.Artist,
                    SongThumbnail = song.Cover,
                    Action = _ => navigation.PushAsync(new SingleSongPage(song.Id))
                };
                break;
        }

        return result;
    }

    private Models.Artist MapToArtist(object data)
    {
        return JsonConvert.DeserializeObject<Models.Artist>(data.ToString());
    }

    private Models.MusicCard MapToSong(object data)
    {
        return JsonConvert.DeserializeObject<Music>(data.ToString());
    }

    private Album MapToAlbum(object data)
    {
        return JsonConvert.DeserializeObject<Album>(data.ToString());
    }
}