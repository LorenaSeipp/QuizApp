using System.Windows;
using Microsoft.Extensions.Configuration;
using QuizApp.Core;
using QuizApp.Infrastructure;

namespace QuizApp;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // 1. Konfiguration laden
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        string? connectionString = config.GetConnectionString("OracleDb");

        // 2. Service erstellen
        UserService userService = new(connectionString);

        // 3. Test: Benutzer speichern und abrufen
        userService.SavePlayer(new Player { Name = "Bob", Highscore = 150 });
        List<User> users = userService.GetAllUsers();

        foreach (User user in users) MessageBox.Show($"Name: {user.Name}, Role: {user.Role}");

        // 4. Hauptfenster starten
        MainWindow mainWindow = new();
        mainWindow.Show();
    }
}