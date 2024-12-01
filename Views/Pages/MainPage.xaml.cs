using maui_music_application.Views.Fragments;

namespace maui_music_application.Views.Pages;

public partial class MainPage
{
    private View? _currentView;
    private readonly View[] _views;

    public MainPage()
    {
        _views =
        [
            new HomePage(),
            new ExplorePage(),
            new LibraryPage()
        ];

        InitializeComponent();
        Init();
        Event();
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false
        });
    }

    private void Init()
    {
        Container.Content = _views[0];
    }

    private void Event()
    {
        BottomNavigation.OnClickItem = index => { ChangePage(_views[index]); };
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