// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 20:09:11 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Views.Components.Musics;

public partial class Process
{
    private double _timeEndProgress;
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
            if (value > _timeEndProgress) return;
            _timeProgress = value;
            var process = value / _timeEndProgress;
            OnPropertyChanged(nameof(TextTimeProcess));
            ProgressBar.ProgressTo(process, 500, Easing.SinInOut);
            DotProgressBard.TranslateTo((_width - PaddingProcess) * process - SizeDot, -12, 500, Easing.SinInOut);
        }
    }

    public double TimeEndProgress
    {
        set
        {
            _timeEndProgress = value;
            TimeEndProgressLabel.Text = FormatTime(value);
        }
    }

    private string FormatTime(double time)
    {
        var ts = TimeSpan.FromSeconds(time);
        return ts.ToString(@"mm\:ss");
    }

    public string TextTimeProcess => FormatTime(_timeProgress);

    private void Layout_OnSizeChanged(object? sender, EventArgs e)
    {
        if (sender == null) return;
        if (sender is VerticalStackLayout layout) _width = layout.Width;
        TimeProgress = _timeProgress;
    }
}