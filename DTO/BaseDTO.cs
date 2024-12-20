namespace maui_music_application.Dto;

public class APIResponse<T>
{
    public int StatusCode { get; set; } = 400;
    public string Error { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; }
}

public class APIResponse
{
    public int StatusCode { get; set; } = 400;
    public string Error { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}