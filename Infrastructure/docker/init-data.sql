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



INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wer komponierte die 9. Sinfonie?', 'Open', 2, 'Musik', 'Ludwig van Beethoven');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie heißt die Hauptstadt von Australien?', 'Open', 1, 'Geografie', 'Canberra');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Was bedeutet "HTTP" im Internet?', 'Open', 1, 'Informatik', 'Hypertext Transfer Protocol');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welches Tier ist das größte Landsäugetier?', 'Open', 0, 'Fun-Facts', 'Elefant');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie viele Tasten hat ein klassisches Klavier?', 'Open', 1, 'Musik', '88');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welcher Kontinent hat die meisten Länder?', 'Open', 1, 'Geografie', 'Afrika');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Was ist die Programmiersprache von Microsofts .NET?', 'Open', 0, 'Informatik', 'C#');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wie viele Farben hat ein Regenbogen?', 'Open', 0, 'Fun-Facts', '7');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Wer schrieb "Die Leiden des jungen Werther"?', 'Open', 2, 'Musik', 'Johann Wolfgang von Goethe');

INSERT INTO OpenQuestion (Question, Typ, Difficulty, Category, Answer)
VALUES ('Welcher Fluss fließt durch Paris?', 'Open', 0, 'Geografie', 'Seine');



INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Das Internet wurde in den 1980er Jahren erfunden.', 'TrueFalse', 1, 'Informatik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Nil ist der längste Fluss der Welt.', 'TrueFalse', 2, 'Geografie', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Mozart war ein berühmter Komponist aus Italien.', 'TrueFalse', 0, 'Musik', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Python ist eine Programmiersprache.', 'TrueFalse', 0, 'Informatik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Eiffelturm steht in Berlin.', 'TrueFalse', 0, 'Geografie', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Die Erde ist der dritte Planet von der Sonne.', 'TrueFalse', 1, 'Fun-Facts', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Informatik ist die Wissenschaft der Information.', 'TrueFalse', 1, 'Informatik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Die Beatles waren eine berühmte Rockband.', 'TrueFalse', 0, 'Musik', 1);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Der Mount Everest liegt in den Alpen.', 'TrueFalse', 0, 'Geografie', 0);

INSERT INTO TrueFalseQuestion (Question, Typ, Difficulty, Category, TrueFalse)
VALUES ('Das Licht bewegt sich schneller als Schall.', 'TrueFalse', 0, 'Fun-Facts', 1);


INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Saiten hat eine klassische Gitarre?', 'Estimate', 0, 'Musik', '6');

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Länder gibt es ungefähr in Afrika?', 'Estimate', 1, 'Geografie', '54');

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Zeilen hat ein Standard-ASCII-Code?', 'Estimate', 2, 'Informatik', '128');

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Stunden hat ein Tag?', 'Estimate', 0, 'Fun-Facts', '24');

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie alt wurde Wolfgang Amadeus Mozart?', 'Estimate', 2, 'Musik', '35');

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Bundesländer hat Deutschland?', 'Estimate', 1, 'Geografie', '16');

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Bits hat ein Byte?', 'Estimate', 0, 'Informatik', '8');

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Planeten hat unser Sonnensystem?', 'Estimate', 1, 'Fun-Facts', '8');

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Saiten hat ein Klavier?', 'Estimate', 1, 'Musik', '88');

INSERT INTO EstimateQuestion (Question, Typ, Difficulty, Category, RightAnswer)
VALUES ('Wie viele Länder haben eine Fläche größer als 1 Million km²?', 'Estimate', 2, 'Geografie', '17');


INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, RightAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Wer ist der Sänger der Band Queen?', 'MultipleChoice', 0, 'Musik', 'Freddie Mercury', 'Brian May',
        'Roger Taylor', 'John Deacon');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, RightAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist die Hauptstadt von Australien?', 'MultipleChoice', 1, 'Geografie', 'Canberra', 'Sydney', 'Melbourne',
        'Brisbane');

INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, RightAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Programmiersprache wird hauptsächlich für iOS-Apps verwendet?', 'MultipleChoice', 1, 'Informatik',
        'Swift', 'Java', 'Python', 'C#');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, RightAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welcher Musiker schrieb die Oper "Die Zauberflöte"?', 'MultipleChoice', 2, 'Musik', 'Wolfgang Amadeus Mozart',
        'Ludwig van Beethoven', 'Johann Sebastian Bach', 'Franz Schubert');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, RightAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welches Land hat die längste Küstenlinie?', 'MultipleChoice', 2, 'Geografie', 'Kanada', 'USA', 'Russland',
        'China');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, RightAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was bedeutet "HTML"?', 'MultipleChoice', 0, 'Informatik', 'HyperText Markup Language',
        'HighText Machine Language', 'Hyperlinking Text Mark Language', 'Hyper Tool Multi Language');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, RightAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welche Band veröffentlichte das Album "Abbey Road"?', 'MultipleChoice', 1, 'Musik', 'The Beatles',
        'The Rolling Stones', 'Pink Floyd', 'Led Zeppelin');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, RightAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Wie viele Bundesstaaten hat Deutschland?', 'MultipleChoice', 0, 'Geografie', '16', '12', '14', '18');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, RightAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Welcher Algorithmus wird oft zum Sortieren verwendet?', 'MultipleChoice', 1, 'Informatik', 'Quicksort',
        'Bubblesort', 'Mergesort', 'Heapsort');
INSERT INTO MultipleChoiceQuestion (Question, Typ, Difficulty, Category, RightAnswer, FalseAnswer1, FalseAnswer2,
                                    FalseAnswer3)
VALUES ('Was ist die chemische Formel für Wasser?', 'MultipleChoice', 0, 'Fun-Facts', 'H2O', 'CO2', 'NaCl', 'O2');

