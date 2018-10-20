USE master;
GO
USE filmography;
GO


ALTER TABLE movies ADD FOREIGN KEY (movie_ID) REFERENCES Actors (ID)
ON DELETE CASCADE;
GO
ALTER TABLE movies ADD FOREIGN KEY (movie_id) REFERENCES producer (ID) 
ON DELETE CASCADE;
GO

ALTER TABLE producer ADD best_movie_ID nvarchar(30);
GO

ALTER TABLE producer ADD FOREIGN KEY (best_movie_ID) REFERENCES movie(movie_id);
ALTER TABLE actors ADD CONSTRAINT actor_motherland_default DEFAULT 'USA' FOR motherland;
GO
ALTER TABLE producer ADD CONSTRAINT producer_motherland_default DEFAULT 'USA' FOR motherland;
GO
ALTER TABLE actors DROP CONSTRAINT number_of_movies;
GO
ALTER TABLE movies ADD CONSTRAINT budget_limit CHECK (budget> 1000);
GO

CREATE TABLE movie_genres(
genre nchar(20),
movie_name nvarchar(30));
GO
/*надо скопировать жанры в таблицу жанров из таблицы фильмы*/
INSERT INTO movie_genres(genre, movie_name) SELECT genres, movie_name
FROM movies;

ALTER TABLE actors ADD CONSTRAINT motherland_select
 CHECK (motherland = 'USA' or motherland = 'UK' 
 or motherland = 'Russia' or motherland = 'France'
 or motherland = 'Germany');
 GO

 ALTER TABLE producer ADD CONSTRAINT motherland_select
 CHECK (motherland = 'USA' or motherland = 'UK' 
 or motherland = 'Russia' or motherland = 'France'
 or motherland = 'Germany');
 GO

 ALTER TABLE actors ADD CONSTRAINT actors_birthday_check
 CHECK(birthday < GETDATE);
 ALTER TABLE producer ADD CONSTRAINT actors_birthday_check
 CHECK(birthday < GETDATE);
 GO

 /* Создание индекса*/
 CREATE NONCLUSTERED INDEX IX_actors_name_surname 
 ON actors (surname, actor_name);
 GO  




 




