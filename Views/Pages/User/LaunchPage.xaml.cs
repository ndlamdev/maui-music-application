// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 22:10:39 - 05/10/2024
// User: Lam Nguyen

using Android.Util;
using maui_music_application.Attributes;
using maui_music_application.Helpers;
using maui_music_application.Services;
using maui_music_application.Services.Api;
using Timer = System.Timers.Timer;

namespace maui_music_application.Views.Pages.User;

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
        _ = LoadingAsync();
    }

    private async Task LoadingAsync()
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
        await TodoBeforeRunApplication();
    }

    private async Task
        TodoBeforeRunApplication()
    {
        Log.Info("LaunchPage", "Join Application");
        Log.Info("LaunchPage", "Go first {0}", Preferences.Get("FIRST_OPEN", false));
        TodoAttribute.PrintTask<LaunchPage>();
        if (!Preferences.Get("FIRST_OPEN", false))
        {
            Preferences.Set("FIRST_OPEN", true);
            await Navigation.PushAsync(new WelcomePage());
            // for (var i = 0; i < Navigation.NavigationStack.Count - 1; i++)
            //     Navigation.RemovePage(Navigation.NavigationStack[i]);
            return;
        }

        // Kiểm tra server còn sống không?
        bool isServerAlive = await IsServerAlive();
        Log.Info("LaunchPage", $"Join Application IsAlive = {isServerAlive}");
        if (isServerAlive)
        {
            await HandleNavigate();
        }
        else
        {
            await Navigation.PushAsync(new LoginPage());
            // for (var i = 0; i < Navigation.NavigationStack.Count - 1; i++)
            //     Navigation.RemovePage(Navigation.NavigationStack[i]);
            AndroidHelper.ShowToast("Server đang trong thời gian bảo trì, vui lòng truy cập app sau!");
        }
    }

    private async Task HandleNavigate()
    {
        var userService = ServiceHelper.GetService<IUserService>();
        if (userService is null)
        {
            await Navigation.PushAsync(new LoginPage());
            // for (var i = 0; i < Navigation.NavigationStack.Count - 1; i++)
            //     Navigation.RemovePage(Navigation.NavigationStack[i]);
            return;
        }

        var cts = new CancellationTokenSource();
        Log.Info("LaunchPage", "Check user login before run application");
        try
        {
            await userService.CheckIfUserHasAccount();
            await Navigation.PushAsync(new MainPage());
            // for (var i = 0; i < Navigation.NavigationStack.Count - 1; i++)
            //     Navigation.RemovePage(Navigation.NavigationStack[i]);
        }
        catch (Exception ex)
        {
            // Call Api thất bại 
            Log.Info("LaunchPage", "Expired Token: {0} {1}", ex.Message, ex.StackTrace);
            await Navigation.PushAsync(new LoginPage());
            // for (var i = 0; i < Navigation.NavigationStack.Count - 1; i++)
            //     Navigation.RemovePage(Navigation.NavigationStack[i]);
            AndroidHelper.ShowToast("Token hết hạn, vui lòng đăng nhập lại");
        }
    }

    private async Task<bool> IsServerAlive()
    {
        IServerApi api = ServiceHelper.GetService<IServerApi>();
        try
        {
            await api.Status();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}