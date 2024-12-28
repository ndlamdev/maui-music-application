// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:21 - 23/09/2024
// User: Lam Nguyen

using maui_music_application.Dto;
using maui_music_application.Views.Components.Categories;
using maui_music_application.Views.Layouts;
using maui_music_application.Views.Pages;

namespace maui_music_application.Views.Adapters;

public class PlaylistCardAdapter(
    ResponsePlaylistCard[] listData,
    INavigation navigation,
    Action<ResponsePlaylistCard>? action = null)
    : GridLayoutAdapter<ResponsePlaylistCard>(listData)
{
    private bool _isSelected;

    public override IView LoadContentView(int _, ResponsePlaylistCard data)
    {
        var view = new PlaylistCard
        {
            Title = data.Name,
            SubTitle = $"{data.TotalSong} songs",
            Source = data.CoverUrl,
            Clicked = Clicked
        };
        return view;

        async void Clicked()
        {
            if (_isSelected) return;
            _isSelected = true;
            if (action != null)
            {
                action.Invoke(data);
            }
            else
                await navigation.PushAsync(new PlaylistMusicPage(data.Id));
            _isSelected = false;
        }
    }
}