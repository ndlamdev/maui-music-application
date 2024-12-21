// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:29 - 23/09/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class MusicCardInTop(long id, string title, string artist, string cover, int top)
    : MusicCard(id, title, artist, cover)
{
    public int Top { get; set; } = top;
}