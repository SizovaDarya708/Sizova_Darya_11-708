/*CREATE LOGIN new_user
WITH PASSWORD='password';*/

USE master
GO

/*CREATE USER new_user FOR LOGIN new_user;
GO*/

GRANT CREATE DATABASE TO new_user;
GO

 USE filmography;
 GO


CREATE TABLE movies(
movie_name nvarchar(30),
movie_description ntext,
movie_year date UNIQUE CHECK(movie_year>1990 AND movie_year < YEAR(GETDATE()+10)),
genres nchar(20),
country nvarchar,
budget money CHECK(budget>10000)
PRIMARY KEY(movie_name, movie_year)
);
GO

CREATE TABLE actors(
surname nvarchar UNIQUE,
actor_name nvarchar UNIQUE,
birthday date UNIQUE,
motherland nvarchar,
number_of_movies int CHECK(number_of_movies>5)
CONSTRAINT Const_surname UNIQUE(surname, actor_name, birthday)
 );
 GO

ALTER TABLE actors ADD column_Seq1 VARCHAR NULL; 
CREATE SEQUENCE actors.Seq1 AS INT START WITH 1 INCREMENT BY 1;
GO

 CREATE TABLE producer(
 surname nvarchar,
 producer_name nvarchar,
 birthday date,
 motherland nvarchar
 );
 GO

 INSERT INTO producer (motherland)VALUES (.USA) ;  
 GO

 ALTER TABLE producer ADD column_Seq2 VARCHAR NULL; 
 GO

 CREATE SEQUENCE producer.Seq2 AS INT START WITH 1 INCREMENT BY 1;
 GO

 /*“естовые значени€*/
  INSERT [movies](movie_name, movie_description, movie_year, genres, country, budget)
  VALUES
  ('Titanic', 'ќдин из рейтинговых фильмов', 1997, 'мелодрама',.USA,200000000),
  ('The Shawshank Redemption', '....', 1994, 'драма',.USA,25000000),
  ('The Green Mile', '....', 1999, 'драма',.USA,60000000),
  ('The Shawshank Redemption', '....', 1994, 'драма',.USA,25000000),
  ('Forrest Gump', '....', 1994, 'драма',.USA,55000000),
  ('Leon', '....', 1994, 'драма',.FRANCE,115000000);
  GO

  INSERT [actors](actor_name, surname, birthday, motherland, number_of_movies)
  VALUES
  ('Gary', 'Oldman', 21-03-1958,.UK, 30),
  ('Natalie', 'Portman', 09-06-1981,.IZRAIL, 40),
  ('Leonardo', 'DiCaprio',11-11-1974,.UK,50),
  ('Tom', 'Hanks', 09-07-1956,.UK, 42),
  ('Ellen', 'Page', 21-02-1987,.CANADA, 15),
  ('Scarlett', 'Johansson', 22-11-1984, .UK, 35);   
  GO

  INSERT [producer](producer_name, surname, birthday, motherland)
  VALUES
  ('Guy', 'Richie', 10-09-1968, .UK),
  ('Quentin', 'Tarantino', 27-03-1963, .USA),
  ('Steven', 'Spielberg', 18-12-1946, .USA),
  ('Christopher', 'Nolan', 30-07-1970, .UK),
  ('Wes', 'Anderson', 01-05-1969, .USA),
  ('Frank', 'Darabont', 28-01-1959, .FRANCE);
  GO









