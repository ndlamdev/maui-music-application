// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Helpers;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;

namespace maui_music_application.Views.Fragments;

public partial class ExplorePage
{
    private KindMusic[] _categories = [];
    private IGenreServices? _genreServices;

    public ExplorePage()
    {
        InitializeComponent();
        Init();
    }

    /*Call request here!*/
    private async void OnContentViewLoaded(object sender, EventArgs e)
    {

    }

    private async Task GetCategories()
    {
        try
        {
            _genreServices = ServiceHelper.GetService<IGenreServices>();
            List<KindMusic> categories = await _genreServices.GetCategories();
            if (categories is not null)
            {
                _categories = categories.ToArray();
            }

        }
        catch (Exception ex)
        {
            Log.Error("ExplorePage", $"{ex.Message}");
        }

    }

    private async void Init()
    {
        await GetCategories();
        Log.Info("ExplorePage", $"Data {_categories.Length} items");
        KindMusic.Adapter(new KindMusicAdapter(_categories));
        Browse.Adapter(new KindMusicAdapter(_categories));
        Browse.AddElement(_categories);
        Browse.AddElement(_categories);
    }

    private void Search_OnOnTextChanged(object? sender, TextChangedEventArgs e)
    {
        Log.Info("ExplorePage", e.NewTextValue);
    }
}