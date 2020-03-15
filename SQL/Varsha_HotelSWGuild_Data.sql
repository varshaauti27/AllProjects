USE [HotelSoftwareGuild]
GO

----Insert Into Tables....
--RoomType varchar(50) PRIMARY KEY,
--StandardOccupancy INT NOT NULL DEFAULT 0,
--MaxOccupancy INT NOT NULL DEFAULT 0,
INSERT INTO RoomType VALUES ('Double',2,4);
INSERT INTO RoomType VALUES ('Single',2,2);
INSERT INTO RoomType VALUES ('Suite',3,8);

--[Name] varchar(100) PRIMARY KEY
INSERT INTO Ammenities VALUES ('Microwave');
INSERT INTO Ammenities VALUES ('Refrigerator');
INSERT INTO Ammenities VALUES ('Oven');
INSERT INTO Ammenities VALUES ('Jacuzzi');

--
--RoomNo int PRIMARY KEY,
--RoomType varchar(50),
--ADAAccessible bit,
--BasePrice decimal(18,2),
--ExtraPerson decimal(18,2) NULL
INSERT INTO Room VALUES (201,'Double',0,199.99,10);
INSERT INTO Room VALUES (202,'Double',1,174.99,10);
INSERT INTO Room VALUES (203,'Double',0,199.99,10);
INSERT INTO Room VALUES (204,'Double',1,174.99,10);
INSERT INTO Room VALUES (205,'Single',0,174.99,NULL);
INSERT INTO Room VALUES (206,'Single',1,149.99,NULL);
INSERT INTO Room VALUES (207,'Single',0,174.99,NULL);
INSERT INTO Room VALUES (208,'Single',1,149.99,NULL);

INSERT INTO Room VALUES (301,'Double',0,199.99,10);
INSERT INTO Room VALUES (302,'Double',1,174.99,10);
INSERT INTO Room VALUES (303,'Double',0,199.99,10);
INSERT INTO Room VALUES (304,'Double',1,174.99,10);
INSERT INTO Room VALUES (305,'Single',0,174.99,NULL);
INSERT INTO Room VALUES (306,'Single',1,149.99,NULL);
INSERT INTO Room VALUES (307,'Single',0,174.99,NULL);
INSERT INTO Room VALUES (308,'Single',1,149.99,NULL);

INSERT INTO Room VALUES (401,'Suite',1,399.99,20);
INSERT INTO Room VALUES (402,'Suite',1,399.99,20);

--
--RoomNo INT NOT NULL,
--AmmenityName varchar(100) NOT NULL,
--('Microwave','Refrigerator','Oven','Jacuzzi');

INSERT INTO RoomAmmenities VALUES (201,'Microwave');
INSERT INTO RoomAmmenities VALUES (201,'Jacuzzi');

INSERT INTO RoomAmmenities VALUES (202,'Refrigerator');

INSERT INTO RoomAmmenities VALUES (203,'Microwave');
INSERT INTO RoomAmmenities VALUES (203,'Jacuzzi');

INSERT INTO RoomAmmenities VALUES (204,'Refrigerator');

INSERT INTO RoomAmmenities VALUES (205,'Microwave');
INSERT INTO RoomAmmenities VALUES (205,'Refrigerator');
INSERT INTO RoomAmmenities VALUES (205,'Jacuzzi');

INSERT INTO RoomAmmenities VALUES (206,'Microwave');
INSERT INTO RoomAmmenities VALUES (206,'Refrigerator');

INSERT INTO RoomAmmenities VALUES (207,'Microwave');
INSERT INTO RoomAmmenities VALUES (207,'Refrigerator');
INSERT INTO RoomAmmenities VALUES (207,'Jacuzzi');

INSERT INTO RoomAmmenities VALUES (208,'Microwave');
INSERT INTO RoomAmmenities VALUES (208,'Refrigerator');

INSERT INTO RoomAmmenities VALUES (301,'Microwave');
INSERT INTO RoomAmmenities VALUES (301,'Jacuzzi');

INSERT INTO RoomAmmenities VALUES (302,'Refrigerator');

INSERT INTO RoomAmmenities VALUES (303,'Microwave');
INSERT INTO RoomAmmenities VALUES (303,'Jacuzzi');

INSERT INTO RoomAmmenities VALUES (304,'Refrigerator');

INSERT INTO RoomAmmenities VALUES (305,'Microwave');
INSERT INTO RoomAmmenities VALUES (305,'Refrigerator');
INSERT INTO RoomAmmenities VALUES (305,'Jacuzzi');

INSERT INTO RoomAmmenities VALUES (306,'Microwave');
INSERT INTO RoomAmmenities VALUES (306,'Refrigerator');

INSERT INTO RoomAmmenities VALUES (307,'Microwave');
INSERT INTO RoomAmmenities VALUES (307,'Refrigerator');
INSERT INTO RoomAmmenities VALUES (307,'Jacuzzi');

INSERT INTO RoomAmmenities VALUES (308,'Microwave');
INSERT INTO RoomAmmenities VALUES (308,'Refrigerator');

INSERT INTO RoomAmmenities VALUES (401,'Microwave');
INSERT INTO RoomAmmenities VALUES (401,'Refrigerator');
INSERT INTO RoomAmmenities VALUES (401,'Oven');

INSERT INTO RoomAmmenities VALUES (402,'Microwave');
INSERT INTO RoomAmmenities VALUES (402,'Refrigerator');
INSERT INTO RoomAmmenities VALUES (402,'Oven');

--
--GuestID INT PRIMARY KEY IDENTITY(1,1),
--[Name] varchar(50),
--[Address] varchar(256) null,
--City varchar(100) null,
--[State] varchar(30),
--Zip varchar(20),
--Phone varchar(22) null,
INSERT INTO Guest VALUES('Mack','Simmer','379 Old Shore Street','Council Bluffs','IA','51501','(291)553-0508');
INSERT INTO Guest VALUES('Bettyann','Seery','750 Wintergreen Dr.','Wasilla','AK','99654','(478)277-9632');
INSERT INTO Guest VALUES('Duane','Cullison','9662 Foxrun Lane','Harlingen','TX','78552','(308)494-0198');
INSERT INTO Guest VALUES('Karie','Yang','9378 W. Augusta Ave.','West Deptford','NJ','08096','(214)730-0298');
INSERT INTO Guest VALUES('Aurore','Lipton','762 Wild Rose Street','Saginaw','MI','48601','(377)507-0974');
INSERT INTO Guest VALUES('Zachery','Luechtefeld','7 Poplar Dr.','Arvada','CO','80003','(814)485-2615');
INSERT INTO Guest VALUES('Jeremiah','Pendergrass','70 Oakwood St.','Zion','IL','60099','(279)491-0960');
INSERT INTO Guest VALUES('Walter','Holaway','7556 Arrowhead St.','Cumberland','RI','02864','(446)396-6785');
INSERT INTO Guest VALUES('Wilfred','Vise','77 West Surrey Street','Oswego','NY','13126','(834)727-1001');
INSERT INTO Guest VALUES('Maritza','Tilton','939 Linda Rd.','Burke','VA','22015','(446)351-6860');
INSERT INTO Guest VALUES('Joleen','Tison','87 Queen St.','Drexel Hill','PA','19026','(231)893-2755');
INSERT INTO Guest VALUES('Varsha','Auti','18163 Glassfern Ln','Lakeville','MN','55044','(612)391-4560');


--ReservationID INT PRIMARY KEY IDENTITY(1,1),
--GuestID INT NOT NULL,
--Adults INT NOT NULL DEFAULT 0,
--Children INT NOT NULL DEFAULT 0
--StartDate DATE NOT NULL DEFAULT CURRENT_TIMESTAMP,
--EndDate DATE NOT NULL DEFAULT CURRENT_TIMESTAMP,
INSERT INTO Reservation VALUES(1,1,0,'2/2/2023','2/4/2023');
INSERT INTO Reservation VALUES(2,2,1,'2/5/2023','2/10/2023');
INSERT INTO Reservation VALUES(3,2,0,'2/22/2023','2/24/2023');
INSERT INTO Reservation VALUES(4,2,2,'3/6/2023','3/7/2023');
INSERT INTO Reservation VALUES(12,1,1,'3/17/2023','3/20/2023');
INSERT INTO Reservation VALUES(5,3,0,'3/18/2023','3/23/2023');
INSERT INTO Reservation VALUES(6,2,2,'3/29/2023','3/31/2023');
INSERT INTO Reservation VALUES(7,2,0,'3/31/2023','4/5/2023');
INSERT INTO Reservation VALUES(8,1,0,'4/9/2023','4/13/2023');
INSERT INTO Reservation VALUES(9,1,1,'4/23/2023','4/24/2023');
INSERT INTO Reservation VALUES(10,2,4,'5/30/2023','6/2/2023');
INSERT INTO Reservation VALUES(11,2,0,'6/10/2023','6/14/2023');
INSERT INTO Reservation VALUES(11,1,0,'6/10/2023','6/14/2023');
INSERT INTO Reservation VALUES(5,3,0,'6/17/2023','6/18/2023');
INSERT INTO Reservation VALUES(12,2,0,'6/28/2023','7/2/2023');
INSERT INTO Reservation VALUES(8,3,1,'7/13/2023','7/14/2023');
INSERT INTO Reservation VALUES(9,4,2,'7/18/2023','7/21/2023');
INSERT INTO Reservation VALUES(2,2,1,'7/28/2023','7/29/2023');
INSERT INTO Reservation VALUES(2,1,0,'8/30/2023','9/1/2023');
INSERT INTO Reservation VALUES(1,2,0,'9/16/2023','9/17/2023');
INSERT INTO Reservation VALUES(4,2,2,'9/13/2023','9/15/2023');
INSERT INTO Reservation VALUES(3,2,2,'11/22/2023','11/25/2023');
INSERT INTO Reservation VALUES(1,2,0,'11/22/2023','11/25/2023');
INSERT INTO Reservation VALUES(1,2,2,'11/22/2023','11/25/2023');
INSERT INTO Reservation VALUES(10,2,0,'12/24/2023','12/28/2023');

--RoomNo INT NOT NULL,
--ReservationID INT NOT NULL,
INSERT INTO RoomReservation VALUES(308,1);
INSERT INTO RoomReservation VALUES(203,2);
INSERT INTO RoomReservation VALUES(305,3);
INSERT INTO RoomReservation VALUES(201,4);
INSERT INTO RoomReservation VALUES(307,5);
INSERT INTO RoomReservation VALUES(302,6);
INSERT INTO RoomReservation VALUES(202,7);
INSERT INTO RoomReservation VALUES(304,8);
INSERT INTO RoomReservation VALUES(301,9);
INSERT INTO RoomReservation VALUES(207,10);
INSERT INTO RoomReservation VALUES(401,11);
INSERT INTO RoomReservation VALUES(206,12);
INSERT INTO RoomReservation VALUES(208,13);
INSERT INTO RoomReservation VALUES(304,14);
INSERT INTO RoomReservation VALUES(205,15);
INSERT INTO RoomReservation VALUES(204,16);
INSERT INTO RoomReservation VALUES(401,17);
INSERT INTO RoomReservation VALUES(303,18);
INSERT INTO RoomReservation VALUES(305,19);
INSERT INTO RoomReservation VALUES(208,20);
INSERT INTO RoomReservation VALUES(203,21);
INSERT INTO RoomReservation VALUES(401,22);
INSERT INTO RoomReservation VALUES(206,23);
INSERT INTO RoomReservation VALUES(301,24);
INSERT INTO RoomReservation VALUES(302,25);

--Deleting data should start with records that reference Jeremiah Pendergrass
DELETE FROM RoomReservation WHERE RoomReservation.ReservationID  = (SELECT ReservationID FROM Reservation WHERE GuestID =
			(SELECT GuestID FROM Guest WHERE Guest.FirstName like 'Jeremiah' AND Guest.LastName like 'Pendergrass'));

DELETE FROM Reservation WHERE Reservation.ReservationID  = (SELECT ReservationID FROM Reservation WHERE GuestID =
			(SELECT GuestID FROM Guest WHERE Guest.FirstName like 'Jeremiah' AND Guest.LastName like 'Pendergrass'));

DELETE FROM Guest WHERE Guest.FirstName like 'Jeremiah' AND Guest.LastName like 'Pendergrass';