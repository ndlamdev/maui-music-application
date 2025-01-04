// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 17:09:21 - 22/09/2024
// User: Lam Nguyen

using maui_music_application.Helpers.Enum;

namespace maui_music_application.Models;

public class PlaylistCard
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CoverUrl { get; set; } = "folder_icon.png";
    public int TotalSong { get; set; }
    public TypePlaylist Type { get; set; } = TypePlaylist.Playlist;

    public override bool Equals(object? obj)
    {
        if (obj is PlaylistCard that)
        {
            return Id == that.Id &&
                   Name == that.Name &&
                   CoverUrl == that.CoverUrl &&
                   TotalSong == that.TotalSong &&
                   Type == that.Type;
        }

        return false;
    }

    protected bool Equals(PlaylistCard other)
    {
        return Id == other.Id && Name == other.Name && CoverUrl == other.CoverUrl && TotalSong == other.TotalSong &&
               Type == other.Type;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, CoverUrl, TotalSong, (int)Type);
    }
}