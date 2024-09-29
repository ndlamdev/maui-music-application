// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:21 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Components.Categories;
using maui_music_application.Layouts;

namespace maui_music_application.Adapters;

using FolderPlayListMusicModel = Models.FolderPlayListMusic;
using FolderPlayListMusicView = PlayListMusicLarge;

public class FolderPlayListMusicAdapter(FolderPlayListMusicModel[] listData)
    : GridLayoutAdapter<FolderPlayListMusicModel>(listData)
{
    public override IView LoadContentView(int _,FolderPlayListMusicModel data)
    {
        var view = new FolderPlayListMusicView
        {
            Title = data.Title,
            SubTitle = data.SubTitle,
            Source = data.Image,
            Clicked = () => { Log.Info("KindMusicAdapter", $"Action {data.Id}"); }
        };
        return view;
    }
}