-- ####################################################################################################
-- ########################################### PLAYER #####################################
-- ####################################################################################################

-- Hash für 'passwort1234' (generiert mit SHA256 und Base64-Kodierung): oUi8dI8eu0YWj1tULBek2QRhceDH/9/cuFhZdgCUDj8=
-- HINWEIS: Diese INSERT-Anweisungen sind nur für Testzwecke!

-- USERS
INSERT INTO Users (Name, Passwordhash, Role)
VALUES ('Spieler1', 'oUi8dI8eu0YWj1tULBek2QRhceDH/9/cuFhZdgCUDj8=', 'Player');
INSERT INTO Users (Name, Passwordhash, Role)
VALUES ('Spieler2', 'oUi8dI8eu0YWj1tULBek2QRhceDH/9/cuFhZdgCUDj8=', 'Player');
INSERT INTO Users (Name, Passwordhash, Role)
VALUES ('Spieler3', 'oUi8dI8eu0YWj1tULBek2QRhceDH/9/cuFhZdgCUDj8=', 'Player');
INSERT INTO Users (Name, Passwordhash, Role)
VALUES ('Spieler4', 'oUi8dI8eu0YWj1tULBek2QRhceDH/9/cuFhZdgCUDj8=', 'Player');
INSERT INTO Users (Name, Passwordhash, Role)
VALUES ('Spieler5', 'oUi8dI8eu0YWj1tULBek2QRhceDH/9/cuFhZdgCUDj8=', 'Player');
INSERT INTO Users (Name, Passwordhash, Role)
VALUES ('Admin1', 'oUi8dI8eu0YWj1tULBek2QRhceDH/9/cuFhZdgCUDj8=', 'Admin');
INSERT INTO Users (Name, Passwordhash, Role)
VALUES ('Admin2', 'oUi8dI8eu0YWj1tULBek2QRhceDH/9/cuFhZdgCUDj8=', 'Admin');
INSERT INTO Users (Name, Passwordhash, Role)
VALUES ('SuperAdmin', 'oUi8dI8eu0YWj1tULBek2QRhceDH/9/cuFhZdgCUDj8=', 'Admin');

-- PLAYERS
INSERT INTO Players (Id, GamesPlayed, HighScore, AverageScore, LastPlayed)
VALUES (1, 10, 1500, 1200, TO_TIMESTAMP('2024-06-15 10:30:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO Players (Id, GamesPlayed, HighScore, AverageScore, LastPlayed)
VALUES (2, 25, 2100, 1850, TO_TIMESTAMP('2024-06-14 14:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO Players (Id, GamesPlayed, HighScore, AverageScore, LastPlayed)
VALUES (3, 5, 800, 750, TO_TIMESTAMP('2024-06-16 09:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO Players (Id, GamesPlayed, HighScore, AverageScore, LastPlayed)
VALUES (4, 18, 1900, 1700, TO_TIMESTAMP('2024-06-15 18:45:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO Players (Id, GamesPlayed, HighScore, AverageScore, LastPlayed)
VALUES (5, 30, 2500, 2300, TO_TIMESTAMP('2024-06-16 11:15:00', 'YYYY-MM-DD HH24:MI:SS'));

-- ADMINS
INSERT INTO Admins (Id, CreatedAt, CreatedBy, IsActive)
VALUES (6, TO_TIMESTAMP('2023-01-01 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'System', 1);
INSERT INTO Admins (Id, CreatedAt, CreatedBy, IsActive)
VALUES (7, TO_TIMESTAMP('2023-03-15 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Admin1', 1);
INSERT INTO Admins (Id, CreatedAt, CreatedBy, IsActive)
VALUES (8, TO_TIMESTAMP('2022-11-20 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Root', 1);

-- ####################################################################################################
-- ########################################### SORT QUESTIONS #########################################
-- ####################################################################################################
-- Informatik
INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Programmiersprachen nach ihrem Erscheinungsjahr (alt → neu):', 'Sort', 0, 'Informatik', 'C', 'Java', 'Python', 'Go');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Datenstrukturen nach ihrer Zugriffskomplexität (einfach → komplex):', 'Sort', 1, 'Informatik', 'Array', 'Linked List', 'Stack', 'Heap');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Erfindungen der Informatik zeitlich (früh → spät):', 'Sort', 2, 'Informatik', 'Transistor', 'Mikroprozessor', 'Internet', 'Smartphone');

-- INFORMATIK
INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Programmiersprachen nach ihrem Erscheinungsjahr (alt → neu):', 'Sort', 0, 'Informatik', 'C',
        'Java', 'Python', 'Go');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Speichertypen nach Zugriffszeit (schnell → langsam):', 'Sort', 0, 'Informatik', 'Register',
        'Cache', 'RAM', 'Festplatte');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Geräte nach ihrer Markteinführung (früh → spät):', 'Sort', 0, 'Informatik', 'Desktop-PC', 'Laptop',
        'Smartphone', 'Smartwatch');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese IT-Berufe nach technischer Spezialisierung (allgemein → spezialisiert):', 'Sort', 0, 'Informatik',
        'IT-Support', 'Systemadministrator', 'Softwareentwickler', 'Data Scientist');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Peripheriegeräte nach ihrem Einsatzzweck (Ein- → Ausgabe):', 'Sort', 0, 'Informatik', 'Tastatur',
        'Maus', 'Monitor', 'Drucker');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Datenstrukturen nach ihrer Zugriffskomplexität (einfach → komplex):', 'Sort', 1, 'Informatik',
        'Array', 'Linked List', 'Stack', 'Heap');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Programmiersprachen nach Paradigma-Nähe zur Maschine (nah → weit):', 'Sort', 1, 'Informatik',
        'Assembler', 'C', 'Java', 'Python');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Prozesse im Software-Lifecycle (Start → Ende):', 'Sort', 1, 'Informatik', 'Planung', 'Entwicklung',
        'Test', 'Wartung');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Zahlensysteme nach Basis (klein → groß):', 'Sort', 1, 'Informatik', 'Binär', 'Oktal', 'Dezimal',
        'Hexadezimal');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Internet-Technologien nach ihrer Verbreitung (alt → neu):', 'Sort', 1, 'Informatik', 'Modem',
        'DSL', 'WLAN', '5G');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Erfindungen der Informatik zeitlich (früh → spät):', 'Sort', 2, 'Informatik', 'Transistor',
        'Mikroprozessor', 'Internet', 'Smartphone');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Big-Data-Technologien nach ihrer Einführung (alt → neu):', 'Sort', 2, 'Informatik', 'Hadoop',
        'Spark', 'Kafka', 'Snowflake');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Informatiker nach Geburtsjahr (früh → spät):', 'Sort', 2, 'Informatik', 'Alan Turing',
        'John von Neumann', 'Linus Torvalds', 'Tim Berners-Lee');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Cybersecurity-Konzepte nach Abstraktionsebene (niedrig → hoch):', 'Sort', 2, 'Informatik',
        'Firewall', 'Antivirus', 'Verschlüsselung', 'Zero Trust');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Programmiersprachen nach Beliebtheit laut TIOBE 2023 (weniger → mehr):', 'Sort', 2, 'Informatik',
        'Rust', 'Go', 'C++', 'Python');

-- MUSIK
INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Musikrichtungen nach Entstehung (früh → spät):', 'Sort', 0, 'Musik', 'Klassik', 'Jazz', 'Rock',
        'Hip-Hop');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Töne nach Tonhöhe (tief → hoch):', 'Sort', 0, 'Musik', 'C', 'E', 'G', 'C\');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Instrumente nach Größe (klein → groß):', 'Sort', 0, 'Musik', 'Blockflöte', 'Violine', 'Cello',
        'Kontrabass');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Musikzeichen nach Länge (kurz → lang):', 'Sort', 0, 'Musik', 'Sechzehntelnote', 'Achtelnote',
        'Viertelnote', 'Halbe Note');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Musiker nach Karrierebeginn (früh → spät):', 'Sort', 0, 'Musik', 'Elvis Presley',
        'Michael Jackson', 'Beyoncé', 'Billie Eilish');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Komponisten nach Geburtsjahr (früh → spät):', 'Sort', 1, 'Musik', 'Bach', 'Mozart', 'Beethoven',
        'Schumann');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Instrumentengruppen nach Häufigkeit im Orchester (selten → häufig):', 'Sort', 1, 'Musik', 'Harfe',
        'Fagott', 'Viola', 'Violine');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Genres nach Tanzbarkeit (niedrig → hoch):', 'Sort', 1, 'Musik', 'Klassik', 'Jazz', 'Rock',
        'Techno');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Musiktheoretiker nach Epoche (früh → spät):', 'Sort', 1, 'Musik', 'Aristoxenos',
        'Guido von Arezzo', 'Rameau', 'Schenker');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Alben nach ihrem Erscheinungsjahr (alt → neu):', 'Sort', 2, 'Musik', 'Thriller', 'Nevermind',
        'Back to Black', '25');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Opern nach ihrer Uraufführung (früh → spät):', 'Sort', 2, 'Musik', 'Die Zauberflöte',
        'La Traviata', 'Carmen', 'Turandot');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Musikepochen chronologisch (früh → spät):', 'Sort', 2, 'Musik', 'Barock', 'Klassik', 'Romantik',
        'Moderne');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Tonarten nach Anzahl der Vorzeichen (wenig → viel):', 'Sort', 2, 'Musik', 'C-Dur', 'G-Dur',
        'A-Dur', 'E-Dur');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Musikpreise nach Prestige (niedrig → hoch):', 'Sort', 2, 'Musik', 'Echo', 'Brit Awards', 'Grammy',
        'Pulitzer');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Musikrichtungen nach Entstehung (früh → spät):', 'Sort', 0, 'Musik', 'Klassik', 'Jazz', 'Rock', 'Hip-Hop');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Komponisten nach Geburtsjahr (früh → spät):', 'Sort', 1, 'Musik', 'Bach', 'Mozart', 'Beethoven', 'Schumann');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Alben nach ihrem Erscheinungsjahr (alt → neu):', 'Sort', 2, 'Musik', 'Thriller', 'Nevermind', 'Back to Black', '25');


-- GEOGRAFIE
INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Länder nach ihrer Fläche (klein → groß):', 'Sort', 0, 'Geografie', 'Niederlande', 'Deutschland', 'Brasilien', 'Russland');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Flüsse nach ihrer Länge (kurz → lang):', 'Sort', 1, 'Geografie', 'Elbe', 'Donau', 'Amazonas', 'Nil');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Hauptstädte geografisch (Westen → Osten):', 'Sort', 2, 'Geografie', 'Lissabon', 'Berlin', 'Moskau', 'Tokio');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Länder nach ihrer Fläche (klein → groß):', 'Sort', 0, 'Geografie', 'Niederlande', 'Deutschland',
        'Brasilien', 'Russland');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Ozeane nach Größe (klein → groß):', 'Sort', 0, 'Geografie', 'Arktischer Ozean', 'Indischer Ozean',
        'Atlantischer Ozean', 'Pazifik');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Kontinente nach Bevölkerungszahl (wenig → viel):', 'Sort', 0, 'Geografie', 'Australien', 'Europa',
        'Afrika', 'Asien');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Städte nach ihrer geografischen Lage (Norden → Süden):', 'Sort', 0, 'Geografie', 'Oslo', 'Berlin',
        'Rom', 'Athen');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Länder nach Einwohnerzahl (wenig → viel):', 'Sort', 0, 'Geografie', 'Island', 'Portugal',
        'Deutschland', 'Indien');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Flüsse nach ihrer Länge (kurz → lang):', 'Sort', 1, 'Geografie', 'Elbe', 'Donau', 'Amazonas',
        'Nil');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Gebirge nach maximaler Höhe (niedrig → hoch):', 'Sort', 1, 'Geografie', 'Mittelgebirge', 'Alpen',
        'Anden', 'Himalaya');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Länder nach Alphabet (A → Z):', 'Sort', 1, 'Geografie', 'Argentinien', 'Frankreich', 'Italien',
        'Südafrika');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Wüsten nach Fläche (klein → groß):', 'Sort', 1, 'Geografie', 'Atacama', 'Kalahari', 'Gobi',
        'Sahara');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Meere nach Salzgehalt (wenig → viel):', 'Sort', 1, 'Geografie', 'Ostsee', 'Nordsee', 'Mittelmeer',
        'Totes Meer');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Hauptstädte geografisch (Westen → Osten):', 'Sort', 2, 'Geografie', 'Lissabon', 'Berlin', 'Moskau',
        'Tokio');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Vulkane nach Ausbruchsjahr (früh → spät):', 'Sort', 2, 'Geografie', 'Vesuv (79 n. Chr.)',
        'Krakatau (1883)', 'Mount St. Helens (1980)', 'Eyjafjallajökull (2010)');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Länder nach ihrer Entstehung (früh → spät):', 'Sort', 2, 'Geografie', 'China', 'Frankreich', 'USA',
        'Deutschland');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese US-Staaten nach Eintritt in die Union (früh → spät):', 'Sort', 2, 'Geografie', 'Delaware',
        'Virginia', 'California', 'Hawaii');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Städte nach Bevölkerung (wenig → viel):', 'Sort', 2, 'Geografie', 'Zürich', 'Berlin', 'London',
        'Tokio');

-- FUNFACTS
INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Tiere nach ihrer Geschwindigkeit (langsam → schnell):', 'Sort', 0, 'FunFacts', 'Faultier',
        'Mensch', 'Hund', 'Gepard');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Früchte nach Größe (klein → groß):', 'Sort', 0, 'FunFacts', 'Heidelbeere', 'Kirsche', 'Apfel',
        'Melone');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Planeten nach Entfernung zur Sonne (nah → fern):', 'Sort', 0, 'FunFacts', 'Merkur', 'Venus',
        'Erde', 'Mars');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Farben nach Wellenlänge (kurz → lang):', 'Sort', 0, 'FunFacts', 'Violett', 'Blau', 'Grün', 'Rot');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Materialien nach Härte (weich → hart):', 'Sort', 0, 'FunFacts', 'Holz', 'Eisen', 'Quarz',
        'Diamant');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Snacks nach Kalorien (wenig → viel):', 'Sort', 1, 'FunFacts', 'Apfel', 'Popcorn', 'Schokolade',
        'Erdnussbutter');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Softdrinks nach Zuckergehalt (wenig → viel):', 'Sort', 1, 'FunFacts', 'Wasser', 'Apfelschorle',
        'Cola', 'Energy Drink');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Feiertage nach Datum (früh → spät):', 'Sort', 1, 'FunFacts', 'Neujahr', 'Ostern', 'Tag der Arbeit',
        'Weihnachten');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Tiere nach Lebenserwartung (kurz → lang):', 'Sort', 1, 'FunFacts', 'Maus', 'Hund', 'Elefant',
        'Galápagos-Schildkröte');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Hunderassen nach Größe (klein → groß):', 'Sort', 1, 'FunFacts', 'Chihuahua', 'Beagle',
        'Golden Retriever', 'Deutsche Dogge');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Länder nach Anzahl der Feiertage pro Jahr (wenig → viel):', 'Sort', 2, 'FunFacts', 'USA',
        'Deutschland', 'Indien', 'Japan');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Filme nach Länge (kurz → lang):', 'Sort', 2, 'FunFacts', 'Toy Story', 'Titanic',
        'Herr der Ringe – Die Rückkehr des Königs', 'Lawrence von Arabien');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Staaten nach Alkoholkonsum pro Kopf (wenig → viel):', 'Sort', 2, 'FunFacts', 'Norwegen', 'USA',
        'Deutschland', 'Tschechien');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Länder nach durchschnittlicher Arbeitszeit pro Woche (kurz → lang):', 'Sort', 2, 'FunFacts',
        'Niederlande', 'Deutschland', 'USA', 'Mexiko');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Tiere nach Anzahl der Zähne (wenig → viel):', 'Sort', 2, 'FunFacts', 'Mensch', 'Hund', 'Hai',
        'Schnecke');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Tiere nach ihrer Geschwindigkeit (langsam → schnell):', 'Sort', 0, 'FunFacts', 'Faultier', 'Mensch', 'Hund', 'Gepard');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Snacks nach Kalorien (wenig → viel):', 'Sort', 1, 'FunFacts', 'Apfel', 'Popcorn', 'Schokolade', 'Erdnussbutter');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
VALUES ('Ordne diese Länder nach Anzahl der Feiertage pro Jahr (wenig → viel):', 'Sort', 2, 'FunFacts', 'USA', 'Deutschland', 'Indien', 'Japan');


--- ####################################################################################################
-- ########################################### OPEN QUESTIONS ##########################################
-- ####################################################################################################

-- Informatik
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man den Bereich eines Computers, der Daten kurzfristig speichert?','Open', 0, 'Informatik', 'RAM,Arbeitsspeicher,Random Access Memory');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) 
VALUES ('Welche Programmiersprache wird hauptsächlich für Webentwicklung verwendet und läuft im Browser?','Open', 1, 'Informatik', 'JavaScript,JS');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt das Verschlüsselungsverfahren mit öffentlichem und privatem Schlüssel?','Open', 2, 'Informatik', 'Asymmetrisch,Asymmetrische Verschlüsselung');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man die kleinste Informationseinheit in der Informatik?', 'Open', 0, 'Informatik', 'Bit');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man den tragbaren Computer, der auf dem Schoß benutzt werden kann?', 'Open', 0, 'Informatik',
        'Laptop,Notebook');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welches Betriebssystem wird häufig auf Smartphones verwendet?', 'Open', 0, 'Informatik', 'Android,iOS');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man Programme, die schädliche Funktionen auf Computern ausführen?', 'Open', 0, 'Informatik',
        'Virus,Malware,Schadsoftware');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Was ist ein anderes Wort für eine Webseite-Adresse?', 'Open', 0, 'Informatik', 'URL,Internetadresse');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt die Programmiersprache, die für wissenschaftliches Rechnen und KI oft verwendet wird?', 'Open', 1,
        'Informatik', 'Python');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man die Wiederholung eines Code-Abschnitts in der Programmierung?', 'Open', 1, 'Informatik',
        'Schleife,Loop');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man den zentralen Steuerungschip eines Computers?', 'Open', 1, 'Informatik', 'Prozessor,CPU');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welche Sprache basiert auf HTML und wird zur Gestaltung von Webseiten verwendet?', 'Open', 1, 'Informatik',
        'CSS,Cascading Style Sheets');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Was bedeutet die Abkürzung "IT"?', 'Open', 1, 'Informatik', 'Informationstechnologie,Information Technology');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man einen Fehler in einem Programmcode?', 'Open', 2, 'Informatik', 'Bug,Programmfehler');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man die Methode zur Versionsverwaltung von Code, z.B. mit Git?', 'Open', 2, 'Informatik',
        'Versionskontrolle,Versionierung');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt das Protokoll, das für verschlüsselte Webseiten verwendet wird?', 'Open', 2, 'Informatik', 'HTTPS');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welcher Algorithmus wird oft zur Datenkomprimierung genutzt?', 'Open', 2, 'Informatik', 'Huffman,Lempel-Ziv');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt das Konzept, bei dem Daten über verteilte Systeme gespeichert werden?', 'Open', 2, 'Informatik',
        'Cloud Computing,Cloud');

-- Musik
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man ein Lied ohne Begleitung durch Instrumente?', 'Open', 0, 'Musik', 'A cappella,Acapella');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man das Zeichen, das Noten höher macht?', 'Open', 0, 'Musik', 'Kreuz,#');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man das Instrument mit weißen und schwarzen Tasten?', 'Open', 0, 'Musik', 'Klavier,Piano');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man einen sehr schnellen Musikabschnitt?', 'Open', 0, 'Musik', 'Presto');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man ein großes Ensemble mit Streichern, Bläsern und Schlagwerk?', 'Open', 0, 'Musik', 'Orchester');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt der Bereich der Musik, der sich mit Klangfarben beschäftigt?', 'Open', 1, 'Musik',
        'Timbre,Klangeigenschaft');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man das Tempozeichen für "mäßig schnell"?', 'Open', 1, 'Musik', 'Andante');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man die Tonhöhe eines Tones im Notensystem?', 'Open', 1, 'Musik', 'Tonlage,Pitch');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welches Instrument hat Saiten, aber wird mit einem Bogen gestrichen?', 'Open', 1, 'Musik', 'Geige,Violine');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man die gleichzeitige Verwendung mehrerer Töne?', 'Open', 1, 'Musik', 'Akkord,Harmonie');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt das Tonsystem, das zwölf Halbtöne pro Oktave kennt?', 'Open', 2, 'Musik',
        'Chromatik,chromatisches System');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man die Musikrichtung, die elektronische Klänge nutzt und oft tanzbar ist?', 'Open', 2, 'Musik',
        'Elektro,Elektronische Musik');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man die musikalische Praxis, ein Thema in anderer Tonart zu wiederholen?', 'Open', 2, 'Musik',
        'Transposition');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welcher Musiker komponierte die „Mondscheinsonate“?', 'Open', 2, 'Musik', 'Beethoven,Ludwig van Beethoven');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man eine Tonfolge, die als Grundlage für Improvisationen dient?', 'Open', 2, 'Musik',
        'Skala,Skale,Tonleiter');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man eine Gruppe von vier Musikern, die zusammen spielen?','Open', 0, 'Musik', 'Quartett');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man die Tonart mit einem Kreuz-Vorzeichen?','Open', 1, 'Musik', 'G-Dur,G Dur');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man die Kompositionstechnik, bei der ein Thema rückwärts gespielt wird?','Open', 2, 'Musik', 'Krebs');

-- Geografie
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welcher Kontinent liegt direkt südlich von Europa?','Open', 0, 'Geografie', 'Afrika');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) 
VALUES ('Wie heißt der höchste Berg Afrikas?','Open', 1, 'Geografie', 'Kilimandscharo,Kilimanjaro');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) 
VALUES ('In welchem Land liegt das geographische Zentrum Europas (laut einer Berechnung in der Nähe von Polotsk)?','Open', 2, 'Geografie', 'Belarus,Weißrussland');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt der größte Ozean der Erde?', 'Open', 0, 'Geografie', 'Pazifik,Pazifischer Ozean');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt der längste Fluss Europas?', 'Open', 0, 'Geografie', 'Wolga');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welche Himmelsrichtung liegt gegenüber von Westen?', 'Open', 0, 'Geografie', 'Osten');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt das Land, in dem die Pyramiden von Gizeh stehen?', 'Open', 0, 'Geografie', 'Ägypten');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man eine Karte, die Höhenunterschiede zeigt?', 'Open', 0, 'Geografie', 'Reliefkarte,Höhenkarte');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt die Hauptstadt von Kanada?', 'Open', 1, 'Geografie', 'Ottawa');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welcher Kontinent hat die meisten Länder?', 'Open', 1, 'Geografie', 'Afrika');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man eine Linie, die alle Punkte gleicher Höhe verbindet?', 'Open', 1, 'Geografie',
        'Höhenlinie,Isolinie');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt der größte See Afrikas?', 'Open', 1, 'Geografie', 'Victoriasee,Victoria-See');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man ein Land, das vollständig von einem anderen Land umschlossen ist?', 'Open', 1, 'Geografie',
        'Enklave');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welche Stadt liegt gleichzeitig auf zwei Kontinenten?', 'Open', 2, 'Geografie', 'Istanbul');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welches Land hat die meisten Nachbarländer?', 'Open', 2, 'Geografie', 'China,Russland');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man das Phänomen, wenn die Sonne 24 Stunden am Tag scheint?', 'Open', 2, 'Geografie',
        'Polartag,Mittsommer');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welche Gebirgskette trennt Europa und Asien?', 'Open', 2, 'Geografie', 'Ural,Uralgebirge');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie nennt man eine geografische Breitenlinie?', 'Open', 2, 'Geografie', 'Breitengrad');

-- FunFacts
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welches Tier miaut und ist ein beliebtes Haustier?', 'Open', 0, 'FunFacts', 'Katze');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Was trägt man am Fuß, um draußen zu gehen?', 'Open', 0, 'FunFacts', 'Schuh,Schuhe');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Was benutzt man, um Zähne zu putzen?', 'Open', 0, 'FunFacts', 'Zahnbürste');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welcher Planet ist der Sonne am nächsten?', 'Open', 0, 'FunFacts', 'Merkur');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welche Farbe bekommt man, wenn man Blau und Gelb mischt?', 'Open', 0, 'FunFacts', 'Grün');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welches Tier kann im Verhältnis zu seiner Größe am höchsten springen?', 'Open', 1, 'FunFacts', 'Floh');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie viele Beine hat ein Insekt normalerweise?', 'Open', 1, 'FunFacts', '6,sechs');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Was passiert mit Wasser bei 100 Grad Celsius?', 'Open', 1, 'FunFacts', 'Es kocht,es verdampft');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt das bekannteste Wahrzeichen von Paris?', 'Open', 1, 'FunFacts', 'Eiffelturm');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welcher Körperteil wächst nie nach der Geburt weiter?', 'Open', 1, 'FunFacts', 'Auge,Augapfel');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt der größte bekannte Dinosaurier?', 'Open', 2, 'FunFacts', 'Argentinosaurus');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie viele Herzen hat ein Oktopus?', 'Open', 2, 'FunFacts', '3,drei');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Was ist der seltenste Bluttyp beim Menschen?', 'Open', 2, 'FunFacts', 'AB negativ');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welches Metall ist flüssig bei Raumtemperatur?', 'Open', 2, 'FunFacts', 'Quecksilber,Hg');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welches Land konsumiert weltweit am meisten Schokolade pro Kopf?', 'Open', 2, 'FunFacts', 'Schweiz');


INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welches Getränk enthält Koffein und wird häufig morgens getrunken?','Open', 0, 'FunFacts', 'Kaffee,Café');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welches Tier schläft am meisten pro Tag?','Open', 1, 'FunFacts', 'Faultier');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welcher chemische Stoff ist verantwortlich für den Geruch von frisch geschnittenem Gras?','Open', 2, 'FunFacts', 'Hexenal');


-- ####################################################################################################
-- ########################################### TRUE FALSE QUESTIONS ###################################
-- ####################################################################################################

-- Informatik
INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Python ist eine Programmiersprache.', 'TrueFalse', 0, 'Informatik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('HTML ist eine Programmiersprache.', 'TrueFalse', 0, 'Informatik', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Ein Byte besteht aus 8 Bits.', 'TrueFalse', 0, 'Informatik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Eine Festplatte speichert Daten dauerhaft.', 'TrueFalse', 0, 'Informatik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('JavaScript wird hauptsächlich auf Servern ausgeführt.', 'TrueFalse', 0, 'Informatik', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Das Internet entstand aus einem militärischen Forschungsprojekt.', 'TrueFalse', 1, 'Informatik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Ein Algorithmus kann nie fehlerhaft sein.', 'TrueFalse', 1, 'Informatik', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Cloud Computing bedeutet, dass Daten auf lokalen Computern gespeichert werden.', 'TrueFalse', 1, 'Informatik',
        0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('SQL steht für Structured Query Language.', 'TrueFalse', 1, 'Informatik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Quantencomputer nutzen die Gesetze der klassischen Physik.', 'TrueFalse', 2, 'Informatik', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Ein Stack arbeitet nach dem Prinzip FIFO.', 'TrueFalse', 2, 'Informatik', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Die Programmiersprache C wurde vor Python entwickelt.', 'TrueFalse', 2, 'Informatik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Machine Learning ist ein Teilgebiet der künstlichen Intelligenz.', 'TrueFalse', 2, 'Informatik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Das Betriebssystem Linux basiert auf Windows.', 'TrueFalse', 2, 'Informatik', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Eine IP-Adresse identifiziert einen Computer in einem Netzwerk.', 'TrueFalse', 2, 'Informatik', 1);

-- Musik
INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Mozart war ein berühmter Komponist.', 'TrueFalse', 0, 'Musik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Eine Gitarre hat normalerweise 6 Saiten.', 'TrueFalse', 0, 'Musik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Jazzmusik entstand im 20. Jahrhundert.', 'TrueFalse', 0, 'Musik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Ein Klavier hat 52 weiße Tasten.', 'TrueFalse', 0, 'Musik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Takt gibt das Tempo eines Musikstücks an.', 'TrueFalse', 0, 'Musik', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Beethoven war taub, als er seine berühmtesten Werke komponierte.', 'TrueFalse', 1, 'Musik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Ein Violinschlüssel wird auch als Bassschlüssel bezeichnet.', 'TrueFalse', 1, 'Musik', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Die Dur-Tonleiter hat keine Halbtonschritte.', 'TrueFalse', 1, 'Musik', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Eine Oktave umfasst 8 Töne.', 'TrueFalse', 1, 'Musik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Das Streichquartett besteht aus vier Streichinstrumenten.', 'TrueFalse', 2, 'Musik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Die Zwölftonmusik wurde von Johann Sebastian Bach entwickelt.', 'TrueFalse', 2, 'Musik', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Eine Synkope ist eine rhythmische Verschiebung.', 'TrueFalse', 2, 'Musik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Klang eines Instruments wird durch seine Obertöne geprägt.', 'TrueFalse', 2, 'Musik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Begriff „Allegro“ beschreibt ein langsames Tempo.', 'TrueFalse', 2, 'Musik', 0);

-- Geografie
INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Nil ist der längste Fluss der Welt.', 'TrueFalse', 0, 'Geografie', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Die Hauptstadt von Deutschland ist München.', 'TrueFalse', 0, 'Geografie', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Afrika ist ein Kontinent.', 'TrueFalse', 0, 'Geografie', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Russland ist das flächenmäßig größte Land der Erde.', 'TrueFalse', 0, 'Geografie', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Amazonas fließt durch Australien.', 'TrueFalse', 0, 'Geografie', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Kilimandscharo ist der höchste Berg Afrikas.', 'TrueFalse', 1, 'Geografie', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Äquator verläuft durch Südamerika, Afrika und Asien.', 'TrueFalse', 1, 'Geografie', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Island liegt im Atlantischen Ozean.', 'TrueFalse', 1, 'Geografie', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Himalaya liegt in Südamerika.', 'TrueFalse', 1, 'Geografie', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Antarktika ist der kälteste Kontinent.', 'TrueFalse', 2, 'Geografie', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Das Tote Meer liegt unter dem Meeresspiegel.', 'TrueFalse', 2, 'Geografie', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Mississippi ist der längste Fluss der USA.', 'TrueFalse', 2, 'Geografie', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Ural gilt als Grenze zwischen Europa und Asien.', 'TrueFalse', 2, 'Geografie', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Japan liegt im Indischen Ozean.', 'TrueFalse', 2, 'Geografie', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Die Sahara ist die größte Wüste der Erde.', 'TrueFalse', 2, 'Geografie', 1);

-- FunFacts
INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Die Erde ist der dritte Planet von der Sonne.', 'TrueFalse', 0, 'FunFacts', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Katzen sind Säugetiere.', 'TrueFalse', 0, 'FunFacts', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Bananen wachsen auf Bäumen.', 'TrueFalse', 0, 'FunFacts', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Honig kann niemals schlecht werden.', 'TrueFalse', 0, 'FunFacts', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Elefanten können nicht springen.', 'TrueFalse', 0, 'FunFacts', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Octopusse haben drei Herzen.', 'TrueFalse', 1, 'FunFacts', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Die menschliche Zunge ist das stärkste Muskelorgan.', 'TrueFalse', 1, 'FunFacts', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Amazonas ist der wasserreichste Fluss der Welt.', 'TrueFalse', 1, 'FunFacts', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Ein Känguru kann rückwärts springen.', 'TrueFalse', 1, 'FunFacts', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Diamanten bestehen hauptsächlich aus Kohlenstoff.', 'TrueFalse', 2, 'FunFacts', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der schnellste Landläufer ist der Gepard.', 'TrueFalse', 2, 'FunFacts', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Quallen sind Fische.', 'TrueFalse', 2, 'FunFacts', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Das längste Tier der Welt ist der Blauwal.', 'TrueFalse', 2, 'FunFacts', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Mensch hat fünf Sinne.', 'TrueFalse', 2, 'FunFacts', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Papier wird aus Holz hergestellt.', 'TrueFalse', 2, 'FunFacts', 1);


-- ####################################################################################################
-- ########################################### ESTIMATE QUESTIONS #####################################
-- ####################################################################################################

-- Estimate Questions: Musik
INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES('Wie viele Tasten hat ein Klavier in der Regel?', 'Estimate', 0, 'Musik', 88);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('In welchem Jahr wurde die Band „The Beatles“ gegründet?', 'Estimate', 0, 'Musik', 1960);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Saiten hat eine Gitarre normalerweise?', 'Estimate', 0, 'Musik', 6);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Sinfonien hat Beethoven komponiert?', 'Estimate', 1, 'Musik', 9);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie alt wurde Wolfgang Amadeus Mozart?', 'Estimate', 1, 'Musik', 35);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Studioalben veröffentlichte Michael Jackson?', 'Estimate', 1, 'Musik', 10);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Takte hat das Lied „Bohemian Rhapsody“ von Queen?', 'Estimate', 2, 'Musik', 360);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Menschen passen in die Wiener Staatsoper?', 'Estimate', 2, 'Musik', 1709);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Noten umfasst eine vollständige Oktave auf einem Klavier (inkl. Halbtöne)?', 'Estimate', 2, 'Musik', 12);

-- Estimate Questions: Informatik
INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('In welchem Jahr wurde die Programmiersprache Java veröffentlicht?', 'Estimate', 0, 'Informatik', 1995);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Bits hat ein Byte?', 'Estimate', 0, 'Informatik', 8);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Tasten hat eine Standard-PC-Tastatur (DE)?', 'Estimate', 0, 'Informatik', 105);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('In welchem Jahr wurde das World Wide Web öffentlich?', 'Estimate', 1, 'Informatik', 1991);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Zeichen umfasst ein IPv4-String maximal (inkl. Punkte)?', 'Estimate', 1, 'Informatik', 15);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Transistoren hatte der Intel 4004, der erste Mikroprozessor?', 'Estimate', 1, 'Informatik', 2300);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Zeichen (inkl. Sonderzeichen) umfasst der ASCII-Standard?', 'Estimate', 2, 'Informatik', 128);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Codezeilen umfasst der Linux-Kernel (ca., 2024)?', 'Estimate', 2, 'Informatik', 30000000);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Jahre alt war Alan Turing bei seinem Tod?', 'Estimate', 2, 'Informatik', 41);

-- Estimate Questions: Geografie
INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Bundesländer hat Deutschland?', 'Estimate', 0, 'Geografie', 16);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Kontinente gibt es auf der Erde?', 'Estimate', 0, 'Geografie', 7);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Länder gibt es weltweit (UN-Mitglieder)?', 'Estimate', 0, 'Geografie', 193);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie hoch ist der Mount Everest in Metern?', 'Estimate', 1, 'Geografie', 8848);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Menschen leben (Stand 2024) in Indien?', 'Estimate', 1, 'Geografie', 1410000000);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Inseln hat Schweden (weltweit höchste Zahl)?', 'Estimate', 1, 'Geografie', 267570);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie lang ist der Amazonas in Kilometern?', 'Estimate', 2, 'Geografie', 6400);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele aktive Vulkane gibt es weltweit?', 'Estimate', 2, 'Geografie', 1500);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Kilometer misst der Äquator?', 'Estimate', 2, 'Geografie', 40075);

-- Estimate Questions: Geschichte
INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('In welchem Jahr wurde die Berliner Mauer gebaut?', 'Estimate', 0, 'Geschichte', 1961);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('In welchem Jahr begann der Zweite Weltkrieg?', 'Estimate', 0, 'Geschichte', 1939);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Jahre dauerte der Dreißigjährige Krieg?', 'Estimate', 0, 'Geschichte', 30);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wann wurde die DDR gegründet?', 'Estimate', 1, 'Geschichte', 1949);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('In welchem Jahr wurde Amerika von Kolumbus entdeckt?', 'Estimate', 1, 'Geschichte', 1492);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('In welchem Jahr begann die Französische Revolution?', 'Estimate', 1, 'Geschichte', 1789);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Menschen starben beim Ausbruch des Vesuvs in Pompeji (geschätzt)?', 'Estimate', 2, 'Geschichte', 16000);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('In welchem Jahr endete das Römische Reich (Westrom)?', 'Estimate', 2, 'Geschichte', 476);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Jahre dauerte das Römische Reich insgesamt (von 27 v.Chr. bis 1453)?', 'Estimate', 2, 'Geschichte',
        1480);


-- Estimate Questions: Funfacts
INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Farben hat ein Regenbogen?', 'Estimate', 0, 'Funfacts', 7);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Augen hat eine Biene?', 'Estimate', 0, 'Funfacts', 5);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Tage hat ein Schaltjahr?', 'Estimate', 0, 'Funfacts', 366);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Liter Wasser passen in ein olympisches Schwimmbecken?', 'Estimate', 1, 'Funfacts', 2500000);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Kilometer pro Stunde kann ein Gepard laufen?', 'Estimate', 1, 'Funfacts', 110);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Wörter hat das längste veröffentlichte Buch der Welt?', 'Estimate', 2, 'Funfacts', 9000000);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Planeten hatte unser Sonnensystem vor der Aberkennung Plutos?', 'Estimate', 2, 'Funfacts', 9);

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer) 
VALUES ('Wie viele Meter ist der Eiffelturm hoch?', 'Estimate', 2, 'Funfacts', 330);


-- ####################################################################################################
-- ########################################### MULTIPLECHOICE QUESTIONS ###############################
-- ####################################################################################################


-- Musik 
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Wer ist der Sänger der Band Queen?', 'MultipleChoice', 0, 'Musik', 'Freddie Mercury', 'Brian May',
        'Roger Taylor', 'John Deacon');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welcher Musiker schrieb die Oper "Die Zauberflöte"?', 'MultipleChoice', 2, 'Musik', 'Wolfgang Amadeus Mozart',
        'Ludwig van Beethoven', 'Johann Sebastian Bach', 'Franz Schubert');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Band veröffentlichte das Album "Abbey Road"?', 'MultipleChoice', 1, 'Musik', 'The Beatles',
        'The Rolling Stones', 'Pink Floyd', 'Led Zeppelin');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welcher Komponist ist bekannt für seine 9. Sinfonie mit dem "Ode an die Freude"?', 'MultipleChoice', 0,
        'Musik', 'Ludwig van Beethoven', 'Johann Sebastian Bach', 'Wolfgang Amadeus Mozart', 'Franz Schubert');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Instrument gehört nicht zu den Blechblasinstrumenten?', 'MultipleChoice', 0, 'Musik', 'Geige',
        'Trompete', 'Posaune', 'Tuba');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Wer ist die Leadsängerin der Band Blondie?', 'MultipleChoice', 0, 'Musik', 'Debbie Harry', 'Stevie Nicks',
        'Joan Jett', 'Pat Benatar');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('In welchem Genre ist Taylor Swift hauptsächlich bekannt geworden?', 'MultipleChoice', 0, 'Musik', 'Country',
        'Pop', 'Rock', 'R&B');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Band ist bekannt für das Lied "Bohemian Rhapsody"?', 'MultipleChoice', 0, 'Musik', 'Queen',
        'Led Zeppelin', 'Pink Floyd', 'The Beatles');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welcher Musiker wird oft als "King of Pop" bezeichnet?', 'MultipleChoice', 1, 'Musik', 'Michael Jackson',
        'Elvis Presley', 'Prince', 'James Brown');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Musikgenre entstand in den späten 1970er Jahren und ist von elektronischen Klängen geprägt?',
        'MultipleChoice', 1, 'Musik', 'Elektronische Tanzmusik (EDM)', 'Jazz', 'Blues', 'Klassik');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches dieser Instrumente ist ein Saiteninstrument?', 'MultipleChoice', 1, 'Musik', 'Gitarre', 'Klarinette',
        'Flöte', 'Schlagzeug');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Oper ist bekannt für die Arie "Nessun Dorma"?', 'MultipleChoice', 1, 'Musik', 'Turandot', 'Carmen',
        'La Bohème', 'Aida');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Wer komponierte die Brandenburgischen Konzerte?', 'MultipleChoice', 1, 'Musik', 'Johann Sebastian Bach',
        'Georg Friedrich Händel', 'Antonio Vivaldi', 'Joseph Haydn');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Tonintervall ist das kleinste in der westlichen Musik?', 'MultipleChoice', 2, 'Musik', 'Halbton',
        'Ganzton', 'Terz', 'Quinte');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist eine Fuge in der Musik?', 'MultipleChoice', 2, 'Musik',
        'Eine Kompositionsform, die auf der Imitation eines Themas basiert', 'Ein schneller Tanz im 18. Jahrhundert',
        'Ein Solostück für ein Blasinstrument', 'Ein Abschnitt in einem Oratorium');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Skala besteht aus nur fünf Noten?', 'MultipleChoice', 2, 'Musik', 'Pentatonische Skala', 'Dur-Skala',
        'Moll-Skala', 'Chromatische Skala');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist der Unterschied zwischen Dur und Moll in der Musiktheorie?', 'MultipleChoice', 2, 'Musik',
        'Dur klingt hell und fröhlich, Moll eher dunkel und traurig', 'Dur ist immer schneller als Moll',
        'Moll hat mehr Noten als Dur', 'Sie sind austauschbar');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welcher Begriff beschreibt das gleichzeitige Erklingen mehrerer Töne?', 'MultipleChoice', 2, 'Musik',
        'Harmonie', 'Melodie', 'Rhythmus', 'Tempo');


-- Geografie
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist die Hauptstadt von Frankreich?', 'MultipleChoice', 0, 'Geografie', 'Paris', 'Berlin', 'Rom', 'Madrid');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welcher Ozean ist der größte der Welt?', 'MultipleChoice', 0, 'Geografie', 'Pazifischer Ozean',
        'Atlantischer Ozean', 'Indischer Ozean', 'Arktischer Ozean');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Wie viele Kontinente gibt es auf der Erde?', 'MultipleChoice', 0, 'Geografie', '7', '5', '6', '8');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welcher Fluss fließt durch London?', 'MultipleChoice', 0, 'Geografie', 'Themse', 'Seine', 'Rhein', 'Donau');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Land ist bekannt für die Pyramiden von Gizeh?', 'MultipleChoice', 0, 'Geografie', 'Ägypten',
        'Griechenland', 'Italien', 'Mexiko');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Gebirge trennt Europa und Asien?', 'MultipleChoice', 1, 'Geografie', 'Ural', 'Alpen', 'Himalaya',
        'Anden');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist der höchste Berg Afrikas?', 'MultipleChoice', 1, 'Geografie', 'Kilimandscharo', 'Mount Everest',
        'Mont Blanc', 'Elbrus');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Land ist der größte Inselstaat der Welt?', 'MultipleChoice', 1, 'Geografie', 'Indonesien', 'Japan',
        'Philippinen', 'Australien');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Durch welche Meerenge verlaufen die Schiffe vom Atlantik in den Pazifik am südlichsten Punkt Südamerikas?',
        'MultipleChoice', 1, 'Geografie', 'Magellanstraße', 'Straße von Gibraltar', 'Beringstraße', 'Suezkanal');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Wüste ist die größte heiße Wüste der Welt?', 'MultipleChoice', 1, 'Geografie', 'Sahara', 'Gobi',
        'Arabische Wüste', 'Kalahari');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Stadt liegt sowohl in Europa als auch in Asien?', 'MultipleChoice', 2, 'Geografie', 'Istanbul',
        'Moskau', 'Kairo', 'Dubai');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist die größte nicht-kontinentale Insel der Welt?', 'MultipleChoice', 2, 'Geografie', 'Grönland',
        'Madagaskar', 'Borneo', 'Neuguinea');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches ist der tiefste Punkt der Erde?', 'MultipleChoice', 2, 'Geografie', 'Marianengraben', 'Totes Meer',
        'Puerto-Rico-Graben', 'Baikalsee');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Land hat die meisten Zeitzonen?', 'MultipleChoice', 2, 'Geografie',
        'Frankreich (inkl. Überseegebiete)', 'Russland', 'USA', 'China');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Gewässer ist der größte Süßwassersee der Welt (nach Volumen)?', 'MultipleChoice', 2, 'Geografie',
        'Baikalsee', 'Oberer See', 'Tanganjikasee', 'Michigansee');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist die Hauptstadt von Australien?', 'MultipleChoice', 1, 'Geografie', 'Canberra', 'Sydney', 'Melbourne',
        'Brisbane');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Land hat die längste Küstenlinie?', 'MultipleChoice', 2, 'Geografie', 'Kanada', 'USA', 'Russland',
        'China');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Wie viele Bundesländer hat Deutschland?', 'MultipleChoice', 0, 'Geografie', '16', '12', '14', '18');

-- Informatik 
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist ein Algorithmus?', 'MultipleChoice', 0, 'Informatik',
        'Eine Schritt-für-Schritt-Anleitung zur Lösung eines Problems', 'Ein Computerprogramm', 'Ein Hardware-Bauteil',
        'Ein Dateiformat');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches der folgenden ist ein Webbrowser?', 'MultipleChoice', 0, 'Informatik', 'Chrome', 'Word', 'Excel',
        'PowerPoint');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist RAM?', 'MultipleChoice', 0, 'Informatik', 'Random Access Memory', 'Read Access Memory',
        'Run Application Module', 'Remote Access Management');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Einheit wird zur Messung der Datenspeicherung verwendet?', 'MultipleChoice', 0, 'Informatik', 'Byte',
        'Hertz', 'Volt', 'Ampere');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist die Funktion eines Betriebssystems?', 'MultipleChoice', 0, 'Informatik',
        'Verwaltung von Hard- und Software', 'Erstellung von Webseiten', 'Bearbeitung von Bildern', 'Schutz vor Viren');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Programmiersprache wurde von Guido van Rossum entwickelt?', 'MultipleChoice', 1, 'Informatik', 'Python',
        'Java', 'C++', 'JavaScript');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist eine Firewall?', 'MultipleChoice', 1, 'Informatik',
        'Ein Sicherheitssystem, das den Netzwerkverkehr überwacht und filtert', 'Ein Programm zur Bildbearbeitung',
        'Ein Gerät zur Speicherung von Daten', 'Ein Dateimanager');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist ein SQL-Befehl?', 'MultipleChoice', 1, 'Informatik',
        'Ein Befehl zur Abfrage oder Manipulation von Daten in einer Datenbank', 'Ein Kommando in einem Texteditor',
        'Eine Anweisung an einen Drucker', 'Ein Befehl zur Systemwiederherstellung');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist der Zweck eines Compilers?', 'MultipleChoice', 1, 'Informatik',
        'Quellcode in Maschinencode zu übersetzen', 'Dateien zu komprimieren', 'Viren zu erkennen',
        'Das Betriebssystem zu starten');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist der Unterschied zwischen HTTP und HTTPS?', 'MultipleChoice', 1, 'Informatik',
        'HTTPS ist die sichere Version von HTTP mit Verschlüsselung', 'HTTP ist schneller als HTTPS',
        'HTTPS wird nur für Bilder verwendet', 'Es gibt keinen Unterschied');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist ein rekursiver Algorithmus?', 'MultipleChoice', 2, 'Informatik',
        'Ein Algorithmus, der sich selbst aufruft, um ein Problem zu lösen',
        'Ein Algorithmus, der in einer Schleife ausgeführt wird', 'Ein Algorithmus, der zufällige Zahlen generiert',
        'Ein Algorithmus, der nur einmal ausgeführt wird');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist die Turing-Maschine?', 'MultipleChoice', 2, 'Informatik',
        'Ein theoretisches Modell eines Computers, das die grundlegenden Konzepte der Berechenbarkeit beschreibt',
        'Ein früher mechanischer Computer', 'Ein Algorithmus zur Verschlüsselung von Daten', 'Ein Netzwerkprotokoll');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist Polymorphismus in der objektorientierten Programmierung?', 'MultipleChoice', 2, 'Informatik',
        'Die Fähigkeit von Objekten verschiedener Klassen, auf dieselbe Nachricht unterschiedlich zu reagieren',
        'Die Erstellung mehrerer Instanzen einer Klasse', 'Das Vererben von Eigenschaften von einer Klasse zur anderen',
        'Das Verbergen von Implementierungsdetails');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist der Unterschied zwischen einem Compiler und einem Interpreter?', 'MultipleChoice', 2, 'Informatik',
        'Ein Compiler übersetzt den gesamten Code vor der Ausführung, ein Interpreter zeilenweise während der Ausführung',
        'Ein Compiler ist schneller als ein Interpreter', 'Ein Interpreter wird nur für Webseiten verwendet',
        'Es gibt keinen Unterschied in ihrer Funktion');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist ein Binärbaum in der Datenstruktur?', 'MultipleChoice', 2, 'Informatik',
        'Eine Baumstruktur, bei der jeder Knoten maximal zwei Kindknoten hat',
        'Ein Baum, der nur aus Nullen und Einsen besteht', 'Ein Baum, der in der Informatik nicht verwendet wird',
        'Ein Baum, der nur aus Blättern besteht');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Programmiersprache wird hauptsächlich für iOS-Apps verwendet?', 'MultipleChoice', 1, 'Informatik',
        'Swift', 'Java', 'Python', 'C#');


INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was bedeutet "HTML"?', 'MultipleChoice', 0, 'Informatik', 'HyperText Markup Language',
        'HighText Machine Language', 'Hyperlinking Text Mark Language', 'Hyper Tool Multi Language');


INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was beschreibt der Begriff „Big O“ in der Informatik?',
        'MultipleChoice',
        2,
        'Informatik',
        'Die asymptotische Laufzeitanalyse von Algorithmen',
        'Die Größe von Objekten im Arbeitsspeicher',
        'Die Stromaufnahme eines Prozessors',
        'Die Anzahl der Operationen in einem Programm');


-- Fun-Facts 
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Wie viele Herzen hat ein Krake?', 'MultipleChoice', 0, 'Fun-Facts', '3', '1', '2', '4');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Gemüse ist botanisch gesehen eine Frucht?', 'MultipleChoice', 0, 'Fun-Facts', 'Tomate', 'Karotte',
        'Kartoffel', 'Zwiebel');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches ist das einzige Tier, das nicht springen kann?', 'MultipleChoice', 0, 'Fun-Facts', 'Elefant',
        'Känguru', 'Hase', 'Frosch');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Aus welchem Land kommt die Pizza ursprünglich?', 'MultipleChoice', 0, 'Fun-Facts', 'Italien', 'USA',
        'Frankreich', 'Deutschland');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist das längste Wort im Deutschen, das keine Selbstlaute enthält?', 'MultipleChoice', 0, 'Fun-Facts',
        'Rhythmus', 'Streng', 'Schwanz', 'Durst');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Tier kann nur rückwärts gehen, wenn es schwimmt?', 'MultipleChoice', 1, 'Fun-Facts', 'Fisch', 'Krabbe',
        'Garnele', 'Qualle');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Wie viele Zähne hat ein ausgewachsener Mensch normalerweise?', 'MultipleChoice', 1, 'Fun-Facts', '32', '28',
        '30', '36');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist der Hauptbestandteil von Bleistiftminen?', 'MultipleChoice', 1, 'Fun-Facts', 'Graphit', 'Blei',
        'Kohle', 'Ton');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches ist der einzige Planet in unserem Sonnensystem, der gegen den Uhrzeigersinn rotiert?',
        'MultipleChoice', 1, 'Fun-Facts', 'Venus', 'Mars', 'Jupiter', 'Uranus');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Farbe hat der Himmel auf dem Mars tagsüber?', 'MultipleChoice', 1, 'Fun-Facts',
        'Butterscotch (bräunlich-gelb)', 'Blau', 'Grün', 'Rot');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Wie viele Minuten braucht das Licht der Sonne, um die Erde zu erreichen?', 'MultipleChoice', 2, 'Fun-Facts',
        'Etwa 8 Minuten und 20 Sekunden', 'Etwa 1 Minute', 'Etwa 30 Minuten', 'Etwa 2 Stunden');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche historische Figur soll eine "sprechende" Katze besessen haben?', 'MultipleChoice', 2, 'Fun-Facts',
        'Sir Isaac Newton', 'Leonardo da Vinci', 'Albert Einstein', 'Marie Curie');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches ist das größte Lebewesen der Welt?', 'MultipleChoice', 2, 'Fun-Facts', 'Blauwal', 'Elefant',
        'Riesenkalmar', 'Honigpilz');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Wie viel Prozent der menschlichen DNA ist identisch mit der einer Banane?', 'MultipleChoice', 2, 'Fun-Facts',
        'Etwa 50%', 'Etwa 10%', 'Etwa 25%', 'Etwa 75%');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches ist das einzige Säugetier, das fliegen kann?', 'MultipleChoice', 2, 'Fun-Facts', 'Fledermaus', 'Vogel',
        'Insekt', 'Gleithörnchen');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Tierart nutzt ihren eigenen Po als Notfall-Atemgerät?', 'MultipleChoice', 0, 'Fun-Facts',
        'Die Schildkröte', 'Der Delfin', 'Der Seestern', 'Die Giraffe');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was passiert, wenn man eine Banane mit einem Geigerzähler untersucht?', 'MultipleChoice', 1, 'Fun-Facts',
        'Sie zeigt eine geringe Radioaktivität', 'Sie explodiert bei 88 Bananen pro Stunde',
        'Sie sendet Morsezeichen aus', 'Sie wird plötzlich grün vor Neid');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, CorrectAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Tierart kann Monate ohne Kopf weiterleben?', 'MultipleChoice', 2, 'Fun-Facts', 'Kakerlaken', 'Frösche',
        'Mäuse', 'Kolibris');

COMMIT; 