USE [master]
GO
/****** Object:  Database [CricBook]    Script Date: 11/29/2018 5:37:03 PM ******/
CREATE DATABASE [CricBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CricBook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.VENU12SQLEXPRESS\MSSQL\DATA\CricBook.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CricBook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.VENU12SQLEXPRESS\MSSQL\DATA\CricBook_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CricBook] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CricBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CricBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CricBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CricBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CricBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CricBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [CricBook] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CricBook] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CricBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CricBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CricBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CricBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CricBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CricBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CricBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CricBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CricBook] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CricBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CricBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CricBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CricBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CricBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CricBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CricBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CricBook] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CricBook] SET  MULTI_USER 
GO
ALTER DATABASE [CricBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CricBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CricBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CricBook] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CricBook]
GO
/****** Object:  Table [dbo].[tblCity]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[State] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCompany]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCompany](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCountry]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCountry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblExtras]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblExtras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblGameType]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGameType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblGender]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMatch]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMatch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Team_A] [int] NULL,
	[Team_B] [int] NULL,
	[Venue_Details] [nvarchar](150) NULL,
	[MatchDatetime] [datetime] NULL,
	[MatchType] [int] NULL,
	[MatchWonby] [int] NULL,
	[Result] [nvarchar](100) NULL,
	[MOM] [int] NULL,
	[GameType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMatchType]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMatchType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchType] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOut]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOut](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblPlayer]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPlayer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DOB] [date] NULL,
	[Gender] [int] NULL,
	[Country] [int] NULL,
	[State] [int] NULL,
	[City] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblState]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Country] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblStatus]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTeam]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTeam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Company] [int] NULL,
	[Country] [int] NULL,
	[State] [int] NULL,
	[City] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUmpire]    Script Date: 11/29/2018 5:37:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUmpire](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tblCity] ON 

INSERT [dbo].[tblCity] ([Id], [Name], [State]) VALUES (1, N'Hyderabad', 2)
INSERT [dbo].[tblCity] ([Id], [Name], [State]) VALUES (2, N'Vijayawada', 1)
SET IDENTITY_INSERT [dbo].[tblCity] OFF
SET IDENTITY_INSERT [dbo].[tblCompany] ON 

INSERT [dbo].[tblCompany] ([Id], [Name]) VALUES (1, N'Nspira-TC')
INSERT [dbo].[tblCompany] ([Id], [Name]) VALUES (2, N'Nspira-RO')
INSERT [dbo].[tblCompany] ([Id], [Name]) VALUES (3, N'Nspira-VIJ')
INSERT [dbo].[tblCompany] ([Id], [Name]) VALUES (4, N'Semantify')
INSERT [dbo].[tblCompany] ([Id], [Name]) VALUES (5, N'Alakriti')
SET IDENTITY_INSERT [dbo].[tblCompany] OFF
SET IDENTITY_INSERT [dbo].[tblCountry] ON 

INSERT [dbo].[tblCountry] ([Id], [Name]) VALUES (1, N'India')
INSERT [dbo].[tblCountry] ([Id], [Name]) VALUES (2, N'Pakisthan')
INSERT [dbo].[tblCountry] ([Id], [Name]) VALUES (3, N'Sri Lanka')
INSERT [dbo].[tblCountry] ([Id], [Name]) VALUES (4, N'Bangladesh')
INSERT [dbo].[tblCountry] ([Id], [Name]) VALUES (5, N'South Africa')
INSERT [dbo].[tblCountry] ([Id], [Name]) VALUES (7, N'Afghanisthan')
INSERT [dbo].[tblCountry] ([Id], [Name]) VALUES (8, N'Australia')
SET IDENTITY_INSERT [dbo].[tblCountry] OFF
SET IDENTITY_INSERT [dbo].[tblExtras] ON 

INSERT [dbo].[tblExtras] ([Id], [Name]) VALUES (1, N'Wide')
INSERT [dbo].[tblExtras] ([Id], [Name]) VALUES (2, N'No-Ball')
INSERT [dbo].[tblExtras] ([Id], [Name]) VALUES (3, N'Bye')
INSERT [dbo].[tblExtras] ([Id], [Name]) VALUES (4, N'Dead Ball')
SET IDENTITY_INSERT [dbo].[tblExtras] OFF
SET IDENTITY_INSERT [dbo].[tblGameType] ON 

INSERT [dbo].[tblGameType] ([Id], [Name], [Status]) VALUES (1, N'FCPL-3              ', 1)
INSERT [dbo].[tblGameType] ([Id], [Name], [Status]) VALUES (2, N'FCPL-2              ', 1)
INSERT [dbo].[tblGameType] ([Id], [Name], [Status]) VALUES (3, N'FCPL-1              ', 1)
INSERT [dbo].[tblGameType] ([Id], [Name], [Status]) VALUES (4, N'Weekend Match       ', 1)
SET IDENTITY_INSERT [dbo].[tblGameType] OFF
SET IDENTITY_INSERT [dbo].[tblGender] ON 

INSERT [dbo].[tblGender] ([Id], [Name]) VALUES (1, N'Male')
INSERT [dbo].[tblGender] ([Id], [Name]) VALUES (2, N'FeMale')
INSERT [dbo].[tblGender] ([Id], [Name]) VALUES (3, N'TransGender')
SET IDENTITY_INSERT [dbo].[tblGender] OFF
SET IDENTITY_INSERT [dbo].[tblMatchType] ON 

INSERT [dbo].[tblMatchType] ([Id], [MatchType], [Description]) VALUES (1, N'20-20', N'Twenty Twenty Match')
INSERT [dbo].[tblMatchType] ([Id], [MatchType], [Description]) VALUES (2, N'10-10', N'Ten Ten Match')
SET IDENTITY_INSERT [dbo].[tblMatchType] OFF
SET IDENTITY_INSERT [dbo].[tblOut] ON 

INSERT [dbo].[tblOut] ([Id], [Name]) VALUES (1, N'Catch               ')
INSERT [dbo].[tblOut] ([Id], [Name]) VALUES (2, N'Bowled              ')
SET IDENTITY_INSERT [dbo].[tblOut] OFF
SET IDENTITY_INSERT [dbo].[tblPlayer] ON 

INSERT [dbo].[tblPlayer] ([Id], [FirstName], [LastName], [DOB], [Gender], [Country], [State], [City]) VALUES (1, N'Pigilam', N'Venu', CAST(0x2D0F0B00 AS Date), 1, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[tblPlayer] OFF
SET IDENTITY_INSERT [dbo].[tblState] ON 

INSERT [dbo].[tblState] ([Id], [Name], [Country]) VALUES (1, N'Andhra Pradesh', 1)
INSERT [dbo].[tblState] ([Id], [Name], [Country]) VALUES (2, N'Telangana', 1)
INSERT [dbo].[tblState] ([Id], [Name], [Country]) VALUES (3, N'Karnataka', 1)
SET IDENTITY_INSERT [dbo].[tblState] OFF
SET IDENTITY_INSERT [dbo].[tblStatus] ON 

INSERT [dbo].[tblStatus] ([Id], [Name]) VALUES (1, N'Active    ')
INSERT [dbo].[tblStatus] ([Id], [Name]) VALUES (2, N'InActive  ')
SET IDENTITY_INSERT [dbo].[tblStatus] OFF
USE [master]
GO
ALTER DATABASE [CricBook] SET  READ_WRITE 
GO
