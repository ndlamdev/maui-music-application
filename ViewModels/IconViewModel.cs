using Microsoft.Maui.Controls.Shapes;

namespace maui_music_application.ViewModels;

public partial class IconViewModel
{
    private Brush _stroke = Brush.Black;
    private PenLineCap _strokeLineCap = PenLineCap.Round;
    private PenLineJoin _strokeLineJoin = PenLineJoin.Round;
    private double _strokeThickness = 1.5;
    private double _widthRequest = 24, _heightRequest = 24;
    private Stretch _aspect = Stretch.Uniform;
    private LayoutOptions _horizontalOptions = LayoutOptions.Start;

    public IconViewModel()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public Brush Stroke
    {
        get => _stroke;
        set
        {
            _stroke = value;
            OnPropertyChanged();
        }
    }

    public PenLineCap StrokeLineCap
    {
        get => _strokeLineCap;
        set
        {
            _strokeLineCap = value;
            OnPropertyChanged();
        }
    }

    public PenLineJoin StrokeLineJoin
    {
        get => _strokeLineJoin;
        set
        {
            _strokeLineJoin = value;
            OnPropertyChanged();
        }
    }

    public double StrokeThickness
    {
        get => _strokeThickness;
        set
        {
            _strokeThickness = value;
            OnPropertyChanged();
        }
    }

    public new double WidthRequest
    {
        get => _widthRequest;
        set
        {
            _widthRequest = value;
            OnPropertyChanged();
        }
    }

    public new double HeightRequest
    {
        get => _heightRequest;
        set
        {
            _heightRequest = value;
            OnPropertyChanged();
        }
    }

    public Stretch Aspect
    {
        get => _aspect;
        set
        {
            _aspect = value;
            OnPropertyChanged();
        }
    }

    public new LayoutOptions HorizontalOptions
    {
        get => _horizontalOptions;
        set
        {
            _horizontalOptions = value;
            OnPropertyChanged();
        }
    }
}
