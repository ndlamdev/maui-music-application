using Java.Sql;

namespace maui_music_application.Dto;

public class ResponseAlbumCard
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public string Artist { get; set; }
    public string Cover { get; set; }
    public DateTime ReleaseDate { get; set; }
}