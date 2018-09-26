CREATE LOGIN new_user
WITH PASSWORD='password';

USE master
GO

CREATE USER new_user FOR LOGIN new_user;
GO

GRANT CREATE DATABASE TO new_user;
GO

 USE filmography;
 GO


CREATE TABLE movies(
name nvarchar PRIMARY KEY NOT NULL,
description ntext,
year date,
genres nchar(20),
country nvarchar,
budget money
);
GO

CREATE TABLE actors(
surname nvarchar,
name nvarchar,
birthday date,
motherland nvarchar,
number_of_movies int
 );
 GO

 CREATE TABLE producer(
 surname nvarchar,
 name nvarchar,
 birthday date,
 motherland nvarchar
 );
 GO



