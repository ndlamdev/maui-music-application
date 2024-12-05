namespace maui_music_application.Dto;

public class APIResponse<T>
{
    public int StatusCode { get; set; }
    public string Error { get; set; }
    public Object Message { get; set; }
    public T Data { get; set; }
}

public class APIResponse
{
    public int StatusCode { get; set; }
    public string Error { get; set; }
    public Object Message { get; set; }
}