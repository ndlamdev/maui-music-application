// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using Android.Util;
using Java.Lang;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Enum;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Adapters;
using Exception = System.Exception;

namespace maui_music_application.Views.Fragments;

public partial class ExplorePage
{
    private KindMusic[] _categories = [];
    private IGenreServices? _genreServices;
    private readonly Debouncer _debouncer = new();
    private string _keyword = "";
    private Pageable _currentPage = new();


    public ExplorePage()
    {
        InitializeComponent();
        Init();
    }

    private async Task GetCategories()
    {
        try
        {
            _genreServices = ServiceHelper.GetService<IGenreServices>();
            if (_genreServices == null) return;
            var categories = await _genreServices.GetCategories();
            _categories = categories.ToArray();
        }
        catch (Exception ex)
        {
            Log.Error("ExplorePage", $"{ex.Message}");
        }
    }

    private async void Init()
    {
        try
        {
            await GetCategories();
            KindMusic.Adapter(new KindMusicAdapter(_categories));
            Browse.Adapter(new KindMusicAdapter(_categories));
        }
        catch (Exception e)
        {
            // TODO handle exception
        }
    }

    private void Search_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _debouncer.UseDebounced(() =>
        {
            if (string.Empty == e.NewTextValue)
            {
                NotSearchDisplay.IsVisible = true;
                SearchDisplay.IsVisible = false;
                return;
            }

            NotSearchDisplay.IsVisible = false;
            SearchDisplay.IsVisible = true;
            if (_keyword == e.NewTextValue) return;
            Search(e.NewTextValue);
        }, 750);
    }

    private bool IsLast { get; set; }

    private void ScrollView_OnScrolled(object? sender, ScrolledEventArgs e)
    {
        if (sender is not ScrollView scrollView) return;
        if (SearchDisplay.IsLoading || IsLast ||
            !(e.ScrollY >= scrollView.ContentSize.Height - scrollView.Height - 5)) return;
        SearchDisplay.IsLoading = true;
        LoadDataNextPage();
    }

    private void Search(string name)
    {
        SearchDisplay.Clear();
        _keyword = name;
        _currentPage = new Pageable();
        ServiceHelper.GetService<ISearchService>()?.Search(name, SearchTypeEntry.All, _currentPage)
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    AndroidHelper.ShowToast("Search failed!");
                    return;
                }

                if (!task.IsCompleted) return;
                NotSearchDisplay.IsVisible = false;
                SearchDisplay.IsVisible = true;
                IsLast = task.Result.Last;
                SearchDisplay.Adapter(new SearchAdapter(task.Result.Content.ToArray(), Navigation));
            }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void LoadDataNextPage()
    {
        _currentPage.Page += 1;
        var service = ServiceHelper.GetService<ISearchService>();
        if (service == null) throw new NullPointerException();
        ServiceHelper.GetService<ISearchService>()?.Search(_keyword, SearchTypeEntry.All, _currentPage)
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    AndroidHelper.ShowToast("Search failed!");
                    return;
                }

                if (!task.IsCompleted) return;
                IsLast = task.Result.Last;
                SearchDisplay.IsLoading = false;
                SearchDisplay.AddElement(task.Result.Content.ToArray());
            }, TaskScheduler.FromCurrentSynchronizationContext());
    }
}