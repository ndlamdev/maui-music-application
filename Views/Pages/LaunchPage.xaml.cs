// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 22:10:39 - 05/10/2024
// User: Lam Nguyen

using maui_music_application.Attributes;
using maui_music_application.Helpers;
using maui_music_application.Services;
using Timer = System.Timers.Timer;

namespace maui_music_application.Views.Pages;

public partial class LaunchPage
{
    public double WidthProcess { get; } = 200;
    public double WidthLineProcess { get; } = 50;
    private Timer? _timer;
    private double _x;
    private bool _ltr = true;


    public LaunchPage()
    {
        InitializeComponent();
        BindingContext = this;
        Loading();
    }

    private void Loading()
    {
        _timer = new Timer();
        _timer.Interval = 1000;
        _timer.Elapsed += (_, _) =>
        {
            if (_ltr)
            {
                Process.TranslateTo(_x += 50, 0, 1000);
                _ltr = _x + WidthLineProcess < WidthProcess;
            }
            else
            {
                Process.TranslateTo(_x -= 50, 0, 1000);
                _ltr = _x <= 0;
            }
        };

        _timer.Enabled = true;
        TodoBeforeRunApplication();
    }

    [Todo("Check some think before run application")]
    private void TodoBeforeRunApplication()
    {
        //..
        TodoAttribute.PrintTask<LaunchPage>();
        if (!Preferences.Get("FIRST_OPEN", false))
        {
            Preferences.Set("FIRST_OPEN", true);
            Navigation.PushAsync(new WelcomePage());
            Navigation.RemovePage(this);
            return;
        }

        var userService = ServiceHelper.GetService<IUserService>();
        if (userService is null)
        {
            Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(this);
            return;
        }

        try
        {
            userService.CheckIfUserHasAccount().ContinueWith(task =>
            {
                if (!task.IsCompleted) return;
                Navigation.PushAsync(task.Result ? new MainPage() : new LoginPage());
                Navigation.RemovePage(this);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        catch (Exception _)
        {
            Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(this);
        }
    }
}