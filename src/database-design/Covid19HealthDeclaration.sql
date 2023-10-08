CREATE TABLE Roles (
  Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  RoleName varchar(15) NOT NULL,
  RoleDescription varchar(30) DEFAULT NULL
  );

  CREATE TABLE Users (
  Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  FirstName varchar(25) NOT NULL,
  LastName varchar(25) DEFAULT NULL,
  RoleId int NOT NULL,
  FOREIGN KEY (RoleId) REFERENCES Roles(Id) 
  );

  CREATE TABLE Visitors (
  Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  FirstName varchar(25) NOT NULL,
  LastName varchar(25) DEFAULT NULL,
  Phone varchar(25) DEFAULT NULL,
  );

  CREATE TABLE Templates (
  Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  TemplateTitle varchar(40) NOT NULL,
  TemplateContent nvarchar(max) NOT NULL,
  UserId int NOT NULL
  FOREIGN KEY (UserId) REFERENCES Users(Id) 
  );

  CREATE TABLE VisitorTemplates (
  Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  VisitorTemplateTitle varchar(40) NOT NULL,
  VisitorTemplateContent nvarchar(max) NOT NULL,
  VisitorId int NOT NULL,
  TemplateId int NOT NULL,
  FOREIGN KEY (VisitorId) REFERENCES Visitors(Id),
  FOREIGN KEY (TemplateId) REFERENCES Templates(Id), 
  );