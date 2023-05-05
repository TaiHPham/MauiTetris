namespace MauiTetris;

using Microsoft.Maui.Controls;
using System.IO;
using System.Text.Json;

public partial class ScoreboardPage : ContentPage
{
    private List<LeaderboardEntry> leaderboardEntries;

    public ScoreboardPage()
    {
        InitializeComponent();
        LoadLeaderboard();
    }

    private async void LoadLeaderboard()
    {
        string filePath = @"C:\Univ of South Miss\317\317-Tetris-Page-V2\Tetris\leaderboard.json";

        string json = await File.ReadAllTextAsync(filePath);
        leaderboardEntries = JsonSerializer.Deserialize<List<LeaderboardEntry>>(json);

        // Sort the leaderboard entries by score in descending order
        leaderboardEntries.Sort((entry1, entry2) => entry2.Score.CompareTo(entry1.Score));

        // Only keep the top 10 entries
        leaderboardEntries = leaderboardEntries.Take(10).ToList();

        UpdateLeaderboardUI();
    }

    private void UpdateLeaderboardUI()
    {
        // Remove the existing rows from the table
        LeaderboardGrid.Children.Clear();

        // Add the new rows to the table
        for (int i = 0; i < leaderboardEntries.Count; i++)
        {
            var rankLabel = new Label { Text = (i + 1).ToString(), FontSize = 18 };
            var nameLabel = new Label { Text = leaderboardEntries[i].Name, FontSize = 18 };
            var scoreLabel = new Label { Text = leaderboardEntries[i].Score.ToString(), FontSize = 18 };

            LeaderboardGrid.Children.Add(rankLabel);
            LeaderboardGrid.SetRow(rankLabel, i + 1);
            LeaderboardGrid.SetColumn(rankLabel, 0);

            LeaderboardGrid.Children.Add(nameLabel);
            LeaderboardGrid.SetRow(nameLabel, i + 1);
            LeaderboardGrid.SetColumn(nameLabel, 1);

            LeaderboardGrid.Children.Add(scoreLabel);
            LeaderboardGrid.SetRow(scoreLabel, i + 1);
            LeaderboardGrid.SetColumn(scoreLabel, 2);
        }
    }

    private void OnBackButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    public class LeaderboardEntry
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
