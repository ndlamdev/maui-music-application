// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 08:12:38 - 05/12/2024
// User: Lam Nguyen

namespace maui_music_application.Views.Components.Popup;

public partial class ContextMenuPopup
{
    public ContextMenuPopup()
    {
        InitializeComponent();
    }
    
    public void SetAnchor(double x, double y)
    {
        Menu.AnchorX = x;
        Menu.AnchorY = y;
    }
}