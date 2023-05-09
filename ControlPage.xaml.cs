namespace MauiTetris;

public partial class ControlPage : ContentPage
{
    public ControlPage()
    {
        InitializeComponent();
    }
    private void OnBackButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}