// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 22:10:39 - 05/10/2024
// User: Lam Nguyen

using Android.Text.Format;
using Android.Util;
using maui_music_application.Attributes;
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
    private async void TodoBeforeRunApplication()
    {
        TodoAttribute.PrintTask<LaunchPage>();

        await Task.Delay(5000);
        _timer.Enabled = false;
        await Navigation.PushAsync(new WelcomePage());
    }
}