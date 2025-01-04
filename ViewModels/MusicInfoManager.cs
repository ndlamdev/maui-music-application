// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 00:01:57 - 01/01/2025
// User: Lam Nguyen

using System.Numerics;
using maui_music_application.Models;

namespace maui_music_application.ViewModels;

public class MusicInfoManager(
    long id,
    string title,
    string artist,
    string cover,
    string url,
    string genre) : MusicCard(id, title, artist, cover)
{
    public string Url { get; set; } = url;
    public string Genre { get; set; } = genre;
    public BigInteger Views { get; set; }
    public long Duration { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}