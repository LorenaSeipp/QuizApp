# Projekt im Rahmen des Moduls Objektorientierte Programmierung an der Technischen Hochschule Nürnberg 
Die Gruppenarbeit fand ursprünglich in GitLab statt. 

# Anleitung
- Docker installieren
- Docker Engine starten
- `cd Infrastructure/docker`
- `docker-compose up -d`
- Für den ersten Start in Infrastructure/OracleDatabaseService.cs in Zeile 51 das initiale Laden der Daten aktiviert werden (nach den ersten Start muss der Befehl dann wieder deaktiviert sein um doppelte Daten zu vermeiden)
- App starten (GUI Projekt)
- Mit Username und Passwort registrieren 
- Mit Username und Passwort anmelden (Spieler1/passwort1234 ist zb schon vorregistriert mit Highscore)
- Gewünschte Einstellungen treffen und starten

Ebenfalls kann man sich als Admin anmelden und eigene Fragen erstellen.

## Datenbank zurücksetzen:
- Im Docker container in die shell gehen (entweder per docker Desktop oder per cmd: `docker exec -it oracle-db bash`)
- In der Shell: `sqlplus system/oraclepw`

Folgende Commands ausführen:
```
DROP TABLE SORTQUESTION;
DROP TABLE ESTIMATEQUESTION;
DROP TABLE MULTIPLECHOICEQUESTION;
DROP TABLE TRUEFALSEQUESTION;
DROP TABLE OPENQUESTION;
DROP TABLE USERS CASCADE CONSTRAINTS;
DROP TABLE PLAYERS CASCADE CONSTRAINTS;
DROP TABLE ADMINS CASCADE CONSTRAINTS;
```
### !!! Wichtig !!!
Nachdem die Datenbank gecleart wurde muss die oben genannte Zeile mit 'init-data.sql' wieder für den 1. Start aktiviert werden

# Funktionalität (technisch)
Die Anzeige wird über ein MVVM (Model-View-ViewModel) Pattern gesteuert.

Die Settings (Schwierigkeit, Category, Anzahl der Fragen) werden mit Bindings vom Frontend an das Backend geschickt. 
Danach werden die Fragen für das Quiz aus der DB geholt und der QuizManager initialisiert.

Die Buttons zeigen auf ein Event, was den aktuell angezeigten View abändert und z.B. persistente Datenobjekte wie den Quizmanager weitergibt.
Während des Quizzes wird auf den Typen der nächsten Frage auf dem FragenStack im QuizManager geguckt und der entsprechende View wird erstellt (siehe QuestionViewModelFactory).

Wenn alle Fragen ausgeschöpft sind wird der Endscreen mit Highscore vom gerade spielenden Nutzer angezeigt.

# Projektplan: QuizApp – Meilenstein 03

**Gruppe 7:** Kristina Ruf, Lorena Seipp, Jan Sobotta, Benedict Volz

Dieser Projektplan beschreibt die Entwicklung einer objektorientierten QuizApp im Rahmen des dritten Meilensteins des OOP-Praktikums. Die Anwendung erfüllt alle geforderten OOP-Konzepte und wird in **C# mit WPF** realisiert. Zur Datenhaltung wird eine relationale Datenbank (**Oracle**) verwendet. Die App läuft isoliert und sicher in einem **Docker-Container**.

---

## 🛠️ Technologien

- **Programmiersprache:** C#
- **GUI:** WPF (Windows Presentation Foundation)
- **Datenbank:** JSON-File oder Oracle DB (optional)
- **Containerisierung:** Docker (optional)
- **Versionskontrolle:** GitLab
- **Entwicklungsumgebung:** Rider, Visual Studio

---

## 🔍 Funktionsübersicht (Features)

### 👤 Benutzer

- Benutzerverwaltung (Rolle, Name, Highscore, Quiz-Historie etc.)
- Admin-Rolle: darf Fragen hinzufügen/löschen – eigene Oberfläche

### ❓ Fragenverwaltung

- Fragenkategorien: Allgemeinwissen, Informatik, Geschichte, Biologie, Musik etc.
- Verschiedene Fragetypen:
  - Multiple Choice
  - Freitext
  - Schätzfragen (z. B. „Wie viele Einwohner hat XY?“)
  - Richtig / Falsch 
- Fragen & Antwortmöglichkeiten werden aus JSON File oder Datenbank geladen
- Fragen-Editor für Admins (GUI)

### 🧠 Quiz-Funktion

- Auswahl: Kategorie, Schwierigkeitslevel, Modus (Wettbewerb oder Übung) & Anzahl Fragen
- Timer je Frage
- Bewertungssystem:
  - Richtig: +10 Punkte
  - Schnell beantwortet: Bonuspunkte
  - Highscore wird in Datenbank gespeichert

### 📊 Statistiken

- Highscore-Übersicht
- Quizverlauf pro Benutzer
- Kategoriebezogene Erfolgsquoten

### 🖥️ GUI

- Navigation zwischen Startseite, Quiz, Ergebnisanzeige
- Eingabeformulare für neue Fragen (nur Admin)
- Fortschrittsanzeige im Quiz (Frage x von y)

---

## 🎯 Ziel

Ziel ist eine QuizApp mit GUI, in der Benutzer Fragen aus verschiedenen Kategorien und in verschiedenen Schwierigkeitsstufen beantworten können. Die Fragen sollen Multiple-Choice, Freitext und Schätzfragen beinhalten. Ein Admin-Frageneditor mit GUI soll es ermöglichen, Fragen zu verwalten.

---

## 🗂️ Projektphasen und Schritte

| **Schritt** | **Aufgabe** |
|------------:|-------------|
| 1 | GitLab-Repo anlegen, Klassendiagramm entwerfen |
| 2 | Basis-Klassen (Frage, Benutzer, Quiz, QuizManager etc.) implementieren |
| 3 | Vererbung: Fragetypen (Multiple Choice, Freitext, Schätzfrage) und Frageneditor implementieren (Benutzer in Player/Admin unterscheiden) |
| 4 | ER-Diagramm für Datenbank. Oracle DB in Docker-Container: Speicherung & Abfragen. Verbindung zur App |
| 5 | GUI (Startseite, Quizseite, Auswertung) & Admin-Frageneditor mit WPF erstellen |
| 6 | Punktesystem, Timer , Exception Handling |
| 7 | Statistiken, Benutzerverwaltung, Highscore-Funktionalität |
| 8 | Docker-Container erstellen, App testweise deployen und testen |
| 9 | Finale Tests, Code Cleanup, Präsentationsvorbereitung |

---
