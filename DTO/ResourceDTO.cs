using System.Text.Json.Serialization;
using maui_music_application.Helpers.Enum;
using Newtonsoft.Json;

namespace maui_music_application.Dto;

public class ResponseSignature
{
    public string Signature { get; set; }
    [JsonProperty("api_key")]
    public string ApiKey { get; set; }
    public long Timestamp { get; set; }
    public string Folder { get; set; }
    public string ResourceType { get; set; }
    public string PublicId { get; set; }
    public string Type { get; set; }
}

public class RequestSignature(string nameFile, Tag tag)
{
    [JsonProperty("name_file")]
    public string NameFile { get; set; } = nameFile;

    public Tag Tag { get; set; } = tag;

}

public class RequestCreateResource
{
    public string Name { get; set; }

    [JsonProperty("public_id")]
    public string PublicId { get; set; }

    Tag Tag { get; set; }
}