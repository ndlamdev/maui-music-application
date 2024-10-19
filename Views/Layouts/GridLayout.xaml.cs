// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 17:09:36 - 22/09/2024
// User: Lam Nguyen


namespace maui_music_application.Views.Layouts;

public partial class GridLayout
{
    private int _columns = -1;
    private int _rows = -1;
    private int _currentRow, _currentColumn;
    private object? _adapter;
    private ScrollOrientation _orientation = ScrollOrientation.Vertical;

    public GridLayout()
    {
        InitializeComponent();
    }

    public void Adapter<T>(GridLayoutAdapter<T> adapter)
    {
        if (_columns != -1) Rows = (int)Math.Ceiling((double)adapter.ListData.Length / _columns);
        else Columns = (int)Math.Ceiling((double)adapter.ListData.Length / _rows);
        _adapter = adapter;
        LoadContent(adapter);
    }

    public void AddElement<T>(T[] data)
    {
        if (_adapter is not GridLayoutAdapter<T> adapter) return;

        adapter.ListData = adapter.ListData.Concat(data).ToArray();
        if (_orientation == ScrollOrientation.Horizontal)
        {
            var newColumn = (int)Math.Ceiling((double)adapter.ListData.Length / _rows);
            AddColumnDefinitions(newColumn - _columns);
            _columns = newColumn;
        }
        else if (_orientation == ScrollOrientation.Vertical)
        {
            var newRows = (int)Math.Ceiling((double)adapter.ListData.Length / _columns);
            AddRowDefinitions(newRows - _rows);
            _rows = newRows;
        }

        LoadContentAdd(adapter);
    }


    public int Columns
    {
        set
        {
            _columns = value;
            SetUpGrid(_columns, _rows);
        }
    }

    public int Rows
    {
        set
        {
            _rows = value;
            SetUpGrid(_columns, _rows);
        }
    }

    private void LoadContent<T>(GridLayoutAdapter<T> layoutAdapter)
    {
        var data = layoutAdapter.ListData;
        for (; _currentRow < _rows; _currentRow++)
        {
            for (var column = 0; column < _columns; column++)
            {
                var index = _currentRow * _columns + column;
                if (index >= data.Length) return;
                _currentColumn = column;
                var view = layoutAdapter.LoadContentView(index, data[index]);
                Grid.Add(view, column, _currentRow);
            }
        }
    }

    private void LoadContentAdd<T>(GridLayoutAdapter<T> layoutAdapter)
    {
        var temp = _currentColumn == _columns - 1 ? -1 : _currentColumn + 1;
        var data = layoutAdapter.ListData;
        for (; _currentRow < _rows; _currentRow++)
        {
            for (var column = temp != -1 ? temp : 0; column < _columns; column++)
            {
                temp = -1;
                var index = _currentRow * _columns + column;
                if (index >= data.Length) return;
                _currentColumn = column;
                var view = layoutAdapter.LoadContentView(index, data[index]);
                Grid.Add(view, column, _currentRow);
            }
        }
    }

    private void SetUpGrid(int columns, int rows)
    {
        Grid.Children.Clear();
        Grid.ColumnDefinitions.Clear();
        Grid.RowDefinitions.Clear();
        AddColumnDefinitions(columns);
        AddRowDefinitions(rows);
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
        set
        {
            _orientation = value;
            ScrollView.Orientation = value;
        }
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
}

public abstract class GridLayoutAdapter<T>(T[] listData)
{
    public T[] ListData { get; set; } = listData;
    public abstract IView LoadContentView(int position, T data);
}