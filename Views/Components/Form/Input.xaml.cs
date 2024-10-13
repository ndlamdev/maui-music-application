namespace maui_music_application.Views.Components.Form;

public partial class Input
{
    private string _placeholder = "", _text = "";
    private ImageSource? _iconLeft, _iconRight;
    private Thickness _marginEntry = new(0);
    private bool _isPassword, _showPassword = true;
    private double _size = 16;
    private const string IconShowPassword = "eye_opened.svg", IconHidePassword = "eye_closed.svg";

    public Input()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void IconLeftTapped(object? sender, TappedEventArgs e)
    {
        IconLeftEvent?.Invoke(sender, e);
    }


    private void IconRightTapped(object? sender, TappedEventArgs e)
    {
        IconRightEvent?.Invoke(sender, e);
    }


    public ImageSource? IconLeft
    {
        get => _iconLeft;
        set
        {
            ImageIconLeft.WidthRequest = 20;
            _iconLeft = value;
            MarginEntry = MarginEntry with { Left = 5 };
            OnPropertyChanged();
        }
    }

    public ImageSource? IconRight
    {
        get => _iconRight;
        set
        {
            ImageIconRight.WidthRequest = 35;
            _iconRight = value;
            OnPropertyChanged();
        }
    }

    public Thickness MarginEntry
    {
        get => _marginEntry;
        set
        {
            _marginEntry = value;
            OnPropertyChanged();
        }
    }

    public event EventHandler<TappedEventArgs>? IconLeftEvent;
    public event EventHandler<TappedEventArgs>? IconRightEvent;
    public event EventHandler<TextChangedEventArgs>? TextChangeEvent;

    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChanged();
        }
    }

    public string Placeholder
    {
        get => _placeholder;
        set
        {
            _placeholder = value;
            OnPropertyChanged();
        }
    }

    public bool IsPassword
    {
        get => _isPassword;
        set
        {
            _isPassword = value;
            if (!IsPassword) return;
            IconRightEvent += (_, _) => ShowPassword = !_showPassword;
            ShowPassword = false;
        }
    }

    public bool ShowPassword
    {
        get => !_showPassword;
        set
        {
            if (!IsPassword) return;
            _showPassword = value;
            IconRight = ShowPassword ? IconHidePassword : IconShowPassword;
            OnPropertyChanged();
        }
    }

    public double FontSize
    {
        get => _size;
        set
        {
            _size = value;
            OnPropertyChanged();
        }
    }

    private void InputView_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        TextChangeEvent?.Invoke(this, e);
    }

    public void Focus(bool focus)
    {
        if (focus) InputEntry.Focus();
        else InputEntry.Unfocus();
    }
}
