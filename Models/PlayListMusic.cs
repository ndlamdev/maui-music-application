// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 17:09:21 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class PlayListMusic(string id, string title, string image, List<Music>? musics = null)
{
    public string Id { get; set; } = id;

    public string Image { get; set; } = image;

    public string Title { get; set; } = title;

    public List<Music>? Musics { get; set; } = musics;
}