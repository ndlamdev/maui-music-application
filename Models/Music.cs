// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:40 - 23/09/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class Music(string id, string name, string signer, string thumbnail)
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Signer { get; set; } = signer;
    public string Thumbnail { get; set; } = thumbnail;
}