using maui_music_application.Helpers.Enum;

namespace maui_music_application.Models;

public class ResourceApp
{
    public ResourceApp(string name, string filePath, Tag tag)
    {
        Name = name;
        FilePath = filePath;
        Tag = tag;
    }

    public string Name { get; set; }
    public string FilePath { get; set; }
    public Tag Tag { get; set; }
}