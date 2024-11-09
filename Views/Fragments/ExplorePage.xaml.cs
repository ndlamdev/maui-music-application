// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Data;
using maui_music_application.Views.Adapters;

namespace maui_music_application.Views.Fragments;

public partial class ExplorePage
{
    public ExplorePage()
    {
        InitializeComponent();
        Init();
    }

    /*Call request here!*/
    private async void OnContentViewLoaded(object sender, EventArgs e)
    {
    }

    private void Init()
    {
        KindMusic.Adapter(new KindMusicAdapter(DataDemoGridLayout.Categories));
        Browse.Adapter(new KindMusicAdapter(DataDemoGridLayout.Categories));
        Browse.AddElement(DataDemoGridLayout.Categories);
        Browse.AddElement(DataDemoGridLayout.Categories);
    }

    private void Search_OnOnTextChanged(object? sender, TextChangedEventArgs e)
    {
        Log.Info("ExplorePage", e.NewTextValue);
    }
}