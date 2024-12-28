// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:36 - 23/09/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class TopMixes
    : PlaylistDetail
{
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
}