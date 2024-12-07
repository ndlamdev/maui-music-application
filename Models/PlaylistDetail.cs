// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 17:09:21 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class PlaylistDetail()
{
    public PlaylistDetail(string id,
        string title,
        string thumbnail,
        List<Music>? musics = null,
        string type = "",
        TimeSpan? timeCreate = null) : this()
    {
        Id = id;
        Title = title;
        Thumbnail = thumbnail;
        Musics = musics ?? [];
        Type = type;
        TimeCreate = timeCreate ?? DateTime.Now.TimeOfDay;
    }


    public string Id { get; set; }

    public string Thumbnail { get; set; }

    public string Title { get; set; }

    public List<Music>? Musics { get; set; }

    public string Type { get; set; }

    public TimeSpan TimeCreate { get; set; }

    public long TotalSong { get; set; }
}