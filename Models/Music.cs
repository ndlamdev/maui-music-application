namespace maui_music_application.Models;

public class Music(
    long id,
    string title,
    string artist,
    string cover,
    string url,
    string genre,
    bool like = false) : MusicCard(id, title, artist, cover)
{
    public string Url { get; set; } = url;
    public string Genre { get; set; } = genre;
    public bool Like { get; set; } = like;
}