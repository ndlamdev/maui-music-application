// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 14:12:38 - 28/12/2024
// User: Lam Nguyen

using maui_music_application.Dto;

namespace maui_music_application.Models;

public class PlaylistDetail : PlaylistCard
{
    public ApiPaging<MusicCard> Songs { get; set; }
}