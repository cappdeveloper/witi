USE [master]
GO
/****** Object:  Database [Construction_DB]    Script Date: 12/19/2016 2:39:03 AM ******/
CREATE DATABASE [Construction_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Construction_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Construction_DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Construction_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Construction_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Construction_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Construction_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Construction_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Construction_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Construction_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Construction_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Construction_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Construction_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Construction_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Construction_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Construction_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Construction_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Construction_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Construction_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Construction_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Construction_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Construction_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Construction_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Construction_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Construction_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Construction_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Construction_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Construction_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Construction_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Construction_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Construction_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Construction_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Construction_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Construction_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Construction_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Construction_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Construction_DB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[CompanyEmail] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[ContractorId] [int] NOT NULL,
	[Zip] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Name] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Change_Order]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Change_Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[JobID] [int] NULL,
	[itemid] [int] NULL,
	[new_quantity] [int] NULL,
	[quantity_Added] [datetime] NULL,
	[changeOrder] [varchar](50) NULL,
 CONSTRAINT [PK_Change_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DailyItems]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DailyItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemNumber] [int] NULL,
	[Quantity] [float] NULL,
	[added_date] [date] NULL,
	[JobDataId] [int] NULL,
	[Location] [varchar](100) NULL,
	[EntryType] [varchar](50) NULL,
	[Unit_Contractor] [int] NULL,
	[Subcontractorid] [int] NULL,
 CONSTRAINT [PK_DailyItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobID] [int] NOT NULL,
	[Description] [varchar](max) NULL,
	[UnitType] [varchar](50) NULL,
	[UnitPrice] [float] NULL,
	[InitialQuantity] [float] NULL,
	[ItemNumber] [int] NOT NULL,
	[SubContractorQuantity] [float] NULL,
	[SubContractorId] [int] NULL,
	[SubUnit_price] [float] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContractorID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Zip] [varchar](10) NULL,
	[Phone] [varchar](14) NULL,
	[Fax] [varchar](14) NULL,
	[Email] [varchar](30) NULL,
	[Active] [bit] NULL,
	[Created_Date] [datetime] NULL,
	[Modified_date] [datetime] NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[JobData]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[JobData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Weather] [varchar](250) NULL,
	[Temperature] [float] NULL,
	[Shift] [varchar](250) NOT NULL,
	[Estimate] [varchar](200) NULL,
	[Notes] [varchar](1000) NULL,
	[ContractorId] [int] NULL,
	[EntryType] [varchar](50) NULL,
 CONSTRAINT [PK_JobData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[payment]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Clientname] [varchar](100) NULL,
	[FromUser] [int] NULL,
	[createddate] [date] NULL,
	[units] [float] NULL,
	[UnitPrice] [float] NULL,
	[Jobid] [int] NULL,
	[Itemid] [int] NULL,
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_sub_contractor]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_sub_contractor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
	[Phone] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Contractorid] [int] NULL,
	[Added] [date] NULL,
 CONSTRAINT [PK_tbl_sub_contractor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblContractor]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblContractor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](100) NULL,
	[Address] [varchar](200) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](40) NULL,
	[Zip] [varchar](50) NULL,
	[Notes] [varchar](300) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Isactive] [bit] NULL,
 CONSTRAINT [PK_TblCOntractor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDailyEquipment]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDailyEquipment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[equipmentid] [int] NULL,
	[jobdataid] [int] NULL,
	[numberof] [int] NULL,
 CONSTRAINT [PK_tblDailyEquipment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblEquipment]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEquipment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Equipment_name] [varchar](200) NULL,
	[COntractor_id] [int] NULL,
 CONSTRAINT [PK_tblEquipment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblworkforce]    Script Date: 12/19/2016 2:39:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblworkforce](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Workforcename] [varchar](50) NULL,
	[numberof] [int] NULL,
	[JobDataid] [int] NULL,
 CONSTRAINT [PK_tblworkforce] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'User')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'00f9a3de-a827-4d06-bee9-4318cea98037', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'32aabb02-fc5c-475a-9149-0a5a53f06445', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'72465d7d-5334-4dc1-9722-6cc9f859228d', N'2')
INSERT [dbo].[AspNetUsers] ([Id], [CompanyEmail], [Address], [City], [Country], [Notes], [ContractorId], [Zip], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [CreatedDate], [isActive]) VALUES (N'00f9a3de-a827-4d06-bee9-4318cea98037', N'bhu@gmail.com', N'vpo-patta teh bhoranj distt ha, 55, ghjgj', N'hamirpur', NULL, N'sdsd', 3, N'176041', N'bhu@gmail.com', 0, N'AMbYlpf0jiRhZWkAiZClGwqhaHDGlabc0wjS6AzsSKAsd6FL+7+e82lhA2RfNW/CMg==', N'288d7748-0486-4196-9a23-283621598f47', N'9915045891', 0, 0, NULL, 1, 0, N'bhu@gmail.com', N'vikas', CAST(0x0000A0F300B58C90 AS DateTime), 1)
INSERT [dbo].[AspNetUsers] ([Id], [CompanyEmail], [Address], [City], [Country], [Notes], [ContractorId], [Zip], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [CreatedDate], [isActive]) VALUES (N'32aabb02-fc5c-475a-9149-0a5a53f06445', N'ben@gmail.com', N'dfdf', N'dfdf', NULL, N'dfdfdf', 3, N'5454', N'ben@gmail.com', 0, N'AMbYlpf0jiRhZWkAiZClGwqhaHDGlabc0wjS6AzsSKAsd6FL+7+e82lhA2RfNW/CMg==', N'288d7748-0486-4196-9a23-283621598f47', N'dfdf', 0, 0, NULL, 1, 0, N'ben@gmail.com', N'sfsdfsdf', CAST(0x0000A6E000C6A69D AS DateTime), 1)
INSERT [dbo].[AspNetUsers] ([Id], [CompanyEmail], [Address], [City], [Country], [Notes], [ContractorId], [Zip], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [CreatedDate], [isActive]) VALUES (N'72465d7d-5334-4dc1-9722-6cc9f859228d', N'as200261@gmail.com', N'vpo-patta teh bhoranj distt ha, 55, ghjgj', N'hamirpur', NULL, N'sdsdsd', 3, N'176041555', N'as200261@gmail.com', 0, N'AEavs80FmxIuMWI5reiRbSpe75sMpr0lLxeY79NqNw9e63RqhNN3IwVKqeo8dGSs4w==', N'08b2b530-2a8d-492f-8151-138f41d88284', N'hi', 0, 0, NULL, 1, 0, N'as200261@gmail.com', N'Abhil', CAST(0x0000A6E000C188D4 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Change_Order] ON 

INSERT [dbo].[Change_Order] ([id], [JobID], [itemid], [new_quantity], [quantity_Added], [changeOrder]) VALUES (9, 1016, 1031, 333, CAST(0x0000A5FD00000000 AS DateTime), NULL)
INSERT [dbo].[Change_Order] ([id], [JobID], [itemid], [new_quantity], [quantity_Added], [changeOrder]) VALUES (19, 15, 28, 22, CAST(0x0000A60500000000 AS DateTime), NULL)
INSERT [dbo].[Change_Order] ([id], [JobID], [itemid], [new_quantity], [quantity_Added], [changeOrder]) VALUES (20, 1019, 1039, 333, CAST(0x0000A60500000000 AS DateTime), NULL)
INSERT [dbo].[Change_Order] ([id], [JobID], [itemid], [new_quantity], [quantity_Added], [changeOrder]) VALUES (21, 1019, 1039, -23, CAST(0x0000A60500000000 AS DateTime), NULL)
INSERT [dbo].[Change_Order] ([id], [JobID], [itemid], [new_quantity], [quantity_Added], [changeOrder]) VALUES (22, 1019, 1034, -10, CAST(0x0000A60500000000 AS DateTime), NULL)
INSERT [dbo].[Change_Order] ([id], [JobID], [itemid], [new_quantity], [quantity_Added], [changeOrder]) VALUES (23, 1019, 1039, -10, CAST(0x0000A60500000000 AS DateTime), NULL)
INSERT [dbo].[Change_Order] ([id], [JobID], [itemid], [new_quantity], [quantity_Added], [changeOrder]) VALUES (24, 1019, 1041, 23, CAST(0x0000A60600000000 AS DateTime), N'Sub')
INSERT [dbo].[Change_Order] ([id], [JobID], [itemid], [new_quantity], [quantity_Added], [changeOrder]) VALUES (1024, 1020, 1036, 22, CAST(0x0000A6E000000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Change_Order] OFF
SET IDENTITY_INSERT [dbo].[DailyItems] ON 

INSERT [dbo].[DailyItems] ([Id], [ItemNumber], [Quantity], [added_date], [JobDataId], [Location], [EntryType], [Unit_Contractor], [Subcontractorid]) VALUES (2072, 1038, 22, CAST(0x5F3B0B00 AS Date), 2039, N'sdf', NULL, 21, 1)
INSERT [dbo].[DailyItems] ([Id], [ItemNumber], [Quantity], [added_date], [JobDataId], [Location], [EntryType], [Unit_Contractor], [Subcontractorid]) VALUES (2073, 1031, 22, CAST(0x5F3B0B00 AS Date), 2040, N'sfsdf', NULL, NULL, NULL)
INSERT [dbo].[DailyItems] ([Id], [ItemNumber], [Quantity], [added_date], [JobDataId], [Location], [EntryType], [Unit_Contractor], [Subcontractorid]) VALUES (2074, 1038, 22, CAST(0x5F3B0B00 AS Date), 2039, N'as', NULL, NULL, NULL)
INSERT [dbo].[DailyItems] ([Id], [ItemNumber], [Quantity], [added_date], [JobDataId], [Location], [EntryType], [Unit_Contractor], [Subcontractorid]) VALUES (2075, 1034, 20, CAST(0x603B0B00 AS Date), 2041, N'sdfdf', NULL, NULL, NULL)
INSERT [dbo].[DailyItems] ([Id], [ItemNumber], [Quantity], [added_date], [JobDataId], [Location], [EntryType], [Unit_Contractor], [Subcontractorid]) VALUES (2076, 26, 100, CAST(0x603B0B00 AS Date), 2042, N'sdff', NULL, NULL, NULL)
INSERT [dbo].[DailyItems] ([Id], [ItemNumber], [Quantity], [added_date], [JobDataId], [Location], [EntryType], [Unit_Contractor], [Subcontractorid]) VALUES (2078, 1039, 100, CAST(0x603B0B00 AS Date), 2043, N'la', NULL, NULL, NULL)
INSERT [dbo].[DailyItems] ([Id], [ItemNumber], [Quantity], [added_date], [JobDataId], [Location], [EntryType], [Unit_Contractor], [Subcontractorid]) VALUES (2079, 1039, 200, CAST(0x613B0B00 AS Date), 2044, N'dfd', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[DailyItems] OFF
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (26, 14, N'roof to be installed', N'NF', 12, 222, 123, NULL, NULL, NULL)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (27, 14, N'abhilash', N'NF', 33, 333, 124, NULL, NULL, NULL)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (28, 15, N'assadasda', N'sd', 22, 22, 123, NULL, NULL, NULL)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (1031, 1016, N'dsdsd', N'22', 22, 22, 111, NULL, NULL, NULL)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (1032, 1018, N'abhilash testing', N'22', 2, 300, 121, NULL, NULL, NULL)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (1033, 1018, N'abhilash testing', N'22', 2, 300, 121, NULL, NULL, NULL)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (1034, 1019, N'abhilastetesting', N'22', 2, 333, 122, NULL, NULL, NULL)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (1035, 1020, N'abhilsh', N'nest', 22, 12, 122, NULL, NULL, NULL)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (1036, 1020, N'abhilash2', N'nest', 22, 12, 123, NULL, NULL, NULL)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (1038, 16, N'dsdasd', N'asdsa', 22, 23232, 123, 233, 1, 21)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (1039, 1019, N'abhilash', N'nest', 23, 300, 132, NULL, NULL, NULL)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (1040, 1020, N'dfdsf', N'aasdsad', 23, 233, 123, 23, 1, 23)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (1041, 1019, N'cement', N'Nest', 22, 2000, 1234, 500, 1, 10)
INSERT [dbo].[Item] ([ID], [JobID], [Description], [UnitType], [UnitPrice], [InitialQuantity], [ItemNumber], [SubContractorQuantity], [SubContractorId], [SubUnit_price]) VALUES (3041, 1020, N'bhulisah', N'22', 25, 2, 121, 12, 1002, 22)
SET IDENTITY_INSERT [dbo].[Item] OFF
SET IDENTITY_INSERT [dbo].[Job] ON 

INSERT [dbo].[Job] ([ID], [ContractorID], [Name], [Address], [City], [State], [Zip], [Phone], [Fax], [Email], [Active], [Created_Date], [Modified_date]) VALUES (14, 3, N'construction site maangement in India', N'vpo-patta teh bhoranj distt hamirpur', N'hamirpur', N'himachal pradesh', N'176041', N'09915045891', N'09915045891', N'as200261@gmail.com', 0, CAST(0x0000A5EF012823EE AS DateTime), CAST(0x0000A5EF012823EE AS DateTime))
INSERT [dbo].[Job] ([ID], [ContractorID], [Name], [Address], [City], [State], [Zip], [Phone], [Fax], [Email], [Active], [Created_Date], [Modified_date]) VALUES (15, 3, N'strret light mechanish', N'#1178,3b2,MOhali', N'Mohali', N'Punjab', N'160055', N'09915045891', N'09915045891', N'as200261@gmail.com', 1, CAST(0x0000A5EF0128F234 AS DateTime), CAST(0x0000A5EF0128F234 AS DateTime))
INSERT [dbo].[Job] ([ID], [ContractorID], [Name], [Address], [City], [State], [Zip], [Phone], [Fax], [Email], [Active], [Created_Date], [Modified_date]) VALUES (16, 3, N'Abhilash Sharma', N'vpo-patta teh bhoranj distt hamirpur', N'hamirpur', N'himachal pradesh', N'176041', N'09915045891', N'09915045891', N'as200261@gmail.com', 0, CAST(0x0000A60501457C07 AS DateTime), CAST(0x0000A60501457C07 AS DateTime))
INSERT [dbo].[Job] ([ID], [ContractorID], [Name], [Address], [City], [State], [Zip], [Phone], [Fax], [Email], [Active], [Created_Date], [Modified_date]) VALUES (1016, 6, N'asdasdas', N'dasdas', N'hamirpur', N'hi', N'176041', N'+919915045891', N'+919915045891', N'as200261@gmail.com', 1, CAST(0x0000A5F7016B85FD AS DateTime), CAST(0x0000A5F7016B85FD AS DateTime))
INSERT [dbo].[Job] ([ID], [ContractorID], [Name], [Address], [City], [State], [Zip], [Phone], [Fax], [Email], [Active], [Created_Date], [Modified_date]) VALUES (1017, 6, N'qwq', N'ds', N'dsdsd', N'himachal pradesh', N'160055', N'+919915045891', N'+919915045891', N'as200261@gmail.com', 1, CAST(0x0000A5F7016C306E AS DateTime), CAST(0x0000A5F7016C306E AS DateTime))
INSERT [dbo].[Job] ([ID], [ContractorID], [Name], [Address], [City], [State], [Zip], [Phone], [Fax], [Email], [Active], [Created_Date], [Modified_date]) VALUES (1018, 3, N'trver job for item', N'trever job for item', N'trever job for item', N'trever job for item', N'12121', N'121212121212', N'1212121', N'trever@gmail.com', 1, CAST(0x0000A5F901168039 AS DateTime), CAST(0x0000A5F901168039 AS DateTime))
INSERT [dbo].[Job] ([ID], [ContractorID], [Name], [Address], [City], [State], [Zip], [Phone], [Fax], [Email], [Active], [Created_Date], [Modified_date]) VALUES (1019, 3, N'abhilashtrever', N'vpo-patta teh bhoranj distt ha', N'hamirpur', N'hi', N'176041', N'+919915045891', N'+919915045891', N'as200261@gmail.com', 1, CAST(0x0000A5F9011703D0 AS DateTime), CAST(0x0000A5F9011703D0 AS DateTime))
INSERT [dbo].[Job] ([ID], [ContractorID], [Name], [Address], [City], [State], [Zip], [Phone], [Fax], [Email], [Active], [Created_Date], [Modified_date]) VALUES (1020, 3, N'testing quantity strenght', N'abhilash', N'hamirpur', N'himachal pradesh', N'176041', N'09915045891', N'fsdfdsf', N'as200261@gmail.com', 1, CAST(0x0000A5FD013F0419 AS DateTime), CAST(0x0000A5FD013F0419 AS DateTime))
INSERT [dbo].[Job] ([ID], [ContractorID], [Name], [Address], [City], [State], [Zip], [Phone], [Fax], [Email], [Active], [Created_Date], [Modified_date]) VALUES (1021, 3, N'sdfsdf', N'ssdfsd', N'fsdfdsf', N'dssdfdf', N'sfsdfdsf', N'dsfds', N'fdsfdsfds', N'as200261@gmail.com', 1, CAST(0x0000A60501492BF6 AS DateTime), CAST(0x0000A60501492BF6 AS DateTime))
SET IDENTITY_INSERT [dbo].[Job] OFF
SET IDENTITY_INSERT [dbo].[JobData] ON 

INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2020, 15, CAST(0x603B0B00 AS Date), N'asd', 2, N'asds', N'2', N'asdsad', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2025, 16, CAST(0x583B0B00 AS Date), N'dfgf', NULL, N'fdgdfg', N'fdgdfg', N'dfgfg', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2026, 16, CAST(0x583B0B00 AS Date), N'dfd', NULL, N'dfdf', N'dfdf', N'dfsfd', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2027, 16, CAST(0x583B0B00 AS Date), N'dfsd', 23, N'sdfds', N'3', N'sdfdsf', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2028, 16, CAST(0x583B0B00 AS Date), N'df', 23, N'sdfsdf', N'3', N'sdfdf', 3, N'Ad')
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2029, 1020, CAST(0x583B0B00 AS Date), N'sunny', 12, N'9:30 to 4:30', N'1sdfsdf', NULL, 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2030, 1020, CAST(0x583B0B00 AS Date), N'sunny', NULL, N'9:30 to 4:30', N'2', N'sdfds', 3, N'Ad')
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2031, 1020, CAST(0x583B0B00 AS Date), N'asd', NULL, N'asd', N'asdsad', N'asdasd', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2032, 16, CAST(0x5D3B0B00 AS Date), N'cxcx', NULL, N'cxcx', N'cxcc', N'xcxc', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2033, 16, CAST(0x5D3B0B00 AS Date), N'sdfdsf', 22, N'dffdsf', N'3', N'sdfsdfsdf', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2034, 16, CAST(0x5D3B0B00 AS Date), N'sdf', 22, N'sdf', N'3', N'dfgfg', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2035, 16, CAST(0x5D3B0B00 AS Date), N'hghghg', 23, N'dddd', N'3', N'fdfdgf', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2036, 16, CAST(0x5D3B0B00 AS Date), N'ghhghg', 23, N'hghghggh', N'1', N'fghfhf', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2037, 16, CAST(0x5D3B0B00 AS Date), N'sdf', 22, N'asdasd', N'2', N'asdasd', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2039, 16, CAST(0x5F3B0B00 AS Date), N'dsf', 22, N'dfsfdsf', N'2', N'sdfdsf', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2040, 1016, CAST(0x5F3B0B00 AS Date), N'sdfd', 2, N'sdfd', N'sdfds', N'sdfdsf', 6, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2041, 1019, CAST(0x603B0B00 AS Date), N'fdfd', 3333, N'sdfsd', N'32', N'dfdf', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2042, 14, CAST(0x603B0B00 AS Date), N'adasdasd', 23232, N'dsfsdf', N'2', N'dsfsfd', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2043, 1019, CAST(0x603B0B00 AS Date), N'sunny', 32, N'9:30 to 7:30', N'1', N'cvcvcvcvcv', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (2044, 1019, CAST(0x613B0B00 AS Date), N'sunny', 33, N'hhh', N'1', N'sddsf', 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (3043, 1020, CAST(0x3B3C0B00 AS Date), N'sunny', 12, N'9:30 to 4:30', N'1sdfsdf', NULL, 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (3044, 1020, CAST(0x3B3C0B00 AS Date), N'sunny', 12, N'9:30 to 4:30', N'1sdfsdf', NULL, 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (3045, 1020, CAST(0x3B3C0B00 AS Date), N'sunny', 12, N'9:30 to 4:30', N'1sdfsdf', NULL, 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (3046, 1020, CAST(0x3B3C0B00 AS Date), N'sunny', 12, N'9:30 to 4:30', N'1sdfsdf', NULL, 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (3047, 1020, CAST(0x3B3C0B00 AS Date), N'sunny', 12, N'9:30 to 4:30', N'1sdfsdf', NULL, 3, NULL)
INSERT [dbo].[JobData] ([ID], [JobID], [Date], [Weather], [Temperature], [Shift], [Estimate], [Notes], [ContractorId], [EntryType]) VALUES (3048, 1020, CAST(0x3B3C0B00 AS Date), N'sunny', 12, N'9:30 to 4:30', N'1sdfsdf', NULL, 3, NULL)
SET IDENTITY_INSERT [dbo].[JobData] OFF
SET IDENTITY_INSERT [dbo].[payment] ON 

INSERT [dbo].[payment] ([id], [Clientname], [FromUser], [createddate], [units], [UnitPrice], [Jobid], [Itemid]) VALUES (1, N'abhilash', 8, CAST(0x5F3B0B00 AS Date), 150, 22, 16, 1038)
INSERT [dbo].[payment] ([id], [Clientname], [FromUser], [createddate], [units], [UnitPrice], [Jobid], [Itemid]) VALUES (3, N'asdsadsad', 8, CAST(0x5F3B0B00 AS Date), 20000, 22, 16, 1038)
INSERT [dbo].[payment] ([id], [Clientname], [FromUser], [createddate], [units], [UnitPrice], [Jobid], [Itemid]) VALUES (4, N'abhilash', 8, CAST(0x603B0B00 AS Date), 200, 12, 14, 26)
INSERT [dbo].[payment] ([id], [Clientname], [FromUser], [createddate], [units], [UnitPrice], [Jobid], [Itemid]) VALUES (9, N'ddfdf', 8, CAST(0x603B0B00 AS Date), 22, 22, 1020, 1035)
INSERT [dbo].[payment] ([id], [Clientname], [FromUser], [createddate], [units], [UnitPrice], [Jobid], [Itemid]) VALUES (10, N'adsad', 8, CAST(0x603B0B00 AS Date), 233, 22, 1020, 1035)
INSERT [dbo].[payment] ([id], [Clientname], [FromUser], [createddate], [units], [UnitPrice], [Jobid], [Itemid]) VALUES (14, N'dfgdfg', 15, CAST(0x613B0B00 AS Date), 123, 23, 1019, 1039)
INSERT [dbo].[payment] ([id], [Clientname], [FromUser], [createddate], [units], [UnitPrice], [Jobid], [Itemid]) VALUES (15, N'hgfjghfhfgh', 15, CAST(0x613B0B00 AS Date), 500, 22, 1019, 1041)
SET IDENTITY_INSERT [dbo].[payment] OFF
SET IDENTITY_INSERT [dbo].[tbl_sub_contractor] ON 

INSERT [dbo].[tbl_sub_contractor] ([id], [Name], [Contact], [Email], [Address], [Phone], [Fax], [Contractorid], [Added]) VALUES (1, N'abhilasg1', N'abhil', N'as200261@gmail.com', N'as200261@gmail.com', N'121212121', N'9915045891', 3, CAST(0x5F3B0B00 AS Date))
INSERT [dbo].[tbl_sub_contractor] ([id], [Name], [Contact], [Email], [Address], [Phone], [Fax], [Contractorid], [Added]) VALUES (2, N'trever', N'trver', N'trever@gmail.com', N'trver', N'tvere', N'121212', 3, CAST(0x603B0B00 AS Date))
INSERT [dbo].[tbl_sub_contractor] ([id], [Name], [Contact], [Email], [Address], [Phone], [Fax], [Contractorid], [Added]) VALUES (1002, N'Abhilash Sharma', N'998989808', N'mnmnmn@gmail.com', N'vpo-patta teh bhoranj distt hamirpur', N'9915045891', N'9915045891', 0, CAST(0x3B3C0B00 AS Date))
SET IDENTITY_INSERT [dbo].[tbl_sub_contractor] OFF
SET IDENTITY_INSERT [dbo].[tblContractor] ON 

INSERT [dbo].[tblContractor] ([Id], [FirstName], [LastName], [Email], [Phone], [Address], [City], [State], [Zip], [Notes], [CreatedDate], [ModifiedDate], [Isactive]) VALUES (3, N'abhilash', N'sharma', N'as200261@gmail.com', N'+919915045891', N'vpo-patta teh bhoranj distt ha', N'hamirpur', N'hi', N'3232323', N'contractor', CAST(0x0000A5EC00658F77 AS DateTime), CAST(0x0000A5EC00658FB7 AS DateTime), 1)
INSERT [dbo].[tblContractor] ([Id], [FirstName], [LastName], [Email], [Phone], [Address], [City], [State], [Zip], [Notes], [CreatedDate], [ModifiedDate], [Isactive]) VALUES (4, N'trever', N'trever', N'trever@outlook.com', N'9915045891', N'abhi', N'abhihihihi', N'adfjdhasdasd ', N'7767', N'any other', CAST(0x0000A5E900E6542B AS DateTime), CAST(0x0000A5E900E6542B AS DateTime), 0)
INSERT [dbo].[tblContractor] ([Id], [FirstName], [LastName], [Email], [Phone], [Address], [City], [State], [Zip], [Notes], [CreatedDate], [ModifiedDate], [Isactive]) VALUES (6, N'dasfadsf', N'sdfsdf', N'sdfsdf', N'sdfsdfsd', N'dfdsfsdf', N'fdsfdsds', N'fdsfsdfsdf', N'23232', N'fsdfdsfdsf', CAST(0x0000A5EC0065CF6F AS DateTime), CAST(0x0000A5EC0065CF6F AS DateTime), 1)
INSERT [dbo].[tblContractor] ([Id], [FirstName], [LastName], [Email], [Phone], [Address], [City], [State], [Zip], [Notes], [CreatedDate], [ModifiedDate], [Isactive]) VALUES (1007, N'abhilash sharma', N'sharmaaa', N'as2002612@gmail.com', N'9915045891', N'vpo-patta teh bhoranj distt ha', N'hamirpur', N'hi', N'176041', N'asdasddsdsds', CAST(0x0000A6050141E0EA AS DateTime), CAST(0x0000A6050141E0EA AS DateTime), 1)
INSERT [dbo].[tblContractor] ([Id], [FirstName], [LastName], [Email], [Phone], [Address], [City], [State], [Zip], [Notes], [CreatedDate], [ModifiedDate], [Isactive]) VALUES (1008, N'sasha', N'sasha', N'shasha@gmail.com', N'999987878', N'asdSAD', N'SDSDASD', N'ASDSAD', N'176041', N'ZXCXZC', CAST(0x0000A60501844BB8 AS DateTime), CAST(0x0000A60501844BB8 AS DateTime), 1)
INSERT [dbo].[tblContractor] ([Id], [FirstName], [LastName], [Email], [Phone], [Address], [City], [State], [Zip], [Notes], [CreatedDate], [ModifiedDate], [Isactive]) VALUES (2008, N'Abhil', N'Sharma', N'as200261@gmail.com', N'9915045891', N'vpo-patta teh bhoranj distt ha, 55, ghjgj', N'hamirpur', N'hi', N'176041', N'adasdsds', CAST(0x0000A6E00074E3D3 AS DateTime), CAST(0x0000A6E00074E3D3 AS DateTime), 1)
INSERT [dbo].[tblContractor] ([Id], [FirstName], [LastName], [Email], [Phone], [Address], [City], [State], [Zip], [Notes], [CreatedDate], [ModifiedDate], [Isactive]) VALUES (2009, N'Abhil', N'Sharma', N'as200261@gmail.com', N'9915045891', N'vpo-patta teh bhoranj distt ha, 55, ghjgj', N'hamirpur', N'hi', N'176041', N'abhilash is great', CAST(0x0000A6E000BF08BD AS DateTime), CAST(0x0000A6E000BF08BD AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[tblContractor] OFF
SET IDENTITY_INSERT [dbo].[tblDailyEquipment] ON 

INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (1, 10, 2036, 1029)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (2, 11, 2036, 1029)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (3, 9, 0, 29)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (4, 13, 0, 29)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (5, 10, 2036, 29)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (6, 10, 2037, 1029)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (7, 10, 2037, 1029)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (8, 13, 2037, 1029)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (9, 9, 2020, 28)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (10, 10, 2020, 28)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (11, 7, 2020, 28)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (12, 12, 2043, 1039)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (13, 12, 2043, 1039)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (14, 11, 2043, 1039)
INSERT [dbo].[tblDailyEquipment] ([id], [equipmentid], [jobdataid], [numberof]) VALUES (15, 12, 2043, 1039)
SET IDENTITY_INSERT [dbo].[tblDailyEquipment] OFF
SET IDENTITY_INSERT [dbo].[tblEquipment] ON 

INSERT [dbo].[tblEquipment] ([id], [Equipment_name], [COntractor_id]) VALUES (7, N'itemid', 3)
INSERT [dbo].[tblEquipment] ([id], [Equipment_name], [COntractor_id]) VALUES (8, N'name', 3)
INSERT [dbo].[tblEquipment] ([id], [Equipment_name], [COntractor_id]) VALUES (11, N'item des', 3)
INSERT [dbo].[tblEquipment] ([id], [Equipment_name], [COntractor_id]) VALUES (12, N'this name', 3)
INSERT [dbo].[tblEquipment] ([id], [Equipment_name], [COntractor_id]) VALUES (13, N'asdasd', 3)
INSERT [dbo].[tblEquipment] ([id], [Equipment_name], [COntractor_id]) VALUES (14, N'asdasds', 3)
INSERT [dbo].[tblEquipment] ([id], [Equipment_name], [COntractor_id]) VALUES (16, N'talwar', 6)
INSERT [dbo].[tblEquipment] ([id], [Equipment_name], [COntractor_id]) VALUES (17, N'fssfsdfds', 3)
INSERT [dbo].[tblEquipment] ([id], [Equipment_name], [COntractor_id]) VALUES (1017, N'rajmah', 0)
SET IDENTITY_INSERT [dbo].[tblEquipment] OFF
SET IDENTITY_INSERT [dbo].[tblworkforce] ON 

INSERT [dbo].[tblworkforce] ([id], [Workforcename], [numberof], [JobDataid]) VALUES (1, N'hgfhgfhgf', 22, 2036)
INSERT [dbo].[tblworkforce] ([id], [Workforcename], [numberof], [JobDataid]) VALUES (2, N'hghghghg', 22, 2036)
INSERT [dbo].[tblworkforce] ([id], [Workforcename], [numberof], [JobDataid]) VALUES (3, N'sdsdsd', 22, 2037)
INSERT [dbo].[tblworkforce] ([id], [Workforcename], [numberof], [JobDataid]) VALUES (4, N'sdsd', 22, 2037)
INSERT [dbo].[tblworkforce] ([id], [Workforcename], [numberof], [JobDataid]) VALUES (5, N'sdsdsdsd', 22, 2037)
INSERT [dbo].[tblworkforce] ([id], [Workforcename], [numberof], [JobDataid]) VALUES (6, N'sdsdsd', 22, 2037)
INSERT [dbo].[tblworkforce] ([id], [Workforcename], [numberof], [JobDataid]) VALUES (7, N'dfdfdf', 33, 2020)
INSERT [dbo].[tblworkforce] ([id], [Workforcename], [numberof], [JobDataid]) VALUES (8, N'supervisor', 2, 2043)
SET IDENTITY_INSERT [dbo].[tblworkforce] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/19/2016 2:39:04 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12/19/2016 2:39:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12/19/2016 2:39:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 12/19/2016 2:39:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12/19/2016 2:39:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/19/2016 2:39:04 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Change_Order] ADD  CONSTRAINT [DF_Change_Order_new_quantity]  DEFAULT ((0)) FOR [new_quantity]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_tblContractor] FOREIGN KEY([ContractorId])
REFERENCES [dbo].[tblContractor] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_tblContractor]
GO
ALTER TABLE [dbo].[Change_Order]  WITH CHECK ADD  CONSTRAINT [FK_Change_Order_Item] FOREIGN KEY([itemid])
REFERENCES [dbo].[Item] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Change_Order] CHECK CONSTRAINT [FK_Change_Order_Item]
GO
ALTER TABLE [dbo].[DailyItems]  WITH CHECK ADD  CONSTRAINT [FK_DailyItems_Item] FOREIGN KEY([ItemNumber])
REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[DailyItems] CHECK CONSTRAINT [FK_DailyItems_Item]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Job1] FOREIGN KEY([JobID])
REFERENCES [dbo].[Job] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Job1]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Job] FOREIGN KEY([ContractorID])
REFERENCES [dbo].[tblContractor] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_Job]
GO
USE [master]
GO
ALTER DATABASE [Construction_DB] SET  READ_WRITE 
GO
