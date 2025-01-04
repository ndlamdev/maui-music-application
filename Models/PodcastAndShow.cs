// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 17:09:21 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class PodcastAndShow(
    string id,
    string title,
    string author,
    string thumbnail,
    string type = "",
    TimeSpan? timeCreate = null)
{
    public string Id { get; set; } = id;

    public string Thumbnail { get; set; } = thumbnail;

    public string Title { get; set; } = title;

    public string Author { get; set; } = author;

    public string Type { get; set; } = type;

    public TimeSpan TimeCreate { get; set; } = timeCreate ?? DateTime.Now.TimeOfDay;
}