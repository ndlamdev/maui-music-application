// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 10:10:13 - 18/10/2024
// User: Lam Nguyen

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace maui_music_application.Views.Components.Form;

public partial class Search
{
    private string _placeholder = "Songs, Artists, Podcasts & More";

    public Search()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public string Placeholder
    {
        get => _placeholder;
        set
        {
            _placeholder = value;
            OnPropertyChanged();
        }
    }

    private string Text => Entry.Text;

    private void InputView_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        TextChanged?.Invoke(sender, e);
    }

    public event EventHandler<TextChangedEventArgs>? TextChanged;
}