﻿namespace maui_music_application.Pages;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Action {count} time";
        else
            CounterBtn.Text = $"Action {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}