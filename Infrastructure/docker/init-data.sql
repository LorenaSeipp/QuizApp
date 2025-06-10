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
