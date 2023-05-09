namespace MauiTetris;

public partial class EnterNamePage : ContentPage
{
	public EnterNamePage()
	{
		InitializeComponent();
	}

	private void OnSubmitClicked(object sender, EventArgs e)
	{
        string name = nameEntry.Text;

        if (string.IsNullOrEmpty(name))
        {
            DisplayAlert("Error", "Please enter a name.", "OK");
            return;
        }

        Navigation.PopAsync();
        using var game = new Tetris.TetrisGame(name);
        game.Run();
    }

    private void OnBackButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}