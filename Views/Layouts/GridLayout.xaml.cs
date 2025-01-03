// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 17:09:36 - 22/09/2024
// User: Lam Nguyen


namespace maui_music_application.Views.Layouts;

public partial class GridLayout
{
    private int _currentRow, _currentColumn;
    private object? _adapter;
    private bool _loading;
    private bool _removeDefinitionLoading;

    private readonly Image _imageLoading = new()
    {
        Source = "loading.gif",
        IsAnimationPlaying = true,
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.Center,
        HeightRequest = 50,
        WidthRequest = 50,
    };

    public GridLayout()
    {
        InitializeComponent();
        _removeDefinitionLoading = true;
        Grid.RowDefinitions.Add(new RowDefinition());
        Grid.Add(_imageLoading);
    }

    public void Adapter<T>(GridLayoutAdapter<T> adapter)
    {
        Grid.RowDefinitions.RemoveAt(Grid.RowDefinitions.Count - 1);
        Grid.Remove(_imageLoading);
        if (Columns != -1) Rows = (int)Math.Ceiling((double)adapter.ListData.Length / Columns);
        else Columns = (int)Math.Ceiling((double)adapter.ListData.Length / Rows);
        SetUpGrid(Columns, Rows);
        _adapter = adapter;
        LoadContent(adapter);
    }

    public void AddElement<T>(T[] data)
    {
        if (_adapter is not GridLayoutAdapter<T> adapter) return;

        adapter.ListData = adapter.ListData.Concat(data).ToArray();
        switch (ScrollView.Orientation)
        {
            case ScrollOrientation.Horizontal:
            {
                var newColumn = (int)Math.Ceiling((double)adapter.ListData.Length / Rows);
                AddColumnDefinitions(newColumn - Columns);
                Columns = newColumn;
                break;
            }
            case ScrollOrientation.Vertical:
            {
                var newRows = (int)Math.Ceiling((double)adapter.ListData.Length / Columns);
                AddRowDefinitions(newRows - Rows);
                Rows = newRows;
                break;
            }
            case ScrollOrientation.Both:
            case ScrollOrientation.Neither:
            default: break;
        }

        LoadContentAdd(adapter);
    }

    public int Size { get; private set; }

    public int Columns { get; set; } = -1;

    public int Rows { get; set; } = -1;

    private void LoadContent<T>(GridLayoutAdapter<T> layoutAdapter)
    {
        var data = layoutAdapter.ListData;
        Size = data.Length;
        for (; _currentRow < Rows; _currentRow++)
        {
            for (var column = 0; column < Columns; column++)
            {
                var index = _currentRow * Columns + column;
                if (index >= data.Length) return;
                _currentColumn = column;
                var view = layoutAdapter.LoadContentView(index, data[index]);
                Grid.Add(view, column, _currentRow);
            }
        }
    }

    private void LoadContentAdd<T>(GridLayoutAdapter<T> layoutAdapter)
    {
        var temp = _currentColumn == Columns - 1 ? -1 : _currentColumn + 1;
        var data = layoutAdapter.ListData;
        Size = data.Length;
        for (; _currentRow < Rows; _currentRow++)
        {
            for (var column = temp != -1 ? temp : 0; column < Columns; column++)
            {
                temp = -1;
                var index = _currentRow * Columns + column;
                if (index >= data.Length) return;
                _currentColumn = column;
                var view = layoutAdapter.LoadContentView(index, data[index]);
                Grid.Add(view, column, _currentRow);
            }
        }
    }

    private void DisplayLoading()
    {
        if (_loading) return;
        _loading = true;
        _removeDefinitionLoading = false;
        switch (ScrollView.Orientation)
        {
            case ScrollOrientation.Horizontal:
            {
                var newColumn = (int)Math.Ceiling((double)(Size + 1) / Rows);
                AddColumnDefinitions(newColumn - Columns);
                if (newColumn - Rows > 0)
                {
                    _removeDefinitionLoading = true;
                    Grid.Add(_imageLoading, _currentColumn + 1, 0);
                }
                else
                    Grid.Add(_imageLoading, _currentColumn, _currentRow == Rows ? 0 : _currentRow + 1);

                break;
            }
            case ScrollOrientation.Vertical:
            {
                var newRows = (int)Math.Ceiling((double)(Size + 1) / Columns);
                AddRowDefinitions(newRows - Rows);
                if (newRows - Rows > 0)
                {
                    _removeDefinitionLoading = true;
                    Grid.Add(_imageLoading, 0, _currentRow + 1);
                }
                else
                    Grid.Add(_imageLoading, _currentColumn == Columns ? 0 : _currentColumn + 1, _currentRow);

                break;
            }
            case ScrollOrientation.Both:
            case ScrollOrientation.Neither:
            default: break;
        }
    }

    private void HiddenLoading()
    {
        _loading = false;
        Grid.Remove(_imageLoading);
        switch (ScrollView.Orientation)
        {
            case ScrollOrientation.Horizontal:
            {
                if (_removeDefinitionLoading)
                    Grid.ColumnDefinitions.RemoveAt(Grid.ColumnDefinitions.Count - 1);
                break;
            }
            case ScrollOrientation.Vertical:
            {
                if (_removeDefinitionLoading)
                    Grid.RowDefinitions.RemoveAt(Grid.RowDefinitions.Count - 1);
                break;
            }
            case ScrollOrientation.Both:
            case ScrollOrientation.Neither:
            default: break;
        }
    }

    private void SetUpGrid(int columns, int rows)
    {
        Grid.Children.Clear();
        Grid.ColumnDefinitions.Clear();
        Grid.RowDefinitions.Clear();
        AddColumnDefinitions(columns);
        AddRowDefinitions(rows);
        _currentColumn = 0;
        _currentRow = 0;
    }

    private void AddColumnDefinitions(int columns)
    {
        for (var i = 0; i < columns; i++)
        {
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
        }
    }

    private void AddRowDefinitions(int rows)
    {
        for (var i = 0; i < rows; i++)
        {
            Grid.RowDefinitions.Add(new RowDefinition());
        }
    }

    public int RowSpacing
    {
        set => Grid.RowSpacing = value;
    }

    public int ColumnSpacing
    {
        set => Grid.ColumnSpacing = value;
    }

    public ScrollOrientation Orientation
    {
        set => ScrollView.Orientation = value;
    }

    private void OnScrollViewScrolled(object? sender, ScrolledEventArgs e)
    {
        if (sender is not ScrollView scrollView) return;
        OnScroll?.Invoke(sender, e);
        if (e.ScrollY >= (scrollView.ContentSize.Height - scrollView.Height))
        {
            OnScrollEnd?.Invoke(sender, e);
        }
    }

    public event EventHandler<ScrolledEventArgs>? OnScrollEnd;
    public event EventHandler<ScrolledEventArgs>? OnScroll;

    public T[] GetData<T>()
    {
        return _adapter is not GridLayoutAdapter<T> adapter ? [] : adapter.ListData;
    }

    public bool IsLoading
    {
        get => _loading;
        set
        {
            if (value)
                DisplayLoading();
            else
                HiddenLoading();
        }
    }
}

public abstract class GridLayoutAdapter<T>(T[] listData)
{
    public T[] ListData { get; set; } = listData;
    public abstract IView LoadContentView(int position, T data);
}