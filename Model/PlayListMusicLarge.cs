// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:07 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Model;

public class PlayListMusicLarge(string id, string title, string subTitle, ImageSource image)
    : KindMusic(id, title, image)
{
    public string SubTitle { get; set; } = subTitle;
}