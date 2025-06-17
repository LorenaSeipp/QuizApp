using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using QuizApp.Core.Models;
using QuizApp.Infrastructure;

namespace QuizApp.ViewModels;

public class HighscoreViewModel : INotifyPropertyChanged
{
    private string _currentPlayerName = "";
    private int _currentPlayerScore = 0;

    public string CurrentPlayerName
    {
        get => _currentPlayerName;
        set => SetField(ref _currentPlayerName, value);
    }

    public int CurrentPlayerScore
    {
        get => _currentPlayerScore;
        set => SetField(ref _currentPlayerScore, value);
    }

    public ObservableCollection<(string Name, int Highscore)> TopHighscores { get; } 
        = new ObservableCollection<(string, int)>();

    private readonly HighscoreManager _highscoreManager;

    public HighscoreViewModel(HighscoreManager highscoreManager)
    {
        _highscoreManager = highscoreManager;
    }

    public void LoadData(Player currentPlayer)
    {
        if (currentPlayer != null)
        {
            CurrentPlayerName = currentPlayer.Name;
            CurrentPlayerScore = currentPlayer.Highscore;
        }

        TopHighscores.Clear();
        var topFive = _highscoreManager.GetTopHighscores();
        foreach (var (name, score) in topFive)
        {
            TopHighscores.Add((name, score));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value)) return false;
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        return true;
    }
}