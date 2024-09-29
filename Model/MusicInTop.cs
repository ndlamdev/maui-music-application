// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:29 - 23/09/2024
// User: Lam Nguyen

namespace maui_music_application.Model;

public class MusicInTop(string id, string name, string signer, string thumbnail, int top)
    : Music(id, name, signer, thumbnail)
{
    public int Top { get; set; } = top;
}