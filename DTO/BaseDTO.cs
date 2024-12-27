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

public class ApiPaging<T>
{
    public long TotalItems { get; set; }
    public bool IsLast { get; set; }
    public bool IsFirst { get; set; }
    public long TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int Size { get; set; }
    public List<T> Content { get; set; }
}