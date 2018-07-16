USE [Rewards]
GO

CREATE PROCEDURE [dbo].[CreateMedal] @name nvarchar(50), @material nvarchar(10)
AS
INSERT INTO medals
VALUES (@name, @material)
SELECT SCOPE_IDENTITY()

CREATE PROCEDURE [dbo].[CreatePerson]  @name nvarchar(30), @surname nvarchar(30), @dateOfBirth date, @age int, @city nvarchar(30), @street nvarchar(30), @numberOfHouse nvarchar(30)
AS
INSERT INTO people
VALUES (@name, @surname, @dateOfBirth, @age, @city, @street, @numberOfHouse)
SELECT SCOPE_IDENTITY()

CREATE PROCEDURE [dbo].[CreateReward] @peopleId int, @medalsId int
AS
INSERT INTO medalsOfPeople
VALUES (@peopleId, @medalsId)

CREATE PROCEDURE [dbo].[RemoveMedal] @id int
AS
DELETE FROM medals WHERE id = @id

CREATE PROCEDURE [dbo].[RemovePerson] @id int
AS
DELETE FROM people WHERE id = @id

CREATE PROCEDURE [dbo].[RemoveReward] @peopleId int, @medalsId int
AS
DELETE FROM medalsOfPeople WHERE peopleId = @peopleId AND medalsId = @medalsId

CREATE PROCEDURE [dbo].[UpdateMedal] @id int, @name nvarchar(50), @material nvarchar(10)
AS
UPDATE Medals SET name = @name, material = @material
WHERE id = @id

CREATE PROCEDURE [dbo].[UpdatePerson]  @id int, @name nvarchar(30), @surname nvarchar(30), @dateOfBirth date, @age int, @city nvarchar(30), @street nvarchar(30), @numberOfHouse nvarchar(30)
AS
UPDATE People SET name = @name, surname = @surname, dateOfBirth = @dateOfBirth, age = @age, city = @city, street = @street, numberOfHouse = @numberOfHouse 
WHERE id = @id

CREATE PROCEDURE [dbo].[ShowAllMedals] 
AS
SELECT * FROM Medals

CREATE PROCEDURE [dbo].[ShowAllPeople]
AS
SELECT * FROM People

CREATE PROCEDURE [dbo].[ShowAllRewards]
AS
SELECT people.name, people.surname, medals.material, medals.name FROM people 
JOIN medalsOfPeople ON people.id = medalsOfPeople.peopleId
JOIN medals ON medals.id = medalsOfPeople.medalsId

CREATE PROCEDURE [dbo].[ShowAllIdInRewards]
AS
SELECT * FROM medalsOfPeople

CREATE PROCEDURE [dbo].[FindRewardByMedalID] @id int
AS
SELECT * FROM medalsOfPeople WHERE medalsId = @id

CREATE PROCEDURE [dbo].[FindRewardByPersonID] @id int
AS
SELECT * FROM medalsOfPeople WHERE peopleId = @id

CREATE PROCEDURE [dbo].[ReturnMedalById] @id int
AS
SELECT * FROM medals WHERE id = @id

CREATE PROCEDURE [dbo].[ReturnPersonByID] @id int
AS
SELECT * FROM people WHERE id = @id

CREATE PROCEDURE [dbo].[ReturnMedalId] @name nvarchar(50)
AS
SELECT id from medals 
WHERE @name = name

CREATE PROCEDURE [dbo].[ReturnPersonId] @name nvarchar(30), @surname nvarchar(30), @dateOfBirth date
AS
SELECT id from People 
WHERE (@name = name AND @surname = surname AND @dateOfBirth = dateOfBirth)
