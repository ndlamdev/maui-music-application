// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:21 - 23/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Views.Custom_Components;

namespace maui_music_application.Adapters;

using FolderPlayListMusicModel = Model.FolderPlayListMusic;
using FolderPlayListMusicView = Views.Categories.PlayListMusicLarge;

public class FolderPlayListMusicAdapter(FolderPlayListMusicModel[] listData)
    : GridLayoutAdapter<FolderPlayListMusicModel>(listData)
{
    public override IView LoadContentView(FolderPlayListMusicModel data)
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