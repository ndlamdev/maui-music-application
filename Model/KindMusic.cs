// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:07 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Model;

public class KindMusic(string id, string title, string image)
{
    public string Id { get; set; } = id;

    public string Title { get; set; } = title;

    public string Image { get; set; } = image;
}