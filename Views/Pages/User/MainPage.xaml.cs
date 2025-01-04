using Android.Util;
using maui_music_application.Helpers;
using maui_music_application.Services;
using maui_music_application.Views.Fragments;

namespace maui_music_application.Views.Pages.User;

public partial class MainPage
{
    private View? _currentView;
    private View[] _views = [];
    private int _currentFrame = 0;
    private IAudioPlayerService? AudioService { get; set; }

    public MainPage()
    {
        InitializeComponent();
        Init();
        Event();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (_views[_currentFrame] is LibraryPage page)
        {
            page.Reload();
        }

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
    }


    private void Init()
    {
        _views =
        [
            new HomePage(this),
            new ExplorePage(),
            new LibraryPage()
        ];
        Container.Content = _views[0];
        AudioService = ServiceHelper.GetService<IAudioPlayerService>();
    }

    private void Event()
    {
        BottomNavigation.OnClickItem = index =>
        {
            ChangePage(_views[index]);
            _currentFrame = index;
        };
        if (AudioService == null) return;
        AudioService.StateChanged += _ =>
        {
            if (AudioService.CurrentMusic == null)
                BottomNavigation.TranslationY = 20;
            else
                BottomNavigation.TranslationY = -50;
        };
    }

    private async void ChangePage(View view)
    {
        if (view == _currentView) return;
        _currentView = view;
        Container.Content = view;
        await _currentView.TranslateTo(200, 0, 0);
        await _currentView.TranslateTo(0, 0, 200, Easing.SinOut);
    }
}