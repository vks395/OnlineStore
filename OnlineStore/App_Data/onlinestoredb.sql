USE [master]
GO
/****** Object:  Database [OnlineStoreDb]    Script Date: 01-07-2025 14:57:27 ******/
CREATE DATABASE [OnlineStoreDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnlineStoreDb', FILENAME = N'C:\Users\Vicky Kumar Sharma\OnlineStoreDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OnlineStoreDb_log', FILENAME = N'C:\Users\Vicky Kumar Sharma\OnlineStoreDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OnlineStoreDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineStoreDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineStoreDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineStoreDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineStoreDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OnlineStoreDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineStoreDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OnlineStoreDb] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineStoreDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineStoreDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineStoreDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineStoreDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnlineStoreDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OnlineStoreDb] SET QUERY_STORE = OFF
GO
USE [OnlineStoreDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [OnlineStoreDb]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 01-07-2025 14:57:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](60) NULL,
	[Description] [nvarchar](200) NULL,
	[Price] [decimal](18, 2) NULL,
	[ImageName] [nvarchar](50) NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 01-07-2025 14:57:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 01-07-2025 14:57:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01-07-2025 14:57:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](60) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [ImageName], [ImagePath]) VALUES (3, N'Laptop', N'Lenvo IdeaPad 7i', CAST(90000.00 AS Decimal(18, 2)), N'download (1).jpg', N'C:\Users\Vicky Kumar Sharma\source\repos\OnlineStore\OnlineStore\write\UploadedImages\images\2a41ee62-087b-436f-99d5-eeb87c15679d\download (1).jpg')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [ImageName], [ImagePath]) VALUES (1005, N'Lenvo Laptop', N'Idea pad 5', CAST(500000.00 AS Decimal(18, 2)), N'download (2).jpg', N'C:\Users\Vicky Kumar Sharma\source\repos\OnlineStore\OnlineStore\write\UploadedImages\images\a616893e-c7e3-4993-9a01-98f0251c9867\download (2).jpg')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [ImageName], [ImagePath]) VALUES (1006, N'Iphone 14', N'most selling phone', CAST(1200000.00 AS Decimal(18, 2)), N'Screenshot 2023-04-27 110551.png', N'C:\Users\Vicky Kumar Sharma\source\repos\OnlineStore\OnlineStore\write\UploadedImages\images\1e88eb26-467c-4637-bc76-4b7d42893089\Screenshot 2023-04-27 110551.png')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [ImageName], [ImagePath]) VALUES (1007, N'Apple Laptop', N'features', CAST(200000.00 AS Decimal(18, 2)), N'Screenshot_20230223_064451.png', N'C:\Users\Vicky Kumar Sharma\source\repos\OnlineStore\OnlineStore\write\UploadedImages\images\e6958d11-5a18-4e3d-9e05-9dfbf6325306\Screenshot_20230223_064451.png')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [ImageName], [ImagePath]) VALUES (1008, N'A1', N'features 444', CAST(85200.00 AS Decimal(18, 2)), N'Screenshot 2023-03-14 195343.png', N'C:\Users\Vicky Kumar Sharma\source\repos\OnlineStore\OnlineStore\write\UploadedImages\images\d6c74d8e-6b44-48d6-a918-3fa7faa48107\Screenshot 2023-03-14 195343.png')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [ImageName], [ImagePath]) VALUES (1009, N'B1', N'most selling phone B1', CAST(89652.00 AS Decimal(18, 2)), N'Screenshot 2023-03-01 195911.png', N'C:\Users\Vicky Kumar Sharma\source\repos\OnlineStore\OnlineStore\write\UploadedImages\images\1c01601b-b935-4260-bd61-5d20baa013e9\Screenshot 2023-03-01 195911.png')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [ImageName], [ImagePath]) VALUES (1014, N'LOU', N'most selling phone', CAST(10.00 AS Decimal(18, 2)), N'IMG_20190129_221754.jpg', N'C:\Users\Vicky Kumar Sharma\source\repos\OnlineStore\OnlineStore\write\UploadedImages\images\0c1e5ad1-5ca7-4c0a-bc45-f9649c8d5a4a\IMG_20190129_221754.jpg')
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Price], [ImageName], [ImagePath]) VALUES (1018, N'Mobilewww', N'Realmww', CAST(200.00 AS Decimal(18, 2)), N'download.jpg', N'C:\Users\Vicky Kumar Sharma\source\repos\OnlineStore\OnlineStore\write\UploadedImages\images\13f49dc9-1bf7-4ed0-bf80-d436191620b6\download.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'customers')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'administrators')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'sellers')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (1, N'admin', 2)
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (4, N'seller', 3)
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (6, N'customer', 1)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [RoleId], [CreateDate]) VALUES (N'admin', N'admin', N'1234', 2, NULL)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [RoleId], [CreateDate]) VALUES (N'customer', N'customer', N'1234', 1, NULL)
INSERT [dbo].[Users] ([UserId], [UserName], [Password], [RoleId], [CreateDate]) VALUES (N'seller', N'seller', N'1234', 3, NULL)
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 01-07-2025 14:57:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllUsers] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	  SELECT u.[UserId]
      ,u.[UserName]
      ,u.[Password]
      ,ur.[RoleId],
	  (select RoleName from Roles where RoleId=ur.RoleId) as RoleName
	  ,[CreateDate]
FROM Users u
INNER JOIN UserRoles ur
ON u.UserId=ur.UserId
END
GO
USE [master]
GO
ALTER DATABASE [OnlineStoreDb] SET  READ_WRITE 
GO
