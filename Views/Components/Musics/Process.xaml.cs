// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 20:09:11 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Views.Components.Musics;

public partial class Process
{
    private double _duration;
    private double _width;
    private double _timeProgress;
    private const int PaddingProcess = 16;
    private const int SizeDot = 12;


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
            var process = value / _duration;
            OnPropertyChanged(nameof(TextTimeProcess));
            ProgressBar.ProgressTo(process, 500, Easing.SinInOut);
            DotProgressBard.TranslateTo((_width - PaddingProcess) * process - SizeDot, -12, 500, Easing.SinInOut);
            OnPropertyChanged(nameof(TextTimeProcess));
        }
    }

    public double Duration
    {
        set
        {
            _duration = value;
            TimeEndProgressLabel.Text = FormatTime(value);
            OnPropertyChanged(nameof(TextDuration));
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
        TimeProgress = _timeProgress;
    }
}
