// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 20:12:51 - 25/12/2024
// User: Lam Nguyen

using CommunityToolkit.Maui.Views;
using maui_music_application.Dto;
using maui_music_application.Helpers;
using maui_music_application.Helpers.Validation;
using maui_music_application.Models;
using maui_music_application.Services;
using maui_music_application.Views.Components.Popup;

namespace maui_music_application.ViewModels;

public class CreatePlayListViewModel(Page page, bool validateOnChanged) : AObservableValidator(validateOnChanged)
{
    private string _name = string.Empty;

    [NotBlank(ErrorMessage = "Vui lòng nhập trên playlist.")]
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value, true);
    }

    public bool IsPublic { get; set; }

    public void OnSubmit(Func<Task> callback)
    {
        ValidateAllProperties();
        if (HasErrors)
            return;
        var service = ServiceHelper.GetService<IPlaylistService>();
        var popup = LoadingPopup.GetInstance();
        if (service == null) return;
        page.ShowPopup(popup);
        service.CreatePlaylist(new RequestCreatePlaylist(Name, "", IsPublic)).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                popup.Close();
                ShowToastErrorHelper.ShowToast<CreatePlayListViewModel, ResponseCreatePlaylist>(task, popup,
                    "Sign up failed: ");
                return;
            }

            if (!task.IsCompleted) return;
            popup.Close();
            callback.Invoke().RunSynchronously();
            AndroidHelper.ShowToast(task.Result.Message);
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
}