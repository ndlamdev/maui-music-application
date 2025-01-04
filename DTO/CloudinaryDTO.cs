using System.Text.Json.Serialization;

namespace maui_music_application.Dto;

public class RequestCloudinaryUpload
{
    public string FilePath { get; set; }

    public string ApiKey { get; set; }

    public string Folder { get; set; }

    public string PublicId { get; set; }

    public long Timestamp { get; set; }
    public string Signature { get; set; }

    public RequestCloudinaryUpload(string filePath, string apiKey, string folder, string publicId, long timestamp, string signature)
    {
        FilePath = filePath;
        ApiKey = apiKey;
        Folder = folder;
        PublicId = publicId;
        Timestamp = timestamp;
        Signature = signature;
    }

    public override string ToString()
    {
        return $"FilePath {FilePath}, ApiKey {ApiKey}, Folder {Folder}, PublicId {PublicId}, Timestamp {Timestamp}, Signature {Signature}";
    }
}

public class ResponseCloudinaryUpload
{
    [JsonPropertyName("public_id")]
    public string PublicId { get; set; }

    [JsonPropertyName("original_filename")]
    public string NameFile { get; set; }

    [JsonPropertyName("format")]
    public string Format { get; set; }
}