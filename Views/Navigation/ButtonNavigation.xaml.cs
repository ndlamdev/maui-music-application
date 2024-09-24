// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 13:09:02 - 24/09/2024
// User: Lam Nguyen

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_music_application.Views.Navigation;

public partial class ButtonNavigation : ContentView
{
    private readonly bool[] _selected = [true, false, false];
    private readonly string[] _nameItems = ["ItemHome", "ItemExplore", "ItemLibrary"];

    public ButtonNavigation()
    {
        InitializeComponent();
        Event();
    }

    public int IconSelected
    {
        get => Array.IndexOf(_selected, true);
        set => SelectItem(value);
    }

    private void SelectItem(int index)
    {
        for (var i = 0; i < _selected.Length; i++)
        {
            var selected = i == index;
            var item = FindButtonNavigationItemByIndex(i);
            _selected[i] = selected;
            // item.Selected = selected;
            // item.TranslateTo(0, selected ? -10 : 0, 200, Easing.SinInOut);
        }
    }

    private ButtonNavigationItem FindButtonNavigationItemByIndex(int index)
    {
        return (ButtonNavigationItem)FindByName(_nameItems[index]);
    }


    private void Event()
    {
        ItemHome.Action = () => { SelectItem(0); };
        ItemExplore.Action = () => { SelectItem(1); };
        ItemLibrary.Action = () => { SelectItem(2); };
    }
}