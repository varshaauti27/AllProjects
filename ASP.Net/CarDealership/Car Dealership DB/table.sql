CREATE TABLE Style(	-- Car / SUV / Truck / Van 
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Description] VARCHAR(30) NOT NULL
)

CREATE TABLE Transmission ( -- Manual / Automatic
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	[Description] VARCHAR(30) NOT NULL
)

CREATE TABLE Color( -- List of possible colors
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Make( -- Honda, Toyota, etc.
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	UserId nvarchar(128) FOREIGN KEY REFERENCES [AspNetUsers](Id)  not null ,
	DateAdded DateTime2 not null default (getdate())
)

CREATE TABLE Model( -- Accord, Camry, etc.
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MakeId INT FOREIGN KEY REFERENCES Make(Id) NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	UserId nvarchar(128) FOREIGN KEY REFERENCES [AspNetUsers](Id)  not null ,
	DateAdded DateTime2 not null default (getdate())
)

CREATE TABLE Vehicle( -- includes all vehicles ever in stock
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Vin VARCHAR(17) UNIQUE NOT NULL,
	ModelId INT FOREIGN KEY REFERENCES Model(Id) NOT NULL,
	[Year] SMALLINT NOT NULL,
	New BINARY NOT NULL default(1),

	StyleId INT FOREIGN KEY REFERENCES Style(Id) NOT NULL,
	TransmissionId INT FOREIGN KEY REFERENCES Transmission(Id) NOT NULL,
	InteriorId INT FOREIGN KEY REFERENCES Color(Id) NOT NULL,
	ExteriorId INT FOREIGN KEY REFERENCES Color(Id) NOT NULL,
	Mileage INT NOT NULL,

	MSRP MONEY NOT NULL,
	SalesPrice MONEY NOT NULL,
	[Description] NVARCHAR(500) NOT NULL, --use empty string if needed
	ImageFile VARCHAR(255) NOT NULL,
	DateAdded DateTime2 not null default (getdate()),
	Feature BINARY NOT NULL default(0),
	UserId nvarchar(128) FOREIGN KEY REFERENCES [AspNetUsers](Id)  not null ,
	InStock BINARY NOT NULL default(1)
)


/* Sales info */

CREATE TABLE Special (
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(70) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL -- use empty string if needed
)


CREATE TABLE [State] (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	Code VARCHAR(2) NOT NULL
)


CREATE TABLE Customer (
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(70) NOT NULL,
	Phone VARCHAR(15) NOT NULL, -- use empty string if needed
	Email VARCHAR(255) NOT NULL, -- use empty string if needed
	Street1 VARCHAR(100) NOT NULL,
	Street2 VARCHAR(100) NULL,
	City VARCHAR(30) NOT NULL,
	StateId INT FOREIGN KEY REFERENCES [State](Id),
	ZipCode VARCHAR(5) NOT NULL
)


CREATE TABLE PurchaseType ( -- Bank finance / Cash / Dealer finance
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	[Description] VARCHAR(30) NOT NULL
)

CREATE TABLE Sales (
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customer(Id) NOT NULL,
	UserId nvarchar(128) FOREIGN KEY REFERENCES [AspNetUsers](Id)  NOT NULL ,

	Vin VARCHAR(17) FOREIGN KEY REFERENCES Vehicle(Vin) NOT NULL,
	[Date] Date NOT NULL,
	PurchasePrice MONEY NOT NULL,
	PurchaseTypeId INT FOREIGN KEY REFERENCES PurchaseType(Id) NOT NULL
)

/* Contact info */

CREATE TABLE Contact (
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(70) NOT NULL,
	Phone VARCHAR(15) NOT NULL, -- use empty string if needed
	Email VARCHAR(255) NOT NULL -- use empty string if needed
)

CREATE TABLE Inquiry (
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contact(Id) NOT NULL,
	[Message] NVARCHAR(2000) NOT NULL, -- use empty string if needed
	Vin VARCHAR(17) FOREIGN KEY REFERENCES Vehicle(Vin) NULL
)

---------------------------------------
-- Droping table

--Drop table Inquiry
--Drop table Contact
--Drop table Sales
--Drop table PurchaseType
--Drop table Customer
--Drop table [State]
--Drop table Special
--Drop table Vehicle
--Drop table Model
--Drop table Make
--Drop table Transmission
--Drop table Color
--Drop table Style