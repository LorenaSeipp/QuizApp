Projektplan: QuizApp – Meilenstein03
Gruppe 7: Kristina Ruf, Lorena Seipp, Jan Sobotta, Benedict Volz
Dieser Projektplan beschreibt die Entwicklung einer objektorientierten QuizApp im Rahmen des dritten Meilensteins des OOP-Praktikums. Die Anwendung erfüllt alle geforderten OOP-Konzepte und wird in C# mit WPF realisiert. Zur Datenhaltung wird eine relationale Datenbank (Oracle) verwendet. Die App läuft isoliert und sicher in einem Docker-Container.
Technologien
- Programmiersprache: C#
- GUI: WPF (Windows Presentation Foundation)
- Datenbank: Oracle DB
- Containerisierung: Docker
- Versionskontrolle: GitLab
- Entwicklungsumgebung: Rider, Visual Studio
Funktionsübersicht (Features)
 Benutzer
•         Benutzerverwaltung (Rolle, Name, Highscore, Quiz-Historie etc.)
•         Admin-Rolle: darf Fragen hinzufügen/löschen - eigene Oberfläche
Fragenverwaltung
•         Fragenkategorien (Allgemeinwissen, Informatik, Geschichte, Biologie, Musik etc.)
•         Verschiedene Fragetypen:
o    Multiple Choice
o    Freitext
o    Schätzfragen (z. B. „Wie viele Einwohner hat XY?“)
•         Fragen & Antwortmöglichkeiten werden aus Datenbank geladen 
•         Fragen-Editor für Admins (GUI)
 Quiz-Funktion
•         Auswahl: Kategorie, Schwierigkeitslevel, Modus (Wettbewerb oder Übung) & Anzahl Fragen
•         Timer je Frage
•         Bewertungssystem:
o    Richtig: +10 Punkte
o    Schnell beantwortet: Bonuspunkte
o    Highscore wird in Datenbank gespeichert
 Statistiken
•         Highscore-Übersicht 
•         Quizverlauf pro Benutzer
•         Kategoriebezogene Erfolgsquoten
 GUI
•         Navigation zwischen Startseite, Quiz, Ergebnisanzeige
•         Eingabeformulare für neue Fragen (nur Admin)
•         Fortschrittsanzeige im Quiz (Frage x von y)
Ziel
Ziel ist eine QuizApp mit GUI, in der Benutzer Fragen aus verschiedenen Kategorien und in verschiedenen Schwierigkeitsstufen beantworten können. Die Fragen sollen MultipleChoice, Freitext und Schätzfragen beinhalten. Eine Admin-Frageneditor mit GUI soll es ermöglichen Fragen zu verwalten. 
Projektphasen und Schritte
Schritte	Aufgabe
1	GitLab-Repo anlegen, Klassendiagramm entwerfen
2	Basis-Klassen (Frage, Benutzer, Quiz, QuizManager etc) implementieren
3	Vererbung: Fragetypen (Multiple Choice, Freitext, Schätzfrage) und  Frageneditor implementieren (Benutzer in Player / Admin unterscheiden) 
4	ER-Diagramm für Datenbank. Oracle DB in Docker-Container:  Speicherung & Abfragen. Verbindungs zu App. 
5	GUI (Startseite, Quizseite, Auswertung) & Admin-Frageneditor  mit WPF erstellen
6	Punktesystem, Timer (Delegates), Exception Handling
7	Statistiken, Benutzerverwaltung, Highscore-Funktionalität
8	Docker-Container erstellen, App testweise deployen und testen
9	Finale Tests, Code Cleanup, Präsentationsvorbereitung

