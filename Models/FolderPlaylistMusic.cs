// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 15:09:07 - 22/09/2024
// User: Lam Nguyen

namespace maui_music_application.Models;

public class FolderPlaylistMusic(string id, string title, List<PlaylistMusic> playlists, TimeSpan? timeCreate = null)
{
    public string Id { get; set; } = id;
    public string Title { get; set; } = title;
    public List<PlaylistMusic> Playlists { get; set; } = playlists;
    public TimeSpan TimeCreate { get; set; } = timeCreate ?? DateTime.Now.TimeOfDay;
    public string Thumbnail => "folder_icon.png";
}