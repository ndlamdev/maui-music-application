using Android.Util;
using CommunityToolkit.Maui.Views;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Enum;
using maui_music_application.Services;
using maui_music_application.ViewModels;
using maui_music_application.Views.Components.Popup;
using maui_music_application.Views.Pages.Admin;
using maui_music_application.Views.Pages.User;

namespace maui_music_application.Views.Components.Header;

public partial class Header
{
    private bool _isSelected;

    public Header()
    {
        InitializeComponent();
        BindingContext = new HeaderViewModel();
    }

    private void Top_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new RankPage());
    }

    public Page Page { get; set; }

    private async void Setting_OnClicked(object? sender, TappedEventArgs e)
    {
        IUserService userService = ServiceHelper.GetService<IUserService>();
        await OpacityEffect.RunOpacity((View)sender, 100);
        var contextMenuPopup = new ContextMenuPopup();
        Role role = await userService.GetRole();
        if (role != null & role == Role.ADMIN)
        {
            contextMenuPopup.SetMenuItems(["Admin", "Logout"],
            [
                (_, _) => NavAdmin(),
                (_, _) => Logout()
            ]);
        }
        else
        {
            contextMenuPopup.SetMenuItems(["Admin", "Logout"],
            [

                (_, _) => Logout()
            ]);
        }
        contextMenuPopup.SetPoint(e.GetPosition(Page)?.X - 100 ?? 0, e.GetPosition(Page)?.Y + 10 ?? 0);
        Page.ShowPopup(contextMenuPopup);
    }

    private async void Logout()
    {
        try
        {
            var userService = ServiceHelper.GetService<IUserService>();
            if (userService == null || _isSelected) return;
            _isSelected = true;
            await userService.Logout();
            await Navigation.PushAsync(new LoginPage(), true);
            _isSelected = false;
        }
        catch (Exception exception)
        {
            AndroidHelper.ShowToast(exception.Message);
        }
    }

    private async void NavAdmin()
    {
        await Navigation.PushAsync(new SongManagerPage());
    }
}