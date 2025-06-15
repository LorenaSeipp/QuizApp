using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core.Models;
using QuizApp.Core.Models.utils;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public class UserLoginViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly UserService _userService;
    private string _password;
    private readonly QuizManager _quizManager;
    private string _username;

    public UserLoginViewModel(NavigationStore navigationStore, QuizManager quizManager)
    {
        _quizManager = quizManager;
        _navigationStore = navigationStore;
        LoginCommand = new RelayCommand(LoginUser);
        _userService = new UserService(App.ConnectionString);
        LoginCommand = new RelayCommand(LoginUser);
        RegisterPlayerCommand = new RelayCommand(RegisterPlayer);
        NavigateSettingsCommand = new NavigateSettingsCommand(_navigationStore, _quizManager);
        QuitCommand = new QuitCommand();
    }

    public ICommand NavigateSettingsCommand { get; }
    public ICommand QuitCommand { get; }

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    public ICommand LoginCommand { get; }
    public ICommand RegisterPlayerCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    private void LoginUser()
    {
        User user = _userService.GetUserByName(Username);

        if (user != null && PasswordHelper.VerifyPassword(Password, user.Password))
        {
            if (user.Role == UserRole.Admin)
            {
                _navigationStore.CurrentViewModel = new AdminDashboardViewModel(App.ConnectionString, _quizManager);
            }
            else if (user.Role == UserRole.Player)
            {
                _navigationStore.CurrentViewModel = new SettingsViewModel(_navigationStore, _quizManager);
            }
        }
        else
        {
            MessageBox.Show("Login fehlgeschlagen.");
        }
    }

    private void RegisterPlayer()
    {
        if (_userService.GetUserByName(Username) != null)
        {
            MessageBox.Show("Benutzername existiert bereits.");
            return;
        }

        string hashed = PasswordHelper.HashPassword(Password);

        Player newPlayer = new()
        {
            Name = Username,
            Password = hashed,
            Role = UserRole.Player,
            GamesPlayed = 0,
            Highscore = 0,
            AverageScore = 0,
            LastPlayed = null
        };

        _userService.SavePlayer(newPlayer);
        MessageBox.Show("Registrierung erfolgreich. Du kannst dich jetzt einloggen.");
    }
}