// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 07:09:36 - 23/09/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class TopMixes(string id, string title, string thumbnail, TimeSpan? timeCreate = null)
    : PlaylistDetail(id, title, thumbnail, timeCreate: timeCreate)
{
}