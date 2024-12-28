// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 10:12:23 - 28/12/2024
// User: Lam Nguyen

using Android.Util;

namespace maui_music_application.Helpers;

using System;
using System.Threading;
using System.Threading.Tasks;

public class Debouncer
{
    private CancellationTokenSource _cancellationTokenSource;

    public async void UseDebounced(Action action, int delayMilliseconds)
    {
        try
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            var token = _cancellationTokenSource.Token;

            await Task.Delay(delayMilliseconds, token);
            if (!token.IsCancellationRequested)
            {
                action.Invoke();
            }
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}