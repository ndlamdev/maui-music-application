// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 14:09:23 - 24/09/2024
// User: Lam Nguyen

using maui_music_application.Helpers;

namespace maui_music_application.Views.Components.Navigation;

public partial class BottomNavigationItem
{
    private string _icon = "";
    private bool _selected;
    private Color _colorSelected = Colors.White, _colorUnselected = Colors.White;

    public BottomNavigationItem()
    {
        InitializeComponent();
    }

    public string Icon
    {
        set
        {
            _icon = value;
            ImageIcon.Source = value;
        }
    }

    public string Title
    {
        set => Label.Text = value;
    }

    public bool Selected
    {
        get => _selected;
        set
        {
            _selected = value;
            ImageIcon.Source = value ? GetIconSelected() : _icon;
            Label.TextColor = value ? _colorSelected : _colorUnselected;
        }
    }

    private string GetIconSelected()
    {
        var paths = _icon.Split(".");
        return paths.Length == 1 ? $"{paths[0]}_selected" : $"{paths[0]}_selected.{paths[1]}";
    }

    public Color ColorSelected
    {
        set
        {
            _colorSelected = value;
            Selected = _selected;
        }
    }

    public Color ColorUnselected
    {
        set
        {
            _colorUnselected = value;
            Selected = _selected;
        }
    }

    public Action Action
    {
        set
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (_, _) =>
            {
                value.Invoke();
                await OpacityEffect.RunOpacity(this, 100);
            };

            RootView.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}