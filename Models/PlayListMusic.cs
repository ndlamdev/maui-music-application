// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 17:09:21 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class PlayListMusic(string id, string title, string thumbnail, List<Music>? musics = null, string type = "")
{
    public string Id { get; set; } = id;

    public string Thumbnail { get; set; } = thumbnail;

    public string Title { get; set; } = title;

    public List<Music>? Musics { get; set; } = musics;

    public string Type { get; set; } = type;
}