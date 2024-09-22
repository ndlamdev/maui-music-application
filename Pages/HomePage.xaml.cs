// Author: Nguyen Dinh Lam
// Email: kiminonawa1305@gmail.com
// Phone number: +84 855354919
// Create at: 09:09:07 - 21/09/2024
// User: Lam Nguyen

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_music_application.Pages;

public partial class HomePage : ContentPage
{
    int count = 0;

    public HomePage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CountClick.Text = $"Clicked {count} time";
        else
            CountClick.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CountClick.Text);
    }
}