namespace MauiTetris;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnStartClicked(object sender, EventArgs e)
	{
        EnterNamePage enterNamePage = new EnterNamePage();
        Navigation.PushAsync(enterNamePage);
    }

    private void OnScoreboardClicked(object sender, EventArgs e)
    {
        ScoreboardPage scoreboardPage = new ScoreboardPage();
        Navigation.PushAsync(scoreboardPage);
    }

    private void OnHowToPlayClicked(object sender, EventArgs e)
    {
        ControlPage controlPage = new ControlPage();
        Navigation.PushAsync(controlPage);
    }
}

