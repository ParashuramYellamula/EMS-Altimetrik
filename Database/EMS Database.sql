USE [EMS]
GO
/****** Object:  Table [dbo].[Voter]    Script Date: 6/23/2022 10:49:04 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Voter]') AND type in (N'U'))
DROP TABLE [dbo].[Voter]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/23/2022 10:49:04 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/23/2022 10:49:04 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[Party]    Script Date: 6/23/2022 10:49:04 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Party]') AND type in (N'U'))
DROP TABLE [dbo].[Party]
GO
/****** Object:  Table [dbo].[ElectionSymbols]    Script Date: 6/23/2022 10:49:04 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ElectionSymbols]') AND type in (N'U'))
DROP TABLE [dbo].[ElectionSymbols]
GO
/****** Object:  Table [dbo].[Election]    Script Date: 6/23/2022 10:49:04 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Election]') AND type in (N'U'))
DROP TABLE [dbo].[Election]
GO
/****** Object:  Table [dbo].[Constituency]    Script Date: 6/23/2022 10:49:04 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Constituency]') AND type in (N'U'))
DROP TABLE [dbo].[Constituency]
GO
/****** Object:  Table [dbo].[Candidate]    Script Date: 6/23/2022 10:49:04 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Candidate]') AND type in (N'U'))
DROP TABLE [dbo].[Candidate]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 6/23/2022 10:49:04 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND type in (N'U'))
DROP TABLE [dbo].[Address]
GO
USE [master]
GO
/****** Object:  Database [EMS]    Script Date: 6/23/2022 10:49:04 AM ******/
DROP DATABASE [EMS]
GO
/****** Object:  Database [EMS]    Script Date: 6/23/2022 10:49:04 AM ******/
CREATE DATABASE [EMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EMS', FILENAME = N'C:\Users\pyellamula\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\EMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EMS_log', FILENAME = N'C:\Users\pyellamula\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\EMS.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EMS] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EMS] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [EMS] SET ANSI_NULLS ON 
GO
ALTER DATABASE [EMS] SET ANSI_PADDING ON 
GO
ALTER DATABASE [EMS] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [EMS] SET ARITHABORT ON 
GO
ALTER DATABASE [EMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EMS] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [EMS] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [EMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EMS] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [EMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EMS] SET RECOVERY FULL 
GO
ALTER DATABASE [EMS] SET  MULTI_USER 
GO
ALTER DATABASE [EMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EMS] SET QUERY_STORE = OFF
GO
USE [EMS]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [EMS]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 6/23/2022 10:49:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] NOT NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[PostalCode] [nvarchar](6) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Candidate]    Script Date: 6/23/2022 10:49:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Party] [nvarchar](100) NULL,
	[Constituency] [nvarchar](100) NULL,
	[Address] [nvarchar](100) NULL,
 CONSTRAINT [PK_Candidate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Constituency]    Script Date: 6/23/2022 10:49:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Constituency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[State] [nvarchar](50) NULL,
	[ConstituencyName] [nvarchar](50) NULL,
	[CurrentMember] [nvarchar](50) NULL,
 CONSTRAINT [PK_MemberOfParliment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Election]    Script Date: 6/23/2022 10:49:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Election](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Constituency] [nvarchar](100) NULL,
	[Candidate] [nvarchar](100) NULL,
	[Party] [nvarchar](100) NULL,
	[Symbol] [nvarchar](100) NULL,
	[Votes] [int] NULL,
 CONSTRAINT [PK_Election] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ElectionSymbols]    Script Date: 6/23/2022 10:49:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElectionSymbols](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Symbol] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ElectionSymbols] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Party]    Script Date: 6/23/2022 10:49:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Party](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Symbol] [nvarchar](100) NULL,
	[Address] [nvarchar](100) NULL,
 CONSTRAINT [PK_Party] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/23/2022 10:49:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] NOT NULL,
	[Role] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/23/2022 10:49:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voter]    Script Date: 6/23/2022 10:49:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[Aadhar] [nvarchar](10) NULL,
	[Mobile] [nvarchar](10) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[DateOfBirth] [date] NULL,
 CONSTRAINT [PK_Voter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Candidate] ON 

INSERT [dbo].[Candidate] ([Id], [Name], [Party], [Constituency], [Address]) VALUES (1, N'KVR', N'Congress', N'Nalgonda', N'Nalgonda')
INSERT [dbo].[Candidate] ([Id], [Name], [Party], [Constituency], [Address]) VALUES (2, N'KBR', N'TRS', N'Nalgonda', N'Nalgonda')
INSERT [dbo].[Candidate] ([Id], [Name], [Party], [Constituency], [Address]) VALUES (3, N'NVR', N'BJP', N'Nalgonda', N'Nalgonda')
SET IDENTITY_INSERT [dbo].[Candidate] OFF
GO
SET IDENTITY_INSERT [dbo].[Constituency] ON 

INSERT [dbo].[Constituency] ([Id], [State], [ConstituencyName], [CurrentMember]) VALUES (1, N'Telangana', N'Nalgonda', N'KVR')
INSERT [dbo].[Constituency] ([Id], [State], [ConstituencyName], [CurrentMember]) VALUES (2, N'Andhra Pradesh', N'Guntur', N'Manoj')
INSERT [dbo].[Constituency] ([Id], [State], [ConstituencyName], [CurrentMember]) VALUES (3, N'Telangana', N'Hyderabad', N'hyd')
INSERT [dbo].[Constituency] ([Id], [State], [ConstituencyName], [CurrentMember]) VALUES (4, N'Delhi', N'Delhi', N'dd')
INSERT [dbo].[Constituency] ([Id], [State], [ConstituencyName], [CurrentMember]) VALUES (8, N'Maharastra', N'Mumbai', N'Ram')
SET IDENTITY_INSERT [dbo].[Constituency] OFF
GO
SET IDENTITY_INSERT [dbo].[Election] ON 

INSERT [dbo].[Election] ([Id], [Constituency], [Candidate], [Party], [Symbol], [Votes]) VALUES (1, N'Nalgonda', N'KBR', N'TRS', N'Car.jpg', 0)
INSERT [dbo].[Election] ([Id], [Constituency], [Candidate], [Party], [Symbol], [Votes]) VALUES (2, N'Nalgonda', N'KVR', N'Congress', N'Hand.jpg', 0)
INSERT [dbo].[Election] ([Id], [Constituency], [Candidate], [Party], [Symbol], [Votes]) VALUES (3, N'Nalgonda', N'Ram', N'BJP', N'Kamalam.jpg', 5)
INSERT [dbo].[Election] ([Id], [Constituency], [Candidate], [Party], [Symbol], [Votes]) VALUES (4, N'Delhi', N'AA', N'Congress', N'Car.jpg', 1)
INSERT [dbo].[Election] ([Id], [Constituency], [Candidate], [Party], [Symbol], [Votes]) VALUES (5, N'Delhi', N'BB', N'BJP', N'Kamalam.jpg', 0)
SET IDENTITY_INSERT [dbo].[Election] OFF
GO
SET IDENTITY_INSERT [dbo].[ElectionSymbols] ON 

INSERT [dbo].[ElectionSymbols] ([Id], [Name], [Symbol]) VALUES (1, N'BJP', N'Kamalam.jpg')
INSERT [dbo].[ElectionSymbols] ([Id], [Name], [Symbol]) VALUES (2, N'Congress', N'Hand.jpg')
INSERT [dbo].[ElectionSymbols] ([Id], [Name], [Symbol]) VALUES (3, N'TRS', N'Car.jpg')
SET IDENTITY_INSERT [dbo].[ElectionSymbols] OFF
GO
SET IDENTITY_INSERT [dbo].[Party] ON 

INSERT [dbo].[Party] ([Id], [Name], [Description], [Symbol], [Address]) VALUES (1, N'BJP', N'Baratiya Janatha Party', N'Kamalam.jpg', N'Delhi')
INSERT [dbo].[Party] ([Id], [Name], [Description], [Symbol], [Address]) VALUES (2, N'Congress', N'Congress', N'Hand.jpg', N'Delihi')
INSERT [dbo].[Party] ([Id], [Name], [Description], [Symbol], [Address]) VALUES (4, N'TRS', N'TRS', N'Car.jpg', N'Hyderabad')
SET IDENTITY_INSERT [dbo].[Party] OFF
GO
INSERT [dbo].[Roles] ([Id], [Role], [Description]) VALUES (1, N'Admin', N'Election commissioner')
INSERT [dbo].[Roles] ([Id], [Role], [Description]) VALUES (2, N'Voter', N'Voter')
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Password]) VALUES (1, N'admin', N'AQAAAAEAACcQAAAAEDr/iZ0qxtTbF7Bial8biL1ZYZe2n/JXhLu5cZftpxLTO3gYWdWZ7vov2YBn2FJpoQ==')
INSERT [dbo].[User] ([Id], [Name], [Password]) VALUES (2, N'voter', N'AQAAAAEAACcQAAAAEPR5LK016a2mTPUlrBK+nL8pqMAU50NnF3QAqPOd9KnN5931+n6H417/YpMJIwUQbg==')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Voter] ON 

INSERT [dbo].[Voter] ([Id], [FirstName], [LastName], [Aadhar], [Mobile], [Email], [Address], [DateOfBirth]) VALUES (1, N'Voter', N'aa', N'1221212', N'9996855785', N'12121', N'122', CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Voter] ([Id], [FirstName], [LastName], [Aadhar], [Mobile], [Email], [Address], [DateOfBirth]) VALUES (2, N'Voter1', N'444', N'222', N'89756985', N'22', N'222', CAST(N'0001-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[Voter] OFF
GO
USE [master]
GO
ALTER DATABASE [EMS] SET  READ_WRITE 
GO
