// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 17:09:36 - 22/09/2024
// User: Lam Nguyen


using Android.Util;
using Java.Lang;

namespace maui_music_application.Views.Custom_Components;

public partial class GridLayout
{
    private int _columns = 1;
    private int _rows = 1;

    public GridLayout()
    {
        InitializeComponent();
        SetUpGrid(_columns, _rows);
    }

    public void LayoutAdapter<T>(GridLayoutAdapter<T> value)
    {
        LoadContent(value);
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
        for (var row = 0; row < _rows; row++)
        {
            for (var column = 0; column < _columns; column++)
            {
                var index = row * _columns + column;
                IView view = layoutAdapter.LoadContentView(data[index]);
                Grid.Add(view, column, row);
            }
        }
    }

    private void SetUpGrid(int columns, int rows)
    {
        Grid.Clear();
        Grid.ColumnDefinitions.Clear();
        Grid.RowDefinitions.Clear();
        for (int i = 0; i < columns; i++)
        {
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        for (int i = 0; i < rows; i++)
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
}

public abstract class GridLayoutAdapter<T>(T[] listData)
{
    public T[] ListData { get; set; } = listData;
    public abstract IView LoadContentView(T data);
}