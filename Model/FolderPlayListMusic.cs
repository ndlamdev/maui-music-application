// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:07 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Model;

public class FolderPlayListMusic(string id, string title, string subTitle)
    : PlayListMusicLarge(id, title, subTitle, "folder_icon.png")
{
}