// Author: Lam Nguyen
// Email: ndlam.dev@gmail.com
// Phone number: +84 855354919
// Create at: 06:10:37 - 18/10/2024
// User: Lam Nguyen

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maui_music_application.Helpers;

namespace maui_music_application.Views.Components.Categories;

public partial class RecentListen
{
    private ImageSource? _source;

    public RecentListen()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public ImageSource? Source
    {
        get => _source;
        set
        {
            _source = value;
            OnPropertyChanged();
        }
    }

    private async void OnTapped(object? sender, TappedEventArgs e)
    {
        Action?.Invoke();
        await OpacityEffect.RunOpacity(this, 100);
    }

    public Action? Action { get; set; }
}