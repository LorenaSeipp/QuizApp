using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core.Models;
using QuizApp.Core.Models.utils;
using QuizApp.Infrastructure;
using QuizApp.Views;

namespace QuizApp.ViewModels;

public class UserLoginViewModel : INotifyPropertyChanged
{
    private readonly UserService _userService;
    private string _password;
    private string _username;

    public UserLoginViewModel()
    {
        _userService = new UserService("OracleDb");
        LoginCommand = new RelayCommand(LoginUser);
        RegisterPlayerCommand = new RelayCommand(RegisterPlayer);
    }

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
                new AdminDashboardView().Show();
                CloseCurrentWindow();
            }
            else if (user.Role == UserRole.Player)
            {
                //TODO Navigation zu QuizView mit Team klären 
                new QuizView();
                CloseCurrentWindow();
            }
        }
        else
        {
            MessageBox.Show("Login fehlgeschlagen. Bitte überprüfe Benutzername und Passwort.");
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


    private void CloseCurrentWindow()
    {
        foreach (Window window in Application.Current.Windows)
            if (window.DataContext == this)
            {
                window.Close();
                break;
            }
    }

    private void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}