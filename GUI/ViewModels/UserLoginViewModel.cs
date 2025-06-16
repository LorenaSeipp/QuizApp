using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Oracle.ManagedDataAccess.Client;
using QuizApp.Commands;
using QuizApp.Core.Models;
using QuizApp.Core.Models.utils;
using QuizApp.Infrastructure;
using QuizApp.Logic;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public class UserLoginViewModel : BaseViewModel
{
    private const int MaxLoginAttempts = 3;
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;
    private readonly UserService _userService;
    private int _loginAttempts;
    private string _password;
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
        NavigateHomeCommand = new NavigateHomeCommand(_navigationStore, _quizManager);
    }

    public ICommand NavigateSettingsCommand { get; }
    public ICommand QuitCommand { get; }
    public ICommand NavigateHomeCommand { get; }


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
        try
        {
            if (_loginAttempts >= MaxLoginAttempts)
            {
                MessageBox.Show("Zu viele Fehlversuche. Bitte Anwendung neu starten.");
                return;
            }

            User user = _userService.GetUserByName(Username);

            if (user == null)
            {
                _loginAttempts++;
                MessageBox.Show(
                    $"Benutzer nicht gefunden. Versuche verbleibend: {MaxLoginAttempts - _loginAttempts} Neuer Nutzer? Registrieren klicken!");
                return;
            }

            if (!PasswordHelper.VerifyPassword(Password, user.Password))
            {
                _loginAttempts++;
                MessageBox.Show($"Falsches Passwort. Versuche verbleibend: {MaxLoginAttempts - _loginAttempts}");
                return;
            }

            // Login erfolgreich
            _loginAttempts = 0;

            if (user.Role == UserRole.Admin)
            {
                _navigationStore.CurrentViewModel =
                    new AdminDashboardViewModel(App.ConnectionString, _quizManager, _navigationStore);
            }
            else if (user.Role == UserRole.Player)
            {
                _navigationStore.CurrentViewModel = new SettingsViewModel(_navigationStore, _quizManager);
            }
        }
        catch (OracleException ex)
        {
            MessageBox.Show("Datenbankfehler beim Login");
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore, _quizManager);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fehler beim Login");
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore, _quizManager);
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