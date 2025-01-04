using Refit;

namespace maui_music_application.Dto;

public class RequestCreateSong
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public string Genre { get; set; }
    public StreamPart FileThumbnail { get; set; }
    public StreamPart FileSource { get; set; }

    public RequestCreateSong(string title, string artist, string album, string genre, StreamPart fileThumbnail, StreamPart fileSource)
    {
        Title = title;
        Artist = artist;
        Album = album;
        Genre = genre;
        FileThumbnail = fileThumbnail;
        FileSource = fileSource;
    }
}