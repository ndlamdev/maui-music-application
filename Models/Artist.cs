// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 08:10:25 - 21/10/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class Artist(long id, string avatar, string name, TimeSpan? timeCreate = null)
{
    public long Id { get; set; } = id;
    public string Avatar { get; set; } = avatar;
    public string Name { get; set; } = name;
    public TimeSpan? TimeCreate { get; set; } = timeCreate;
}