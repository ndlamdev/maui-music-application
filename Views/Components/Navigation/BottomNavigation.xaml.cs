// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 13:09:02 - 24/09/2024
// User: Lam Nguyen

namespace maui_music_application.Views.Components.Navigation;

public partial class BottomNavigation
{
    private readonly bool[] _selected = [true, false, false];
    private readonly string[] _nameItems = ["ItemHome", "ItemExplore", "ItemLibrary"];

    public BottomNavigation()
    {
        InitializeComponent();
        Event();
    }

    public int IconSelected
    {
        set => SelectItem(value);
    }

    private void SelectItem(int index)
    {
        OnClickItem?.Invoke(index);
        for (var i = 0; i < _selected.Length; i++)
        {
            var selected = i == index;
            var item = FindButtonNavigationItemByIndex(i);
            _selected[i] = selected;
            item.Selected = selected;
            try
            {
                item.TranslateTo(0, selected ? -10 : 0, 200, Easing.SinInOut);
            }
            catch (Exception)
            {
                item.TranslationY = selected ? -10 : 0;
            }
        }
    }

    private BottomNavigationItem FindButtonNavigationItemByIndex(int index)
    {
        return (BottomNavigationItem)FindByName(_nameItems[index]);
    }


    private void Event()
    {
        ItemHome.Action = () => { SelectItem(0); };
        ItemExplore.Action = () => { SelectItem(1); };
        ItemLibrary.Action = () => { SelectItem(2); };
    }

    public Action<int>? OnClickItem { get; set; }
}