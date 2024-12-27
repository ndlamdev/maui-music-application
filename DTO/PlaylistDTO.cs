using maui_music_application.Helpers;
using maui_music_application.Models;

namespace maui_music_application.Dto;

public class RequestCreatePlaylist(
    string name,
    string description,
    bool isPublic)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public bool IsPublic { get; set; } = isPublic;
}

public class ResponseCreatePlaylist(
    string id,
    string name,
    string description,
    bool isPublic) : RequestCreatePlaylist(name, description, isPublic)
{
    public string ID { get; set; } = id;
}

public class ResponsePlaylistCard
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CoverUrl { get; set; } = "folder_icon.png";
    public int TotalSong { get; set; }
    public bool IsAlbum { get; set; } = false;
}

public class ResponsePlaylistDetail : ResponsePlaylistCard
{
    public ApiPaging<MusicCard> Songs { get; set; }
}