// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 23:12:02 - 31/12/2024
// User: Lam Nguyen

using maui_music_application.Helpers;
using maui_music_application.Views.Layouts;
using maui_music_application.Views.Pages.Admin;
using maui_music_application.Views.Pages.User;
using MusicCard = maui_music_application.Models.MusicCard;
using MusicCardView = maui_music_application.Views.Components.Musics.MusicCard;

namespace maui_music_application.Views.Adapters;

public class MusicAdapter(
    MusicCard[] listData,
    SongManagerPage page,
    INavigation navigation,
    Action longPress
)
    : GridLayoutAdapter<MusicCard>(listData)
{
    private bool _isSelected;

    public override IView LoadContentView(int position, MusicCard data)
    {
        return new MusicCardView
        {
            SongId = data.Id,
            SongName = data.Title,
            SingerName = data.Artist,
            SongThumbnail = data.Cover,
            Action = Action,
            Page = page,
            LongPressCommand = new Command(async () => { longPress.Invoke(); }),
            OnLongPressCompleted = card => page.CurrentMusicWorking = card
        };

        async void Action(object? sender)
        {
            if (_isSelected) return;
            _isSelected = true;
            await OpacityEffect.RunOpacity((View?)sender, 100);
            await navigation.PushAsync(new SingleSongPage(data.Id));
            _isSelected = false;
        }
    }
}