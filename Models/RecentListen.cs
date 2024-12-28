// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 06:10:22 - 18/10/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class RecentListen(long id, string thumbnail)
{
    public long Id { get; set; } = id;
    public string Thumbnail { get; set; } = thumbnail;
}