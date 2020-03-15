USE [master]
GO
/****** Object:  Database [FlooringOrderSys]    Script Date: 3/5/2020 4:23:32 PM ******/
CREATE DATABASE [FlooringOrderSys]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FlooringOrderSys', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FlooringOrderSys.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FlooringOrderSys_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FlooringOrderSys_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FlooringOrderSys] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FlooringOrderSys].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FlooringOrderSys] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET ARITHABORT OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FlooringOrderSys] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FlooringOrderSys] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FlooringOrderSys] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FlooringOrderSys] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET RECOVERY FULL 
GO
ALTER DATABASE [FlooringOrderSys] SET  MULTI_USER 
GO
ALTER DATABASE [FlooringOrderSys] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FlooringOrderSys] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FlooringOrderSys] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FlooringOrderSys] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FlooringOrderSys] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FlooringOrderSys', N'ON'
GO
ALTER DATABASE [FlooringOrderSys] SET QUERY_STORE = OFF
GO
USE [FlooringOrderSys]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/5/2020 4:23:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderNo] [int] IDENTITY(1,1) NOT NULL,
	[CustName] [varchar](50) NOT NULL,
	[State] [varchar](20) NULL,
	[ProductType] [varchar](50) NULL,
	[Area] [decimal](18, 3) NOT NULL,
	[OrderDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/5/2020 4:23:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Type] [varchar](50) NOT NULL,
	[CostPerSquareFoot] [decimal](18, 0) NOT NULL,
	[LaborCostPerSquareFoot] [decimal](18, 3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 3/5/2020 4:23:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateAbbreviation] [varchar](20) NOT NULL,
	[StateName] [varchar](50) NOT NULL,
	[TaxRate] [decimal](18, 3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StateAbbreviation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderNo], [CustName], [State], [ProductType], [Area], [OrderDate]) VALUES (2, N'Wise', N'OH', N'Wood', CAST(100.000 AS Decimal(18, 3)), CAST(N'2020-03-05' AS Date))
INSERT [dbo].[Order] ([OrderNo], [CustName], [State], [ProductType], [Area], [OrderDate]) VALUES (5, N'Ashish', N'PA', N'Marbel', CAST(221.000 AS Decimal(18, 3)), CAST(N'2021-03-03' AS Date))
INSERT [dbo].[Order] ([OrderNo], [CustName], [State], [ProductType], [Area], [OrderDate]) VALUES (6, N'Tom', N'MI', N'Marbel', CAST(130.000 AS Decimal(18, 3)), CAST(N'2021-03-03' AS Date))
INSERT [dbo].[Order] ([OrderNo], [CustName], [State], [ProductType], [Area], [OrderDate]) VALUES (7, N'Dany', N'PA', N'Wood', CAST(130.000 AS Decimal(18, 3)), CAST(N'2021-03-03' AS Date))
INSERT [dbo].[Order] ([OrderNo], [CustName], [State], [ProductType], [Area], [OrderDate]) VALUES (8, N'Sally', N'OH', N'Tile', CAST(220.000 AS Decimal(18, 3)), CAST(N'2021-03-03' AS Date))
INSERT [dbo].[Order] ([OrderNo], [CustName], [State], [ProductType], [Area], [OrderDate]) VALUES (10, N'ttt', N'OH', N'Marbel', CAST(230.000 AS Decimal(18, 3)), CAST(N'2021-03-03' AS Date))
SET IDENTITY_INSERT [dbo].[Order] OFF
INSERT [dbo].[Product] ([Type], [CostPerSquareFoot], [LaborCostPerSquareFoot]) VALUES (N'Carpet', CAST(2 AS Decimal(18, 0)), CAST(2.100 AS Decimal(18, 3)))
INSERT [dbo].[Product] ([Type], [CostPerSquareFoot], [LaborCostPerSquareFoot]) VALUES (N'Laminate', CAST(2 AS Decimal(18, 0)), CAST(2.100 AS Decimal(18, 3)))
INSERT [dbo].[Product] ([Type], [CostPerSquareFoot], [LaborCostPerSquareFoot]) VALUES (N'Marbel', CAST(2 AS Decimal(18, 0)), CAST(25.000 AS Decimal(18, 3)))
INSERT [dbo].[Product] ([Type], [CostPerSquareFoot], [LaborCostPerSquareFoot]) VALUES (N'Tile', CAST(4 AS Decimal(18, 0)), CAST(4.150 AS Decimal(18, 3)))
INSERT [dbo].[Product] ([Type], [CostPerSquareFoot], [LaborCostPerSquareFoot]) VALUES (N'Wood', CAST(5 AS Decimal(18, 0)), CAST(4.750 AS Decimal(18, 3)))
INSERT [dbo].[State] ([StateAbbreviation], [StateName], [TaxRate]) VALUES (N'HI', N'Hawai', CAST(100.000 AS Decimal(18, 3)))
INSERT [dbo].[State] ([StateAbbreviation], [StateName], [TaxRate]) VALUES (N'IN', N'Indiana', CAST(6.000 AS Decimal(18, 3)))
INSERT [dbo].[State] ([StateAbbreviation], [StateName], [TaxRate]) VALUES (N'MI', N'Michigan', CAST(5.750 AS Decimal(18, 3)))
INSERT [dbo].[State] ([StateAbbreviation], [StateName], [TaxRate]) VALUES (N'OH', N'Ohio', CAST(6.250 AS Decimal(18, 3)))
INSERT [dbo].[State] ([StateAbbreviation], [StateName], [TaxRate]) VALUES (N'PA', N'Pennsylvania', CAST(6.750 AS Decimal(18, 3)))
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_ProductType] FOREIGN KEY([ProductType])
REFERENCES [dbo].[Product] ([Type])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_ProductType]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_State] FOREIGN KEY([State])
REFERENCES [dbo].[State] ([StateAbbreviation])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_State]
GO
USE [master]
GO
ALTER DATABASE [FlooringOrderSys] SET  READ_WRITE 
GO
