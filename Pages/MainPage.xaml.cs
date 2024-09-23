namespace maui_music_application.Pages;

public partial class MainPage
{
    int _count;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        _count++;

        if (_count == 1)
            CounterBtn.Text = $"Action {_count} time";
        else
            CounterBtn.Text = $"Action {_count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}