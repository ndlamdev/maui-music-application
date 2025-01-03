using System.Text.Json.Serialization;
using maui_music_application.Helpers.Enum;

namespace maui_music_application.Dto;

public class ResponseSignature
{
    public string Signature { get; set; }
    public string ApiKey { get; set; }
    public long Timestamp { get; set; }
    public string Folder { get; set; }
    public string ResourceType { get; set; }
    public string PublicId { get; set; }
    public string Type { get; set; }
}

public class RequestSignature
{
    [JsonPropertyName("name_file")]
    public string NameFile { get; set; }

    public Tag Tag { get; set; }

    public RequestSignature(string nameFile, Tag tag)
    {
        NameFile = nameFile;
        Tag = tag;
    }
}

public class RequestCreateResource
{
    public string Name { get; set; }

    [JsonPropertyName("public_id")]
    public string PublicId { get; set; }

    Tag Tag { get; set; }
}