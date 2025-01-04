// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 23:12:18 - 31/12/2024
// User: Lam Nguyen

using maui_music_application.Helpers;
using maui_music_application.Views.Pages.Admin;
using MusicCardModel = maui_music_application.Models.MusicCard;

namespace maui_music_application.Views.Fragments;

public partial class SongInfo
{
    public SongInfo()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public event EventHandler<TappedEventArgs>? BackClicked;

    private void Back_OnClicked(object? sender, TappedEventArgs e)
    {
        BackClicked?.Invoke(sender, e);
    }

    public MusicCardModel? Music { get; set; }

    public void SetContext(MusicCardModel musicCard)
    {
        Music = musicCard;
        SongId = musicCard.Id;
        Title = musicCard.Title;
        Artist = musicCard.Artist;
        Cover = musicCard.Cover;
        ArtistView.Title = musicCard.Artist;
        ViewsView.Title = musicCard.Views.ToString();
        GenreView.Title = musicCard.Genre;
        CreateAtView.Title = musicCard.CreatedAt.ToString("u");
        UpdateAtView.Title = musicCard.UpdatedAt.ToString("u");
        OnPropertyChanged(nameof(SongId));
        OnPropertyChanged(nameof(Title));
        OnPropertyChanged(nameof(Artist));
        OnPropertyChanged(nameof(Cover));
    }

    public long SongId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public string Cover { get; set; } = string.Empty;

    private bool IsClick { get; set; }

    private async void ButtonIcon_OnClicked(object? sender, EventArgs e)
    {
        if (IsClick || Music == null) return;
        IsClick = true;
        await OpacityEffect.RunOpacity((View?)sender, 100);
        await Navigation.PushAsync(new EditSongPage(Music));
        IsClick = false;
    }
}