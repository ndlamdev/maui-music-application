// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 08:12:38 - 05/12/2024
// User: Lam Nguyen

using Android.Util;

namespace maui_music_application.Views.Components.Popup;

public partial class ContextMenuPopup
{
    private string[] _menuItems = [];

    public ContextMenuPopup()
    {
        InitializeComponent();
    }

    public void SetPoint(double x, double y)
    {
        FrameX.TranslationX = x;
        FrameY.TranslationY = y;
    }


    public void SetMenuItems(string[] menuItems, Func<string, IView> onRender)
    {
        _menuItems = menuItems;
        MenuContext.Clear();
        foreach (var item in menuItems)
            MenuContext.Add(onRender.Invoke(item));
    }

    public void SetMenuItems(string[] menuItems, Action<object?, TappedEventArgs>[] onClicks)
    {
        if (onClicks.Length != menuItems.Length) throw new Exception("Size menu item and event not equals.");
        _menuItems = menuItems;
        RenderMenuItems(onClicks);
    }

    public void SetMenuItems(string[] menuItems)
    {
        _menuItems = menuItems;
        RenderMenuItems();
    }

    private void RenderMenuItems()
    {
        MenuContext.Clear();
        var index = 0;
        foreach (var item in _menuItems)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => { Log.Info(nameof(ContextMenuPopup), $"Select: {item}!"); };
            var view = new Label
            {
                Text = item,
                TextColor = Colors.Black,
                GestureRecognizers = { tapGestureRecognizer },
            };
            MenuContext.Add(view);

            if (index++ < _menuItems.Length - 1)
                MenuContext.Add(new BoxView
                {
                    HeightRequest = 10,
                });
        }
    }

    private void RenderMenuItems(Action<object?, TappedEventArgs>[] onClicks)
    {
        MenuContext.Clear();
        var index = 0;
        foreach (var item in _menuItems)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += onClicks[index].Invoke;
            var view = new Label
            {
                Text = item,
                TextColor = Colors.Black,
                GestureRecognizers = { tapGestureRecognizer },
            };
            MenuContext.Add(view);

            if (index++ < _menuItems.Length - 1)
                MenuContext.Add(new BoxView
                {
                    HeightRequest = 10,
                });
        }
    }

    private void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        Log.Info(nameof(ContextMenuPopup), "Another click!");
        Close();
    }

    private void TapGestureRecognizer2_OnTapped(object? sender, TappedEventArgs e)
    {
        Log.Info(nameof(ContextMenuPopup), "Another click 2!");
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        Log.Info(nameof(ContextMenuPopup), "Another click 3!");
    }
}