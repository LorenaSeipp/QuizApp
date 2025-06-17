// QuizApp.ViewModels/UserLoginViewModel.cs

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

// Make sure this is included

namespace QuizApp.ViewModels;

public class UserLoginViewModel : BaseViewModel
{
    private const int MaxLoginAttempts = 3;
    private readonly NavigationStore _navigationStore; // Still needed for initializing commands
    private readonly QuizManager _quizManager; // Still needed for initializing commands
    private readonly UserService _userService;
    private int _loginAttempts;
    private string _password;
    private string _username;


    public UserLoginViewModel(NavigationStore navigationStore, QuizManager quizManager)
    {
        _quizManager = quizManager;
        _navigationStore = navigationStore;

        _userService = new UserService(App.ConnectionString);

        // Initialize commands
        LoginCommand = new RelayCommand(LoginUser); // This command stays as it performs authentication logic
        RegisterPlayerCommand = new RelayCommand(RegisterPlayer); // This command stays
        NavigateSettingsCommand = new NavigateSettingsCommand(_navigationStore, _quizManager);
        QuitCommand = new QuitCommand();
        NavigateHomeCommand = new NavigateHomeCommand(_navigationStore, _quizManager);
        // NEW: Initialize NavigateAdminDashboardCommand
        NavigateAdminDashboardCommand = new NavigateAdminDashboardCommand(_navigationStore, _quizManager);
    }

    public ICommand NavigateSettingsCommand { get; }
    public ICommand QuitCommand { get; }
    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateAdminDashboardCommand { get; } // NEW property for the command


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

    public event PropertyChangedEventHandler
        PropertyChanged; // This seems redundant if BaseViewModel already handles it

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
                    $"Benutzername oder Passwort falsch. \n. Versuche verbleibend: {MaxLoginAttempts - _loginAttempts} Neuer Nutzer? Registrieren klicken!");
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
                NavigateAdminDashboardCommand.Execute(null); // Or pass user data if needed
            }
            else if (user.Role == UserRole.Player)
            {
                if (user is Player player)
                {
                    _quizManager.SetCurrentPlayer(player);
                    MessageBox.Show($"Willkommen, {player.Name}!");
                }

                NavigateSettingsCommand.Execute(null);
            }
        }
        catch (OracleException ex)
        {
            MessageBox.Show("Datenbankfehler beim Login");
            NavigateHomeCommand.Execute(null); // Use the command here too
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fehler beim Login");
            NavigateHomeCommand.Execute(null); // Use the command here too
        }
    }

    private void RegisterPlayer()
    {
        if (_userService.GetUserByName(Username) != null)
        {
            MessageBox.Show("Benutzername existiert bereits.");
            return;
        }

        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            MessageBox.Show("Bitte Benutzername und Passwort eingeben.");
            return;
        }

        if (Password.Length < 12)
        {
            MessageBox.Show("Passwort muss mindestens 12 Zeichen lang sein.");
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