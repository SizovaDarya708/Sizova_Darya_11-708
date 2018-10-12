USE master;  
GO

/*База данных из трех файловых групп, одного журнала
в первичной группе два файла -Doc_1, Doc_2 на различных дисках*/

CREATE DATABASE Documents
ON PRIMARY 
	(NAME = Doc_1,  
    FILENAME = 'C:\BD.mdf',  
    SIZE = 100MB,  
    MAXSIZE = 200MB,  
    FILEGROWTH = 20MB), 
    ( NAME = Doc_2,  
    FILENAME = 'D:\BD.mdf',  
    SIZE = 100MB,  
    MAXSIZE = 200MB,  
    FILEGROWTH = 20MB),
	/*Две вторичные группы Doc2, Doc3, вторая группа по умолчанию */
FILEGROUP Doc2 DEFAULT 
   (NAME = Doc_3,  
    FILENAME = 'C:\BD.ndf', 
	SIZE = UNLIMITED,   
    FILEGROWTH = 10MB),
FILEGROUP Doc3  
	(NAME = Doc_4,  
    FILENAME = 'C:\BD.ndf',  
    SIZE = 100MB,  
    MAXSIZE = 100MB,  
    FILEGROWTH = 20)
LOG ON
(NAME = DocLog,  
    FILENAME = 'C:\BD.ldf',  
    SIZE = 100MB,  
    MAXSIZE = 200MB,  
    FILEGROWTH = 15%);
GO  

/*Удаление 2ой вторичной группы и по умолчанию первичную группу*/
ALTER DATABASE Documents REMOVE FILEGROUP Doc2;
ALTER DATABASE Documents MODIFY FILEGroup  Doc_3 DEFAULT;

CREATE TABLE PST
( NOMDOG int PRIMARY KEY,
KODDET int,
EDIZM varchar,
DTN date NOT NULL CHECK(DTN>(2004-04-01)),
DTK date CHECK(DTK > DTN),
STOIM int CHECK(STOIM > 0));
GO

CREATE TABLE DOG
(NOMDOG int PRIMARY KEY,
NAME_PST varchar,
DTDOG date NOT NULL,
ADR_PST varchar);
GO

CREATE TABLE PSTS
(NAMEPST varchar PRIMARY KEY,
ADRPST varchar,
INN numeric(10, 0),
FIO_RUK varchar(30) DEFAULT null);
GO

ALTER TABLE PSTS ADD Gorod VARCHAR;
ALTER TABLE PSTS ADD Ulica VARCHAR; 
ALTER TABLE PSTS ADD KOD_PSTS int PRIMARY KEY;
ALTER TABLE DOG ADD KOD_PSTS int PRIMARY KEY;






