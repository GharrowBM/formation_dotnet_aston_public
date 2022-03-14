-- Insertion d'une valeur dans la table Adresses

INSERT INTO Adresses (Valeur) VALUES ('404, Rue des chatons 59000 LILLE');

-- Insertion d'une personne dans la table Personnes

INSERT INTO Personnes (Firstname, Lastname, AdresseId) VALUES ('John', 'SMITH', 1);

-- Selection de toutes les colonnes dans la table Personnes

SELECT * FROM Personnes;

-- Modification des valeurs de la personne n°1 dans la table Personnes

UPDATE Personnes SET Firstname='Mikael' WHERE Id = 1;

-- Selection des prénoms des personnes depuis la table Personnes

SELECT Firstname FROM Personnes;

-- Selection des données de personne et de son adresse via la jointure

SELECT p.Firstname, p.Lastname, a.valeur AS 'Adresse' FROM Personnes AS p JOIN Adresses AS a ON p.AdresseId = a.Id;

-- Suppression de la personne ayant l'Id n°1

DELETE FROM Personnes WHERE Id = 1;