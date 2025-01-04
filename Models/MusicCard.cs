// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:40 - 23/09/2024
// User: Lam Nguyen

using System.Numerics;

namespace maui_music_application.Models;

public class MusicCard(long id, string title, string artist, string cover)
{
    public long Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Artist { get; set; } = artist;
    public string Cover { get; set; } = cover;
    public string Genre { get; set; } = string.Empty;
    public BigInteger Views { get; set; } = 0;
    public long Duration { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public override string ToString()
    {
        return $"Id = {Id}, Title = {Title}, Artist = {Artist}, Cover = {Cover}";
    }
}