USE GuildCars
GO

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetAllColors'
)
BEGIN
    DROP PROCEDURE sp_GetAllColors
END
GO
 
CREATE PROCEDURE sp_GetAllColors
AS
	SELECT * FROM Color;
GO

EXEC sp_GetAllColors;

---------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetColorById'
)
BEGIN
    DROP PROCEDURE sp_GetColorById
END
GO

CREATE PROCEDURE sp_GetColorById @ColorId INT
AS
	SELECT * FROM Color 
	WHERE Id = @ColorId
GO

EXEC sp_GetColorById 1
---------------------------------------------------------------------


IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_InsertContactInformation'
)
BEGIN
    DROP PROCEDURE sp_InsertContactInformation
END
GO

create proc sp_InsertContactInformation @Name Nvarchar(70), @Email VARCHAR(255),
					@Phone VARCHAR(15),@Vin VARCHAR(17), @Message NVARCHAR(2000)
as  
begin  
        insert into Contact values(@Name, @Phone,@Email)  
        declare @Contact_ID int = @@identity  
        insert into Inquiry values(@Contact_ID,@Message,@Vin)  
end  

Exec sp_InsertContactInformation 'Tanvi' ,'Tanu@gmail.com','1233444','1234567890ABCDEFG','New Message'

---------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_AddCustomer'
)
BEGIN
    DROP PROCEDURE sp_AddCustomer
END
GO

CREATE PROCEDURE sp_AddCustomer @Name NVARCHAR(70),@Phone VARCHAR(15),@Email VARCHAR(255),
		@Street1 VARCHAR(100),@Street2 VARCHAR(100),@City VARCHAR(30),@StateId INT,@ZipCode VARCHAR(5)
AS
DECLARE @cust_id int
BEGIN
   INSERT INTO Customer([Name],Phone,Email,Street1,Street2,City,StateId,ZipCode)
   VALUES (@Name,@Phone,@Email,@Street1,@Street2,@City,@StateId,@ZipCode)

   SET @cust_id = SCOPE_IDENTITY()
END return @cust_id
GO

---------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetAllMakes'
)
BEGIN
    DROP PROCEDURE sp_GetAllMakes
END
GO
 
CREATE PROCEDURE sp_GetAllMakes
AS
	SELECT Make.Id,[Name],DateAdded,UserId,UserName FROM Make 
	Join AspNetUsers on AspNetUsers.Id = Make.UserId
GO

---------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetMakeById'
)
BEGIN
    DROP PROCEDURE sp_GetMakeById
END
GO

CREATE PROCEDURE sp_GetMakeById @MakeId INT
AS
	SELECT Make.Id,[Name],DateAdded,UserId,UserName FROM Make 
	Join AspNetUsers on AspNetUsers.Id = Make.UserId
	WHERE Make.Id = @MakeId;
GO

EXEC sp_GetMakeById 1
---------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_AddMake'
)
BEGIN
    DROP PROCEDURE sp_AddMake
END
GO

CREATE PROCEDURE sp_AddMake @Name VARCHAR(30),@UserId nvarchar(128),@DateAdded DateTime2 
AS
BEGIN
   INSERT INTO Make([Name],UserId,DateAdded)
   VALUES (@Name,@UserId,@DateAdded)
END 
GO

---------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetAllModels'
)
BEGIN
    DROP PROCEDURE sp_GetAllModels
END
GO
 
CREATE PROCEDURE sp_GetAllModels
AS
	SELECT Model.Id,MakeId,Model.[Name] AS ModelName,Make.[Name] AS MakeName,Model.UserId,UserName, Model.DateAdded FROM Model 
	Join Make on Make.Id = Model.MakeId
	Join AspNetUsers on AspNetUsers.Id = Model.UserId
GO

EXEC sp_GetAllModels
---------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetModelById'
)
BEGIN
    DROP PROCEDURE sp_GetModelById
END
GO

CREATE PROCEDURE sp_GetModelById @ModelId INT
AS
	SELECT Model.Id,MakeId,Model.[Name] AS ModelName,Make.[Name] AS MakeName,Model.UserId,UserName, Model.DateAdded FROM Model 
	Join Make on Make.Id = Model.MakeId
	Join AspNetUsers on AspNetUsers.Id = Model.UserId
	WHERE Model.Id = @ModelId;
GO

select * from Model
---------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetModelByMakeId'
)
BEGIN
    DROP PROCEDURE sp_GetModelByMakeId
END
GO

CREATE PROCEDURE sp_GetModelByMakeId @MakeId INT
AS
	SELECT Model.Id,MakeId,Model.[Name] AS ModelName,Make.[Name] AS MakeName,Model.UserId,UserName, Model.DateAdded FROM Model 
	Join Make on Make.Id = Model.MakeId
	Join AspNetUsers on AspNetUsers.Id = Model.UserId
	WHERE Model.MakeId = @MakeId;
GO

Exec sp_GetModelByMakeId 2
---------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_AddModel'
)
BEGIN
    DROP PROCEDURE sp_AddModel
END
GO

CREATE PROCEDURE sp_AddModel @MakeId INT,@Name NVARCHAR(30),@UserId nvarchar(128),@DateAdded DateTime2
AS
BEGIN
   INSERT INTO Model(MakeId,[Name],UserId,DateAdded)
   VALUES (@MakeId,@Name,@UserId,@DateAdded)
END 
GO

---------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetAllPurchaseTypes'
)
BEGIN
    DROP PROCEDURE sp_GetAllPurchaseTypes
END
GO

CREATE PROCEDURE sp_GetAllPurchaseTypes 
AS
BEGIN
   SELECT * FROM PurchaseType
END 
GO

Exec sp_GetAllPurchaseTypes
-----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetPurchaseById'
)
BEGIN
    DROP PROCEDURE sp_GetPurchaseById
END
GO

CREATE PROCEDURE sp_GetPurchaseById @PurchaseId INT
AS
	SELECT * FROM PurchaseType
	WHERE Id = @PurchaseId;
GO

------------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_AddSalesInformation'
)
BEGIN
    DROP PROCEDURE sp_AddSalesInformation
END
GO

CREATE PROCEDURE sp_AddSalesInformation @CustId INT, @UserId nvarchar(128),
				@Vin VARCHAR(17),@Date Date,@PurchasePrice MONEY,@PurchaseTypeId INT 
AS
BEGIN
   INSERT INTO Sales(CustomerId,UserId,Vin,[Date],PurchasePrice,PurchaseTypeId)
   VALUES (@CustId,@UserId,@Vin,@Date,@PurchasePrice,@PurchaseTypeId)
END 
GO

------------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetAllSales'
)
BEGIN
    DROP PROCEDURE sp_GetAllSales
END
GO

CREATE PROCEDURE sp_GetAllSales
AS
BEGIN
	Select Sales.*,PurchaseType.[Description] from Sales 
	Join PurchaseType On PurchaseType.Id = Sales.PurchaseTypeId
END 
GO

EXEC sp_GetAllSales
----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetAllSpecials'
)
BEGIN
    DROP PROCEDURE sp_GetAllSpecials
END
GO

CREATE PROCEDURE sp_GetAllSpecials
AS
BEGIN
	Select * from Special
END 
GO

EXEC sp_GetAllSpecials
----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_AddSpecial'
)
BEGIN
    DROP PROCEDURE sp_AddSpecial
END
GO

CREATE PROCEDURE sp_AddSpecial @Name NVARCHAR(70),@Description NVARCHAR(500)
AS
BEGIN
   INSERT INTO Special([Name],[Description])
   VALUES (@Name,@Description)
END 
GO

----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_DeleteSpecial'
)
BEGIN
    DROP PROCEDURE sp_DeleteSpecial
END
GO

CREATE PROCEDURE sp_DeleteSpecial @SpecialId int
AS
	DELETE FROM Special WHERE Special.Id = @SpecialId
GO

----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetAllStates'
)
BEGIN
    DROP PROCEDURE sp_GetAllStates
END
GO

CREATE PROCEDURE sp_GetAllStates
AS
BEGIN
	SELECT * FROM [State]
END 
GO

EXEC sp_GetAllStates
----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetStateById'
)
BEGIN
    DROP PROCEDURE sp_GetStateById
END
GO

CREATE PROCEDURE sp_GetStateById @StateId INT
AS
	SELECT * FROM [State]
	WHERE Id = @StateId;
GO

----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetAllStyles'
)
BEGIN
    DROP PROCEDURE sp_GetAllStyles
END
GO

CREATE PROCEDURE sp_GetAllStyles
AS
BEGIN
	SELECT * FROM [Style]
END 
GO

EXEC sp_GetAllStyles;
----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetStyleById'
)
BEGIN
    DROP PROCEDURE sp_GetStyleById
END
GO

CREATE PROCEDURE sp_GetStyleById @StyleId INT
AS
	SELECT * FROM [Style]
	WHERE Id = @StyleId;
GO


----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetAllTransmission'
)
BEGIN
    DROP PROCEDURE sp_GetAllTransmission
END
GO

CREATE PROCEDURE sp_GetAllTransmission
AS
BEGIN
	SELECT * FROM Transmission
END 
GO

EXEC sp_GetAllTransmission
----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetTransmissionById'
)
BEGIN
    DROP PROCEDURE sp_GetTransmissionById
END
GO

CREATE PROCEDURE sp_GetTransmissionById @TransmissionId INT
AS
	SELECT * FROM Transmission
	WHERE Id = @TransmissionId;
GO

----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetAllVehicle'
)
BEGIN
    DROP PROCEDURE sp_GetAllVehicle
END
GO

CREATE PROCEDURE sp_GetAllVehicle
AS
BEGIN
	SELECT Vin,New,[Year],Mileage,SalesPrice,MSRP,Vehicle.[Description] As VehicleDescription,ImageFile,Feature,Vehicle.UserId,
	Vehicle.InStock,Model.[Name] As ModelName,Make.[Name] As MakeName,[Style].[Description] AS StyleDescription,Transmission.[Description] As TransDescription,Color.[Name] as 'Interior Color',c.[Name] as 'Exterior Color' FROM Vehicle
	JOIN Model ON Model.Id = Vehicle.ModelId
	JOIN Make ON Make.Id = Model.MakeId
	JOIN [Style] ON Style.Id = Vehicle.StyleId
	JOIN Transmission ON Transmission.Id = Vehicle.TransmissionId
	JOIN Color ON Color.Id = Vehicle.InteriorId
	JOIN Color as c ON c.Id = Vehicle.ExteriorId
	Where Vehicle.InStock = 1
END 
GO

EXEC sp_GetAllVehicle
----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetFeatureVehicles'
)
BEGIN
    DROP PROCEDURE sp_GetFeatureVehicles
END
GO

CREATE PROCEDURE sp_GetFeatureVehicles
AS
BEGIN
	SELECT Vin,New,[Year],Mileage,SalesPrice,MSRP,Vehicle.[Description] As VehicleDescription,ImageFile,Feature,Vehicle.UserId,
	Vehicle.InStock,Model.[Name] As ModelName,Make.[Name] As MakeName,[Style].[Description] AS StyleDescription,Transmission.[Description] As TransDescription,Color.[Name] as 'Interior Color',c.[Name] as 'Exterior Color' FROM Vehicle
	JOIN Model ON Model.Id = Vehicle.ModelId
	JOIN Make ON Make.Id = Model.MakeId
	JOIN [Style] ON Style.Id = Vehicle.StyleId
	JOIN Transmission ON Transmission.Id = Vehicle.TransmissionId
	JOIN Color ON Color.Id = Vehicle.InteriorId
	JOIN Color as c ON c.Id = Vehicle.ExteriorId
	WHERE Vehicle.Feature = 1 And Vehicle.InStock=1
END 
GO

EXEC sp_GetFeatureVehicles
----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_GetVehicleByVin'
)
BEGIN
    DROP PROCEDURE sp_GetVehicleByVin
END
GO

CREATE PROCEDURE sp_GetVehicleByVin @Vin VARCHAR(17) 
AS
BEGIN
	SELECT Vin,New,[Year],Mileage,SalesPrice,MSRP,Vehicle.[Description] As VehicleDescription,ImageFile,Feature,Vehicle.UserId,
	Vehicle.InStock,Model.[Name] As ModelName,Make.[Name] As MakeName,[Style].[Description] AS StyleDescription,Transmission.[Description] As TransDescription,Color.[Name] as 'Interior Color',c.[Name] as 'Exterior Color' FROM Vehicle
	JOIN Model ON Model.Id = Vehicle.ModelId
	JOIN Make ON Make.Id = Model.MakeId
	JOIN [Style] ON Style.Id = Vehicle.StyleId
	JOIN Transmission ON Transmission.Id = Vehicle.TransmissionId
	JOIN Color ON Color.Id = Vehicle.InteriorId
	JOIN Color as c ON c.Id = Vehicle.ExteriorId
	WHERE Vehicle.Vin = @Vin
END 
GO

Exec sp_GetVehicleByVin '2345678901BCDEFGH'

----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_AddVehicle'
)
BEGIN
    DROP PROCEDURE sp_AddVehicle
END
GO

CREATE PROCEDURE sp_AddVehicle @Vin VARCHAR(17),@ModelName NVARCHAR(30) ,@MakeName VARCHAR(30),@Year SMALLINT,@New BINARY,@Feature BINARY, @StyleName VARCHAR(30),
				@TransName VARCHAR(30),@InteriorName VARCHAR(30),@ExteriorName VARCHAR(30),@Mileage INT,@MSRP MONEY,@SalesPrice MONEY,
				@Description NVARCHAR(500),@ImageFile VARCHAR(255),@DateAdded DateTime2,@UserId nvarchar(128)
AS

BEGIN
   DECLARE @ModelId int = (SELECT Model.Id FROM Model JOIN Make ON Make.Id = Model.MakeId
							WHERE Model.[Name] = @ModelName and Make.[Name] = @MakeName)
   DECLARE @StyleId int = (SELECT Style.Id FROM [Style] WHERE Style.[Description] = @StyleName)
   DECLARE @TransmissionId int = (SELECT Transmission.Id FROM Transmission WHERE Transmission.[Description] = @TransName)
   DECLARE @InteriorId int = (SELECT Color.Id FROM Color WHERE Color.[Name] = @InteriorName)
   DECLARE @ExteriorId int = (SELECT Color.Id FROM Color WHERE Color.[Name] = @ExteriorName)
  
   INSERT INTO Vehicle(Vin,ModelId,[Year],New ,Feature,StyleId,TransmissionId,InteriorId,ExteriorId,Mileage,MSRP,
					SalesPrice,[Description],ImageFile,DateAdded,UserId)
   VALUES (@Vin,@ModelId,@Year,@New,@Feature,@StyleId,@TransmissionId,@InteriorId,@ExteriorId,@Mileage,@MSRP,
					@SalesPrice,@Description,@ImageFile,@DateAdded,@UserId)
END 
GO


----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_SetVehicleIsSold'
)
BEGIN
    DROP PROCEDURE sp_SetVehicleIsSold
END
GO

CREATE PROCEDURE sp_SetVehicleIsSold  @Vin VARCHAR(17) 
AS
	UPDATE Vehicle 
	SET InStock = 0
	WHERE Vin = @Vin
GO

Exec sp_SetVehicleIsSold '1234567890ABCDEFG'
----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_EditVehicle'
)
BEGIN
    DROP PROCEDURE sp_EditVehicle
END
GO

CREATE PROCEDURE sp_EditVehicle @Vin VARCHAR(17),@ModelName NVARCHAR(30),@MakeName VARCHAR(30),@Year SMALLINT,@New BINARY,@Feature BINARY,@StyleName VARCHAR(30),
				@TransName VARCHAR(30),@InteriorName VARCHAR(30),@ExteriorName VARCHAR(30),@Mileage INT,@MSRP MONEY,@SalesPrice MONEY,
				@Description NVARCHAR(500),@ImageFile VARCHAR(255),@UserId nvarchar(128)
AS
   DECLARE @ModelId int = (SELECT Model.Id FROM Model JOIN Make ON Make.Id = Model.MakeId
							WHERE Model.[Name] = @ModelName and Make.[Name] = @MakeName)
   DECLARE @StyleId int = (SELECT Style.Id FROM [Style] WHERE Style.[Description] = @StyleName)
   DECLARE @TransmissionId int = (SELECT Transmission.Id FROM Transmission WHERE Transmission.[Description] = @TransName)
   DECLARE @InteriorId int = (SELECT Color.Id FROM Color WHERE Color.[Name] = @InteriorName)
   DECLARE @ExteriorId int = (SELECT Color.Id FROM Color WHERE Color.[Name] = @ExteriorName)

   UPDATE Vehicle
   SET Vin = @Vin, ModelId = @ModelId,[Year] = @Year,New = @New, Feature=@Feature ,StyleId = @StyleId,TransmissionId = @TransmissionId,
			InteriorId = @InteriorId,ExteriorId = @ExteriorId,Mileage = @Mileage,MSRP = @MSRP,
			SalesPrice = @SalesPrice,[Description] = @Description,ImageFile = @ImageFile,UserId = @UserId
   WHERE Vin = @Vin
GO


select * from Vehicle
----------------------------------------------------------------------

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'sp_DeleteVehicle'
)
BEGIN
    DROP PROCEDURE sp_DeleteVehicle
END
GO

CREATE PROCEDURE sp_DeleteVehicle @Vin VARCHAR(17)
AS
	DELETE FROM Vehicle WHERE Vin = @Vin
GO
