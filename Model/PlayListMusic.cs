// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 17:09:21 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Model;

public class PlayListMusic(string id, string title, ImageSource image)
{
    public string Id { get; set; } = id;

    public ImageSource Image { get; set; } = image;

    public string Title { get; set; } = title;
}