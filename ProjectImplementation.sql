USE [master]
GO
/****** Object:  Database [ProjectImplementation]    Script Date: 18.06.2022 21:02:47 ******/
CREATE DATABASE [ProjectImplementation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectImplementation', FILENAME = N'C:\Data_Bases\ProjectImplementation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectImplementation_log', FILENAME = N'C:\Data_Bases\ProjectImplementation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjectImplementation] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectImplementation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectImplementation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectImplementation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectImplementation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectImplementation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectImplementation] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectImplementation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectImplementation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectImplementation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectImplementation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectImplementation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectImplementation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectImplementation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectImplementation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectImplementation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectImplementation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectImplementation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectImplementation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectImplementation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectImplementation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectImplementation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectImplementation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectImplementation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectImplementation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectImplementation] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectImplementation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectImplementation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectImplementation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectImplementation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectImplementation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectImplementation] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProjectImplementation] SET QUERY_STORE = OFF
GO
USE [ProjectImplementation]
GO
/****** Object:  User [Simple]    Script Date: 18.06.2022 21:02:47 ******/
CREATE USER [Simple] FOR LOGIN [Simple] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Admin]    Script Date: 18.06.2022 21:02:47 ******/
CREATE USER [Admin] FOR LOGIN [Admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [Performers]    Script Date: 18.06.2022 21:02:47 ******/
CREATE ROLE [Performers]
GO
/****** Object:  DatabaseRole [Administrators]    Script Date: 18.06.2022 21:02:47 ******/
CREATE ROLE [Administrators]
GO
/****** Object:  DatabaseRole [Administrator]    Script Date: 18.06.2022 21:02:47 ******/
CREATE ROLE [Administrator]
GO
ALTER ROLE [Performers] ADD MEMBER [Simple]
GO
ALTER ROLE [Administrators] ADD MEMBER [Admin]
GO
/****** Object:  UserDefinedFunction [dbo].[OrderCalculate]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [dbo].[OrderCalculate](@projectId int, @dateStart date, @dateEnd date) RETURNS money
AS
BEGIN
DECLARE @sumReport money=0.0;
DECLARE @categoryCoefficient numeric(18,2)=0.0;

SELECT @categoryCoefficient=Category.Coefficient
FROM Project JOIN Category ON Project.CategoryId=Category.Id
WHERE Project.Id=@projectId;

SELECT @sumReport=SUM(T.EmpSalaryOnProject)
FROM (	SELECT  ISNULL(SUM(Report.HoursNumber*(1+Position.HourlyRate))*Qualifiction.HourleRate,0.0) AS EmpSalaryOnProject
		FROM Report JOIN Performer ON Report.PerformerId=Performer.Id 
					JOIN Employee ON Employee.Id=Performer.EmployeeId
					JOIN Career ON Career.EmployeeId=Employee.Id
					JOIN Position ON Position.Id=Career.PositionId
					JOIN Qualifiction ON Qualifiction.Id=Employee.QualificationId
					WHERE Performer.ProjectId=@projectId AND Report.[Check]=1 AND Report.Date BETWEEN @dateStart AND @dateEnd
					AND Report.Date BETWEEN Career.DateStart AND Career.DateEnd
					GROUP BY Employee.Id, Position.HourlyRate, Qualifiction.HourleRate) AS T

RETURN ISNULL(@sumReport*(1+@categoryCoefficient)*1.4,0.0);
END
GO
/****** Object:  UserDefinedFunction [dbo].[SalaryCalculate]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   FUNCTION [dbo].[SalaryCalculate](@employeeId int, @dateStart date, @dateEnd date) RETURNS money
AS
BEGIN
DECLARE @sum money=0.0;
DECLARE @qualificationRate money=0.0;
--DECLARE @positionRate numeric(18,2)=0.0;

SELECT @qualificationRate=Qualifiction.HourleRate
FROM Employee JOIN Qualifiction ON Employee.QualificationId=Qualifiction.Id 
WHERE Employee.Id=@employeeId

--SELECT @positionRate =Position.HourlyRate
--FROM Employee JOIN Position ON Employee.PositionId=Position.Id 
--WHERE Employee.Id=@employeeId

SELECT @sum=(T.SumByProject)
FROM 
(SELECT  SUM(Report.HoursNumber*(1+Position.HourlyRate))*@qualificationRate*(1+Category.Coefficient) SumByProject
FROM Employee	JOIN Performer ON Employee.Id=Performer.EmployeeId 
				JOIN Project ON Project.Id=Performer.ProjectId 
				JOIN Report ON Performer.Id=Report.PerformerId
				JOIN Category ON Category.Id =Project.CategoryId
				JOIN Career ON Employee.Id=Career.EmployeeId
				JOIN Position ON Career.PositionId=Position.Id
WHERE Employee.Id=@employeeId AND Report.[Check]=1 AND Report.Date BETWEEN @dateStart AND @dateEnd
AND Report.Date BETWEEN Career.DateStart AND Career.DateEnd
GROUP BY Project.Id, Category.Coefficient) AS T



RETURN ISNULL(@sum,0.0);
END
GO
/****** Object:  Table [dbo].[Career]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Career](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[PositionId] [int] NOT NULL,
	[DateStart] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
 CONSTRAINT [PK_Career] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Coefficient] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_CategoryProjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[QualificationId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[DateStart] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
	[Sum] [money] NOT NULL,
	[IsPayment] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Performer]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Performer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_Performer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[HourlyRate] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[HeadId] [int] NOT NULL,
	[DateStart] [date] NOT NULL,
	[Duration] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Qualifiction]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualifiction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[HourleRate] [money] NOT NULL,
 CONSTRAINT [PK_Qualifiction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PerformerId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[HoursNumber] [int] NOT NULL,
	[Action] [nvarchar](250) NOT NULL,
	[Check] [bit] NOT NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salary]    Script Date: 18.06.2022 21:02:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[DateStart] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
	[Sum] [money] NOT NULL,
 CONSTRAINT [PK_Salary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Career] ON 

INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (2, 1, 1, CAST(N'2022-04-16' AS Date), CAST(N'2022-09-30' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (4, 2, 1, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (7, 5, 2, CAST(N'2022-04-01' AS Date), CAST(N'2022-09-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (9, 6, 2, CAST(N'2022-01-01' AS Date), CAST(N'2022-09-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (10, 7, 2, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (12, 8, 3, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (13, 10, 3, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (14, 11, 3, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (15, 12, 4, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (16, 13, 4, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (17, 14, 4, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (18, 15, 4, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (20, 16, 5, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (21, 17, 5, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (22, 18, 5, CAST(N'2022-06-01' AS Date), CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Career] ([Id], [EmployeeId], [PositionId], [DateStart], [DateEnd]) VALUES (25, 20, 6, CAST(N'2022-06-18' AS Date), CAST(N'2023-10-01' AS Date))
SET IDENTITY_INSERT [dbo].[Career] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Coefficient]) VALUES (2, N'Низька', CAST(0.65 AS Numeric(18, 2)))
INSERT [dbo].[Category] ([Id], [Name], [Coefficient]) VALUES (3, N'Середня', CAST(0.80 AS Numeric(18, 2)))
INSERT [dbo].[Category] ([Id], [Name], [Coefficient]) VALUES (4, N'Висока', CAST(0.95 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (2, N'Міська лікарня', N'Львів')
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (3, N'Школа 2', N'Стрий')
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (4, N'Міська бібліотека', N'Золочів')
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (5, N'НУ ЛП', N'Львів')
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (6, N'Школа 1', N'Львів')
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (7, N'Школа 52', N'Львів')
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (8, N'Школа 12', N'Львів')
INSERT [dbo].[Customer] ([Id], [Name], [Address]) VALUES (9, N'Школа 129', N'Львів')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (1, N'Білий Петро', 2)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (2, N'Стасик Іван', 2)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (5, N'Іваненко Сергій', 4)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (6, N'Петренко Сніжана', 2)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (7, N'Галик Данило', 2)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (8, N'Кушнір Оксана ', 4)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (10, N'Кушнір Петро', 4)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (11, N'Банрак Ігор', 1)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (12, N'Лісняк Володимир', 1)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (13, N'Сердюк Олег', 2)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (14, N'Федис Ігор', 1)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (15, N'Лисенко Вікторія', 2)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (16, N'Нечипір Вікторія', 4)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (17, N'Ортинська Марія', 4)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (18, N'Зубрицька Іванна', 1)
INSERT [dbo].[Employee] ([Id], [FullName], [QualificationId]) VALUES (20, N'Test', 6)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [ProjectId], [DateStart], [DateEnd], [Sum], [IsPayment]) VALUES (18, 1, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 89202.4000, 1)
INSERT [dbo].[Order] ([Id], [ProjectId], [DateStart], [DateEnd], [Sum], [IsPayment]) VALUES (19, 2, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 89258.4000, 0)
INSERT [dbo].[Order] ([Id], [ProjectId], [DateStart], [DateEnd], [Sum], [IsPayment]) VALUES (20, 3, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 77945.0000, 0)
INSERT [dbo].[Order] ([Id], [ProjectId], [DateStart], [DateEnd], [Sum], [IsPayment]) VALUES (21, 4, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 110905.2000, 0)
INSERT [dbo].[Order] ([Id], [ProjectId], [DateStart], [DateEnd], [Sum], [IsPayment]) VALUES (22, 1, CAST(N'2022-07-01' AS Date), CAST(N'2022-07-31' AS Date), 66640.0000, 0)
INSERT [dbo].[Order] ([Id], [ProjectId], [DateStart], [DateEnd], [Sum], [IsPayment]) VALUES (23, 1, CAST(N'2022-07-01' AS Date), CAST(N'2022-07-01' AS Date), 33320.0000, 0)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Performer] ON 

INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (1, 1, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (2, 1, 3)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (3, 2, 2)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (7, 2, 4)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (8, 5, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (9, 5, 2)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (10, 6, 3)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (11, 6, 4)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (12, 7, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (13, 8, 4)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (14, 10, 3)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (15, 11, 2)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (16, 11, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (17, 12, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (18, 12, 2)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (19, 12, 3)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (20, 13, 2)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (21, 13, 3)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (24, 13, 4)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (25, 14, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (26, 14, 2)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (27, 14, 3)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (28, 15, 4)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (29, 16, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (30, 17, 2)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (31, 18, 3)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (32, 17, 4)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (33, 10, 4)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (34, 18, 2)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (35, 7, 2)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (36, 8, 2)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (37, 2, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (38, 18, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (39, 8, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (40, 18, 4)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (41, 16, 4)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (46, 17, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (47, 15, 1)
INSERT [dbo].[Performer] ([Id], [EmployeeId], [ProjectId]) VALUES (48, 16, 2)
SET IDENTITY_INSERT [dbo].[Performer] OFF
GO
SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([Id], [Name], [HourlyRate]) VALUES (1, N'Керівник проекту', CAST(1.00 AS Numeric(18, 2)))
INSERT [dbo].[Position] ([Id], [Name], [HourlyRate]) VALUES (2, N'Менеджер', CAST(0.75 AS Numeric(18, 2)))
INSERT [dbo].[Position] ([Id], [Name], [HourlyRate]) VALUES (3, N'Адміністратор', CAST(0.60 AS Numeric(18, 2)))
INSERT [dbo].[Position] ([Id], [Name], [HourlyRate]) VALUES (4, N'Програміст', CAST(0.70 AS Numeric(18, 2)))
INSERT [dbo].[Position] ([Id], [Name], [HourlyRate]) VALUES (5, N'Тестувальник', CAST(0.60 AS Numeric(18, 2)))
INSERT [dbo].[Position] ([Id], [Name], [HourlyRate]) VALUES (6, N'Фінансист', CAST(0.60 AS Numeric(18, 2)))
INSERT [dbo].[Position] ([Id], [Name], [HourlyRate]) VALUES (7, N'Секретар', CAST(0.40 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Position] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Name], [CustomerId], [HeadId], [DateStart], [Duration], [CategoryId]) VALUES (1, N'Система обліку препаратів', 2, 1, CAST(N'2022-06-01' AS Date), 400, 3)
INSERT [dbo].[Project] ([Id], [Name], [CustomerId], [HeadId], [DateStart], [Duration], [CategoryId]) VALUES (2, N'Пожежна система', 3, 2, CAST(N'2022-06-01' AS Date), 150, 4)
INSERT [dbo].[Project] ([Id], [Name], [CustomerId], [HeadId], [DateStart], [Duration], [CategoryId]) VALUES (3, N'Облік книжок', 4, 1, CAST(N'2022-06-01' AS Date), 150, 3)
INSERT [dbo].[Project] ([Id], [Name], [CustomerId], [HeadId], [DateStart], [Duration], [CategoryId]) VALUES (4, N'Електронний журнал', 3, 2, CAST(N'2022-06-01' AS Date), 90, 4)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Qualifiction] ON 

INSERT [dbo].[Qualifiction] ([Id], [Name], [HourleRate]) VALUES (1, N'Кваліфікація A', 500.0000)
INSERT [dbo].[Qualifiction] ([Id], [Name], [HourleRate]) VALUES (2, N'Кваліфікація B', 700.0000)
INSERT [dbo].[Qualifiction] ([Id], [Name], [HourleRate]) VALUES (4, N'Кваліфікація C', 900.0000)
INSERT [dbo].[Qualifiction] ([Id], [Name], [HourleRate]) VALUES (5, N'Кваліфікація D', 930.0000)
INSERT [dbo].[Qualifiction] ([Id], [Name], [HourleRate]) VALUES (6, N'Кваліфікація E', 950.0000)
SET IDENTITY_INSERT [dbo].[Qualifiction] OFF
GO
SET IDENTITY_INSERT [dbo].[Report] ON 

INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (24, 1, CAST(N'2022-06-01' AS Date), 5, N'111', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (26, 2, CAST(N'2022-06-01' AS Date), 5, N'111', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (27, 3, CAST(N'2022-06-01' AS Date), 3, N'111', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (28, 7, CAST(N'2022-06-01' AS Date), 6, N'111', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (29, 8, CAST(N'2022-06-01' AS Date), 7, N'112', 0)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (30, 9, CAST(N'2022-06-01' AS Date), 2, N'112', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (31, 10, CAST(N'2022-06-01' AS Date), 5, N'112', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (32, 11, CAST(N'2022-06-01' AS Date), 5, N'112', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (33, 12, CAST(N'2022-06-01' AS Date), 10, N'112', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (34, 13, CAST(N'2022-06-01' AS Date), 8, N'113', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (35, 14, CAST(N'2022-06-01' AS Date), 7, N'113', 0)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (36, 15, CAST(N'2022-06-01' AS Date), 4, N'113', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (37, 16, CAST(N'2022-06-01' AS Date), 6, N'113', 0)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (38, 17, CAST(N'2022-06-02' AS Date), 10, N'200', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (39, 20, CAST(N'2022-06-02' AS Date), 10, N'201', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (40, 25, CAST(N'2022-06-02' AS Date), 10, N'202', 0)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (41, 28, CAST(N'2022-06-02' AS Date), 5, N'203', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (42, 18, CAST(N'2022-06-03' AS Date), 10, N'200', 0)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (44, 21, CAST(N'2022-06-03' AS Date), 10, N'201', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (45, 26, CAST(N'2022-06-03' AS Date), 10, N'202', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (47, 19, CAST(N'2022-06-04' AS Date), 10, N'200', 0)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (48, 24, CAST(N'2022-06-04' AS Date), 10, N'201', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (49, 27, CAST(N'2022-06-04' AS Date), 10, N'202', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (50, 28, CAST(N'2022-06-04' AS Date), 5, N'203', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (51, 29, CAST(N'2022-06-06' AS Date), 7, N'300', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (52, 30, CAST(N'2022-06-06' AS Date), 4, N'301', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (53, 31, CAST(N'2022-06-06' AS Date), 8, N'302', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (54, 32, CAST(N'2022-06-06' AS Date), 6, N'301', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (56, 1, CAST(N'2022-06-06' AS Date), 1, N'111', 0)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (58, 1, CAST(N'2022-06-06' AS Date), 3, N'111', 0)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (59, 1, CAST(N'2022-07-01' AS Date), 10, N'111', 1)
INSERT [dbo].[Report] ([Id], [PerformerId], [Date], [HoursNumber], [Action], [Check]) VALUES (60, 1, CAST(N'2022-07-02' AS Date), 10, N'111', 1)
SET IDENTITY_INSERT [dbo].[Report] OFF
GO
SET IDENTITY_INSERT [dbo].[Salary] ON 

INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (30, 1, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 11900.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (31, 2, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 5400.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (32, 5, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 5508.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (33, 6, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 10115.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (34, 7, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 20230.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (35, 8, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 20736.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (36, 11, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 5760.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (37, 12, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 14450.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (38, 13, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 20230.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (39, 14, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 14450.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (40, 15, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 10710.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (41, 16, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 17136.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (42, 17, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 10368.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (43, 18, CAST(N'2022-06-01' AS Date), CAST(N'2022-06-30' AS Date), 10880.0000)
INSERT [dbo].[Salary] ([Id], [EmployeeId], [DateStart], [DateEnd], [Sum]) VALUES (44, 1, CAST(N'2022-07-01' AS Date), CAST(N'2022-07-31' AS Date), 47600.0000)
SET IDENTITY_INSERT [dbo].[Salary] OFF
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_IsPayment]  DEFAULT ((0)) FOR [IsPayment]
GO
ALTER TABLE [dbo].[Report] ADD  CONSTRAINT [DF_Report_Check]  DEFAULT ((0)) FOR [Check]
GO
ALTER TABLE [dbo].[Career]  WITH CHECK ADD  CONSTRAINT [FK_Career_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Career] CHECK CONSTRAINT [FK_Career_Employee]
GO
ALTER TABLE [dbo].[Career]  WITH CHECK ADD  CONSTRAINT [FK_Career_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[Career] CHECK CONSTRAINT [FK_Career_Position]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Qualifiction] FOREIGN KEY([QualificationId])
REFERENCES [dbo].[Qualifiction] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Qualifiction]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Project]
GO
ALTER TABLE [dbo].[Performer]  WITH CHECK ADD  CONSTRAINT [FK_Performer_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Performer] CHECK CONSTRAINT [FK_Performer_Employee]
GO
ALTER TABLE [dbo].[Performer]  WITH CHECK ADD  CONSTRAINT [FK_Performer_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Performer] CHECK CONSTRAINT [FK_Performer_Project]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_CategoryProjects] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_CategoryProjects]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Customer]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Performer] FOREIGN KEY([PerformerId])
REFERENCES [dbo].[Performer] ([Id])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Performer]
GO
ALTER TABLE [dbo].[Salary]  WITH CHECK ADD  CONSTRAINT [FK_Salary_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Salary] CHECK CONSTRAINT [FK_Salary_Employee]
GO
/****** Object:  StoredProcedure [dbo].[GenarateOrder]    Script Date: 18.06.2022 21:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[GenarateOrder]  @dateStart date, @dateEnd date
AS
BEGIN

INSERT INTO [Order](ProjectId, DateStart, DateEnd, [Sum])
SELECT Project.Id, @dateStart, @dateEnd, dbo.OrderCalculate(Project.Id, @dateStart, @dateEnd)
FROM Project
WHERE dbo.OrderCalculate(Project.Id, @dateStart, @dateEnd)>0

END
GO
/****** Object:  StoredProcedure [dbo].[GenarateSalary]    Script Date: 18.06.2022 21:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[GenarateSalary]  @dateStart date, @dateEnd date
AS
BEGIN

INSERT INTO Salary(EmployeeId, DateStart, DateEnd, [Sum])
SELECT Employee.Id, @dateStart, @dateEnd, dbo.SalaryCalculate(Employee.Id, @dateStart, @dateEnd)
FROM Employee
WHERE dbo.SalaryCalculate(Employee.Id, @dateStart, @dateEnd)>0

END
GO
/****** Object:  StoredProcedure [dbo].[PERFORMERS_FOR_PROJECT]    Script Date: 18.06.2022 21:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[PERFORMERS_FOR_PROJECT] @progectId int
AS
BEGIN
	SELECT Employee.Id EmployeeId, Employee.FullName, Qualifiction.Name [Qualification], Position.Name [Position]
	FROM	Employee JOIN Qualifiction ON Employee.QualificationId=Qualifiction.Id
			JOIN Career ON Career.EmployeeId=Employee.Id 
			JOIN Position 	ON Career.PositionId=Position.Id
	WHERE Employee.Id NOT IN(SELECT Performer.EmployeeId FROM Performer WHERE Performer.ProjectId=@progectId)
	AND Career.DateStart=(SELECT MAX(C1.DateStart) FROM Career C1 WHERE C1.EmployeeId=Employee.Id)
END
GO
/****** Object:  StoredProcedure [dbo].[PROJECTS_REPORT]    Script Date: 18.06.2022 21:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROJECTS_REPORT]
AS
BEGIN
		SELECT Project.Name AS [Project], Customer.Name AS [Customer], Category.Name AS [Category],
		ISNULL((SELECT SUM([Order].Sum) FROM [Order] WHERE [Order].ProjectId=Project.Id),0) AS [OrdersSum],
		ISNULL((SELECT SUM([Order].Sum) FROM [Order] WHERE [Order].ProjectId=Project.Id AND [Order].IsPayment=1),0) AS [PaymentsSum]

		FROM Project INNER JOIN Category ON Project.CategoryId=Category.Id INNER JOIN Customer ON Customer.Id=Project.CustomerId

END
GO
/****** Object:  StoredProcedure [dbo].[SALARY_BY_PERIOD]    Script Date: 18.06.2022 21:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SALARY_BY_PERIOD](@dateStart date, @dateEnd date)
AS
BEGIN
	SELECT Employee.FullName AS [Employee], Qualifiction.Name AS [Qualification], Salary.Sum [SalarySum]
	FROM Salary INNER JOIN Employee ON Employee.Id=Salary.EmployeeId INNER JOIN Qualifiction ON Qualifiction.Id=Employee.QualificationId
	WHERE  Salary.DateStart >= @dateStart AND Salary.DateEnd <= @dateEnd

END
GO
/****** Object:  StoredProcedure [dbo].[SALARY_BY_PERIOD_QUALIFICATION_POSITION]    Script Date: 18.06.2022 21:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SALARY_BY_PERIOD_QUALIFICATION_POSITION](@dateStart date, @dateEnd date)
AS
BEGIN
	SELECT		Employee.FullName AS [Employee], 
				(SELECT Position.Name FROM Career JOIN Position ON Career.PositionId=Position.Id WHERE Career.EmployeeId=Employee.Id AND @dateStart BETWEEN Career.DateStart AND Career.DateEnd AND @dateEnd BETWEEN Career.DateStart AND Career.DateEnd) [Position],  
				Qualifiction.Name AS [Qualification],  
				Salary.Sum [SalarySum]
	FROM Salary INNER JOIN Employee ON Employee.Id=Salary.EmployeeId INNER JOIN Qualifiction ON Qualifiction.Id=Employee.QualificationId
	WHERE  Salary.DateStart >= @dateStart AND Salary.DateEnd <= @dateEnd

END
GO
USE [master]
GO
ALTER DATABASE [ProjectImplementation] SET  READ_WRITE 
GO
