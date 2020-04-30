Use GuildCars
Go

INSERT INTO Style ([Description])
VALUES ('Car'), ('Suv'), ('Truck'), ('Van')

INSERT INTO Transmission ([Description])
VALUES ('Automatic'), ('Manual')

INSERT INTO Color ([Name])
VALUES ('Black'), ('White'), ('Gray'), ('Red'), ('Silver'), ('Blue')

INSERT INTO Make ([Name],UserId)
VALUES	('Honda','195111be-3f63-449d-bd6c-0323c7ec67a8'), 
		('Toyota','c65b9ccd-7bec-48e8-aade-8811d4769fa7'), 
		('Mazda','195111be-3f63-449d-bd6c-0323c7ec67a8'), 
		('Lexus','c65b9ccd-7bec-48e8-aade-8811d4769fa7')

INSERT INTO Model (MakeId, [Name],UserId)
VALUES
	(4, 'Civic','195111be-3f63-449d-bd6c-0323c7ec67a8'), (4, 'Accord','195111be-3f63-449d-bd6c-0323c7ec67a8'),
	(1, 'Corolla','c65b9ccd-7bec-48e8-aade-8811d4769fa7'), (4, 'Camry','c65b9ccd-7bec-48e8-aade-8811d4769fa7'),
	(2, 'MX-5 Miata','c65b9ccd-7bec-48e8-aade-8811d4769fa7'), (2, 'CX-3','c65b9ccd-7bec-48e8-aade-8811d4769fa7'),
	(3, 'RX','c65b9ccd-7bec-48e8-aade-8811d4769fa7'), (3, 'IS','c65b9ccd-7bec-48e8-aade-8811d4769fa7') 


INSERT INTO Vehicle
	(Vin, ModelId, [Year], New, 
	StyleId, TransmissionId, InteriorId, ExteriorId,
	Mileage, MSRP,SalesPrice, [Description], ImageFile,UserId)
VALUES
	('1234567890ABCDEFG', 2, '2017', 1, 1, 1, 2, 3, 50, 22000, 21000 ,'New Honda Acc', 'icon.img','c65b9ccd-7bec-48e8-aade-8811d4769fa7'),
	('2345678901BCDEFGH', 3, '2007', 0, 1, 1, 2, 3, 100000, 18000,17000, 'Old Toyota Corolla', 'icon.img','195111be-3f63-449d-bd6c-0323c7ec67a8'),
	('3456789012CDEFGHI', 5, '2015', 0, 1, 1, 2, 3, 30000, 28000,27000, 'Used Mazda Miata', 'icon.img','195111be-3f63-449d-bd6c-0323c7ec67a8'),
	('4567890123DEFGHIJ', 8, '2012', 0, 1, 1, 2, 3, 55000, 34000,33000, 'Used Lexus IS', 'icon.img','c65b9ccd-7bec-48e8-aade-8811d4769fa7')

INSERT INTO Special ([Name], [Description])
VALUES
	('Free sticker', 'Get a free bumper sticker with the purchase of a new car.'),
	('Walk-in special', '$300 off if you mention this special!')

INSERT INTO [State] ([Name],Code)
VALUES ('Minnesota','MN'),('Texas','TX'),('Chicago','IL')

INSERT INTO Customer
	([Name], Phone, Email,
	Street1, Street2, City, StateId, ZipCode)
VALUES ('Tanvi Desai', '6123914560', 'varshaauti27@gmail.com', '18163 Glassfern Ln', '', 'Lakeville', 1, '55044')

INSERT INTO PurchaseType ([Description])
VALUES ('Bank finance'), ('Cash'), ('Dealer finance')

INSERT INTO Sales (CustomerId, UserId, Vin, [Date], PurchasePrice, PurchaseTypeId)
VALUES (1, '195111be-3f63-449d-bd6c-0323c7ec67a8', '3456789012CDEFGHI', '1/23/2017', 18500, 1)

INSERT INTO Contact ([Name], Phone, Email)
VALUES ('Varsha Auti', '', 'varshaauti27@gmail.com')

INSERT INTO Inquiry (ContactId, [Message], Vin)
VALUES (1, 'How are you?', NULL)