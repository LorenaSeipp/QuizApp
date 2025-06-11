-- SORT QUESTIONS
-- Informatik
DELETE FROM SortQuestion;
INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Programmiersprachen nach ihrem Erscheinungsjahr (alt → neu):', 'Sort', 0, 'Informatik', 'C', 'Java', 'Python', 'Go');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Datenstrukturen nach ihrer Zugriffskomplexität (einfach → komplex):', 'Sort', 1, 'Informatik', 'Array', 'Linked List', 'Stack', 'Heap');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Erfindungen der Informatik zeitlich (früh → spät):', 'Sort', 2, 'Informatik', 'Transistor', 'Mikroprozessor', 'Internet', 'Smartphone');

-- Musik
INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Musikrichtungen nach Entstehung (früh → spät):', 'Sort', 0, 'Musik', 'Klassik', 'Jazz', 'Rock', 'Hip-Hop');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Komponisten nach Geburtsjahr (früh → spät):', 'Sort', 1, 'Musik', 'Bach', 'Mozart', 'Beethoven', 'Schumann');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Alben nach ihrem Erscheinungsjahr (alt → neu):', 'Sort', 2, 'Musik', 'Thriller', 'Nevermind', 'Back to Black', '25');

-- Geografie
INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Länder nach ihrer Fläche (klein → groß):', 'Sort', 0, 'Geografie', 'Niederlande', 'Deutschland', 'Brasilien', 'Russland');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Flüsse nach ihrer Länge (kurz → lang):', 'Sort', 1, 'Geografie', 'Elbe', 'Donau', 'Amazonas', 'Nil');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Hauptstädte geografisch (Westen → Osten):', 'Sort', 2, 'Geografie', 'Lissabon', 'Berlin', 'Moskau', 'Tokio');

-- Fun-Facts
INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Tiere nach ihrer Geschwindigkeit (langsam → schnell):', 'Sort', 0, 'FunFacts', 'Faultier', 'Mensch', 'Hund', 'Gepard');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Snacks nach Kalorien (wenig → viel):', 'Sort', 1, 'FunFacts', 'Apfel', 'Popcorn', 'Schokolade', 'Erdnussbutter');

INSERT INTO SortQuestion (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4) VALUES
    ('Ordne diese Länder nach Anzahl der Feiertage pro Jahr (wenig → viel):', 'Sort', 2, 'FunFacts', 'USA', 'Deutschland', 'Indien', 'Japan');

-- OPEN QUESTIONS
DELETE FROM OpenQuestion;

-- Informatik
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('Wie nennt man den Bereich eines Computers, der Daten kurzfristig speichert?','Open', 0, 'Informatik', 'RAM;Arbeitsspeicher;Random Access Memory');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('Welche Programmiersprache wird hauptsächlich für Webentwicklung verwendet und läuft im Browser?','Open', 1, 'Informatik', 'JavaScript;JS');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('Wie heißt das Verschlüsselungsverfahren mit öffentlichem und privatem Schlüssel?','Open', 2, 'Informatik', 'Asymmetrisch;Asymmetrische Verschlüsselung');

-- Musik
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('Wie nennt man eine Gruppe von vier Musikern, die zusammen spielen?','Open', 0, 'Musik', 'Quartett');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('Wie nennt man die Tonart mit einem Kreuz-Vorzeichen?','Open', 1, 'Musik', 'G-Dur;G Dur');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('Wie nennt man die Kompositionstechnik, bei der ein Thema rückwärts gespielt wird?','Open', 2, 'Musik', 'Krebs');

-- Geografie
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('Welcher Kontinent liegt direkt südlich von Europa?','Open', 0, 'Geografie', 'Afrika');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('Wie heißt der höchste Berg Afrikas?','Open', 1, 'Geografie', 'Kilimandscharo;Kilimanjaro');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('In welchem Land liegt das geographische Zentrum Europas (laut einer Berechnung in der Nähe von Polotsk)?','Open', 2, 'Geografie', 'Belarus;Weißrussland');

-- Fun-Facts
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('Welches Getränk enthält Koffein und wird häufig morgens getrunken?','Open', 0, 'FunFacts', 'Kaffee;Café');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('Welches Tier schläft am meisten pro Tag?','Open', 1, 'FunFacts', 'Faultier');
INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer) VALUES
    ('Welcher chemische Stoff ist verantwortlich für den Geruch von frisch geschnittenem Gras?','Open', 2, 'FunFacts', 'Hexenal');
