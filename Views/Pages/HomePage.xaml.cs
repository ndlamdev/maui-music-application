// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using maui_music_application.Data;
using maui_music_application.Views.Adapters;

namespace maui_music_application.Views.Pages;

public partial class HomePage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = this;
        Init();
    }

    private void Init()
    {
        PlayListMusic.Adapter(new PlayListMusicAdapter(DataDemoGridLayout.PlayLists));
        TopMixes.Adapter(new TopMixesAdapter(DataDemoGridLayout.TopMixes));
        RecentListen.Adapter(new RecentListenAdapter(DataDemoGridLayout.RecentListens));
    }
}