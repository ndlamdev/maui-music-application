namespace maui_music_application.Helpers;

public class Pageable(int page = 0, int size = 10, List<SortItem>? sort = null)
{
    public int Page { get; set; } = page;
    public int Size { get; set; } = size;
    public List<SortItem> Sort { get; set; } = sort ?? [];
}

public class SortItem(string field, Sort sort)
{
    public override string ToString()
    {
        return $"{field},{sort}";
    }
}

public enum Sort
{
    ASC,
    DESC
}