// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 14:09:39 - 22/09/2024
// User: Lam Nguyen

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Util;
using maui_music_application.Model;

namespace maui_music_application.Views.Categories;

public partial class PlayListMusicLarge : ContentView
{
    public PlayListMusicLarge()
    {
        InitializeComponent();
    }

    public ImageSource Source
    {
        set => Image.Source = value;
    }

    public string Title
    {
        set => Label.Text = value;
    }
    
    public string SubTitle
    {
        set => SubLabel.Text = value;
    }

    public Action Clicked
    {
        set
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => value?.Invoke();
            Frame.GestureRecognizers.Add(tapGestureRecognizer);
            FrameImage.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}