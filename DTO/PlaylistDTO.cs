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
    public string Id { get; set; } = id;
}
