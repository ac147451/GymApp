CREATE SCHEMA Location;
go

CREATE SCHEMA Session;
go

CREATE SCHEMA Member;
go

CREATE SCHEMA Gym; 
go

CREATE SCHEMA Role;
go

CREATE TABLE Role.roles (
	roleID INT IDENTITY (1, +1) PRIMARY KEY,
	rolename VARCHAR (255)
);
go


CREATE TABLE Member.members (
	memberID INT IDENTITY (1, +1) PRIMARY KEY,
	firstname VARCHAR (255),
	lastname VARCHAR (255),
	phonenumber VARCHAR(15),
	emailaddress VARCHAR (255),
	username VARCHAR (255),
	password VARCHAR (8),
	roleID int,
	FOREIGN KEY (roleID) REFERENCES Role.roles(roleID),
);
go


CREATE TABLE Location.country ( 
	countryID INT IDENTITY (1, +1) PRIMARY KEY,
	countryname VARCHAR (255),
);
go

CREATE TABLE Location.city ( 
	cityID INT IDENTITY (1, +1) PRIMARY KEY,
	cityname VARCHAR (255),
);

CREATE TABLE Location.suburb ( 
	suburbID INT IDENTITY (1, +1) PRIMARY KEY,
	suburbname VARCHAR (255),
);
go



CREATE TABLE Session.classtype ( 
	classtypeID INT IDENTITY (1, +1) PRIMARY KEY,
	classtype VARCHAR (255),
	classprice INT,
);
go

CREATE TABLE Gym.gyms (
	gymID INT IDENTITY (1, +1) PRIMARY KEY,
	gymname VARCHAR (255),
	streetaddress VARCHAR (255),
	countryID int, 
	cityID int, 
	suburbID int,
	phonenumber VARCHAR(15),
	emailaddress VARCHAR (255),
	password VARCHAR (8),
	roleID int,
	FOREIGN KEY (countryID) REFERENCES Location.country(countryID),
	FOREIGN KEY (cityID) REFERENCES Location.city(cityID),
	FOREIGN KEY (suburbID) REFERENCES Location.suburb(suburbID),
	FOREIGN KEY (roleID) REFERENCES Role.roles(roleID),

);
go

CREATE TABLE Session.instructor ( 
	instructorID INT IDENTITY (1, +1) PRIMARY KEY,
	instructorname VARCHAR (255),
	gymID int,
	phonenumber VARCHAR(15),
	emailaddress VARCHAR (255),
	username VARCHAR (255),
	password VARCHAR (8),
	roleID int,
	FOREIGN KEY (gymID) REFERENCES Gym.gyms(gymID),
	FOREIGN KEY (roleID) REFERENCES Role.roles(roleID),
);
go
	
CREATE TABLE Session.sessionbooking (
	sessionID INT IDENTITY (1, +1) PRIMARY KEY,
	instructorID int ,
	classtypeID int ,
	memberID int , 
	gymID int ,
	sessiondate DATETIME,
	FOREIGN KEY (instructorID) REFERENCES Session.instructor(instructorID),
	FOREIGN KEY (classtypeID) REFERENCES Session.classtype(classtypeID),
	FOREIGN KEY (memberID) REFERENCES Member.members(memberID),
	FOREIGN KEY (gymID) REFERENCES Gym.gyms(gymID),
);
go