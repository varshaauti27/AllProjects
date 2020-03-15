use [master]
Go

if exists (select * from sys.databases where name=N'HotelSoftwareGuild')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'HotelSoftwareGuild';
	ALTER DATABASE HotelSoftwareGuild SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE HotelSoftwareGuild;
end

-- Here's our original CREATE.
CREATE DATABASE HotelSoftwareGuild;
GO

USE HotelSoftwareGuild
Go

--Create Table queries...
CREATE TABLE RoomType(
		RoomType varchar(50) PRIMARY KEY,
		StandardOccupancy INT NOT NULL DEFAULT 0,
		MaxOccupancy INT NOT NULL DEFAULT 0
		);

CREATE TABLE Ammenities(
		[Name] varchar(100) PRIMARY KEY
		);


CREATE TABLE Room(
		RoomNo int PRIMARY KEY,
		RoomType varchar(50),
		ADAAccessible bit,
		BasePrice decimal(18,2),
		ExtraPerson decimal(18,2) NULL
		CONSTRAINT FK_RoomType_RoomType FOREIGN KEY(RoomType)
			REFERENCES RoomType(RoomType),
		);

CREATE TABLE RoomAmmenities(
		RoomNo INT NOT NULL,
		AmmenityName varchar(100) NOT NULL,
		PRIMARY KEY(RoomNo,AmmenityName),
		CONSTRAINT FK_RoomAmmenities_RoomNo FOREIGN KEY(RoomNo)
			REFERENCES Room(RoomNo),
		CONSTRAINT FK_RoomAmmenities_ReservationID FOREIGN KEY(AmmenityName)
			REFERENCES Ammenities([Name]),
		);

CREATE TABLE Guest(
		GuestID INT PRIMARY KEY IDENTITY(1,1),
		FirstName varchar(50),
		LastName varchar(50),
		[Address] varchar(256) null,
		City varchar(100) null,
		[State] varchar(30),
		Zip varchar(20),
		Phone varchar(22) null,
		);

CREATE TABLE Reservation(
		ReservationID INT PRIMARY KEY IDENTITY(1,1),
		GuestID INT NOT NULL,
		Adults INT NOT NULL DEFAULT 0,
		Children INT NOT NULL DEFAULT 0,
		StartDate DATE NOT NULL DEFAULT CURRENT_TIMESTAMP,
		EndDate DATE NOT NULL DEFAULT CURRENT_TIMESTAMP,
		CONSTRAINT FK_ReservationGuest_GuestID FOREIGN KEY(GuestID)
			REFERENCES Guest(GuestID),
		);

CREATE TABLE RoomReservation(
		RoomNo INT NOT NULL,
		ReservationID INT NOT NULL,
		PRIMARY KEY(RoomNo,ReservationID),
		CONSTRAINT FK_RoomReservation_RoomNo FOREIGN KEY(RoomNo)
			REFERENCES Room(RoomNo),
		CONSTRAINT FK_RoomReservation_ReservationID FOREIGN KEY(ReservationID)
			REFERENCES Reservation(ReservationID),
		);
