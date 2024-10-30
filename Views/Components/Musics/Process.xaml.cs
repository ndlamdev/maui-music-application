// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 20:09:11 - 22/09/2024
// User: Lam Nguyen

using Android.Util;

namespace maui_music_application.Views.Components.Musics;

public partial class Process
{
    private double _duration;
    private double _width;
    private double _timeProgress;
    public event EventHandler<double>? OnValueChangeCompleted;
    private bool _drag;
    private double _newValue;

    public Process()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public double TimeProgress
    {
        get => _timeProgress;
        set
        {
            if (value > _duration) return;
            _timeProgress = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TextTimeProcess));
        }
    }

    public double Duration
    {
        get => _duration;
        set
        {
            _duration = value;
            TimeEndProgressLabel.Text = FormatTime(value);
            OnPropertyChanged(nameof(TextDuration));
            OnPropertyChanged();
        }
    }

    private static string FormatTime(double time)
    {
        var ts = TimeSpan.FromSeconds(time);
        return ts.ToString(@"mm\:ss");
    }

    public string TextTimeProcess => FormatTime(_timeProgress);
    public string TextDuration => FormatTime(_duration);

    private void Layout_OnSizeChanged(object? sender, EventArgs e)
    {
        if (sender == null) return;
        if (sender is VerticalStackLayout layout) _width = layout.Width;
        ProcessBar.WidthRequest = _width / 1.37;
        TimeProgress = _timeProgress;
    }

    private void Process_OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        if (!_drag)
            return;
        _newValue = e.NewValue;
        TimeProgress = e.NewValue;
        OnValueChanged?.Invoke(sender, e);
    }

    public event EventHandler<ValueChangedEventArgs>? OnValueChanged;

    private void ProcessBar_OnDragCompleted(object? sender, EventArgs e)
    {
        _drag = false;
        OnValueChangeCompleted?.Invoke(sender, _newValue);
    }

    private void ProcessBar_OnDragStarted(object? sender, EventArgs e)
    {
        _drag = true;
    }
}