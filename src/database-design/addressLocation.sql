CREATE DATABASE TestDb;

Use TestDb;

CREATE TABLE Countries (
  Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  CountryName varchar(200) NOT NULL,
  CountryCode char(3) 
  );

 CREATE TABLE States (
   Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
   StateName varchar(75) NOT NULL,
   CountryId int NOT NULL,
   FOREIGN KEY (CountryId) REFERENCES Countries(Id) 
   );

 CREATE TABLE Cities (
  Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  CityName varchar(200) NOT NULL,
  StateId int NOT NULL,
  FOREIGN KEY (StateId) REFERENCES States(Id) 
  );

  CREATE TABLE Districts (
  Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  DistrictName varchar(200) DEFAULT NULL,
  CityId int NOT NULL,
  FOREIGN KEY (CityId) REFERENCES Cities(Id)
  );

  CREATE TABLE Addresses (
   Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
   Street varchar(100) NOT NULL,
   Street1 varchar(100) DEFAULT NULL,
   Building varchar(100) DEFAULT NULL,
   LevelNumber varchar(25) DEFAULT NULL, 
   Room varchar(25) DEFAULT NULL,
   PostalCode varchar(25)  DEFAULT NULL, 
   DistrictId int NOT NULL,
   FOREIGN KEY (DistrictId) REFERENCES Districts(Id)
);

