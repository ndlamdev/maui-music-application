namespace maui_music_application.Helpers;

public class ApiPaging<T>
// (
//     long totalItems,
//     bool isLast,
//     bool isFirst,
//     long totalPages,
//     int currentPage,
//     int size,
//     List<T> content)
{
    // public long TotalItems { get; } = totalItems;
    // public bool IsLast { get; } = isLast;
    // public bool IsFirst { get; } = isFirst;
    // public long TotalPages { get; } = totalPages;
    // public int CurrentPage { get; } = currentPage;
    // public int Size { get; } = size;
    // public List<T> Content { get; } = content;

    public long TotalItems { get; set; }
    public bool IsLast { get; set; }
    public bool IsFirst { get; set; }
    public long TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int Size { get; set; }
    public List<T> Content { get; set; }
}