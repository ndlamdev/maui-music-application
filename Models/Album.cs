// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 17:09:21 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class Album(long id, string name, string artist, string coverUrl, string type = "", DateTime? releaseDate = null)
{
    public long Id { get; set; } = id;

    public string CoverUrl { get; set; } = coverUrl;

    public string Name { get; set; } = name;

    public string Artist { get; set; } = artist;

    public string Type { get; set; } = type;

    public DateTime ReleaseDate { get; set; } = releaseDate ?? DateTime.Now;
}