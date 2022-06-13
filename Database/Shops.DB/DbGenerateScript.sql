USE [master]
GO
/****** Object:  Database [ShopsDb]    Script Date: 13.06.2022 11:23:49 ******/
CREATE DATABASE [ShopsDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopsDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShopsDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopsDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ShopsDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShopsDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopsDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopsDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopsDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopsDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopsDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopsDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopsDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopsDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopsDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopsDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopsDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopsDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopsDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopsDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopsDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopsDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopsDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopsDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopsDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopsDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopsDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopsDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ShopsDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopsDb] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopsDb] SET  MULTI_USER 
GO
ALTER DATABASE [ShopsDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopsDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopsDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopsDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopsDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopsDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopsDb', N'ON'
GO
ALTER DATABASE [ShopsDb] SET QUERY_STORE = OFF
GO
USE [ShopsDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13.06.2022 11:23:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrentAccounts]    Script Date: 13.06.2022 11:23:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrentAccounts](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[CurrentAccountTypeId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsAffiliate] [bit] NOT NULL,
 CONSTRAINT [PK_CurrentAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrentAccountTypes]    Script Date: 13.06.2022 11:23:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrentAccountTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[CurrentAccountTypeDesc] [nvarchar](max) NULL,
 CONSTRAINT [PK_CurrentAccountTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 13.06.2022 11:23:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discounts](
	[Id] [uniqueidentifier] NOT NULL,
	[DiscountCode] [nvarchar](max) NULL,
	[DiscountName] [nvarchar](max) NULL,
	[Percentage] [float] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Discounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 13.06.2022 11:23:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[Id] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[IsGrocery] [bit] NOT NULL,
	[CurrentAccountId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220610121337_InvoiceAddColumnGrocery', N'6.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220611123928_CurrenAccountAddColumnIsAffiliate', N'6.0.5')
GO
INSERT [dbo].[CurrentAccounts] ([Id], [FirstName], [LastName], [CurrentAccountTypeId], [CreatedDate], [IsAffiliate]) VALUES (N'bb6cdcf6-c48d-4c5b-5c48-08da4b0c7357', N'Bayram', N'EREN', N'88ca23a6-2be1-48b5-99db-01257597abd8', CAST(N'2022-06-10T21:10:08.3042959' AS DateTime2), 0)
INSERT [dbo].[CurrentAccounts] ([Id], [FirstName], [LastName], [CurrentAccountTypeId], [CreatedDate], [IsAffiliate]) VALUES (N'6573835f-e5a6-421b-5c49-08da4b0c7357', N'Yusuf', N'KARA', N'a58e3c0f-25ac-42e8-a107-1c35f87f4460', CAST(N'2022-06-10T21:11:29.7685401' AS DateTime2), 1)
INSERT [dbo].[CurrentAccounts] ([Id], [FirstName], [LastName], [CurrentAccountTypeId], [CreatedDate], [IsAffiliate]) VALUES (N'4446d44e-0dbc-46b0-2de7-08da4bb19d76', N'Hüseyin', N'Çimen', N'a58e3c0f-25ac-42e8-a107-1c35f87f4460', CAST(N'2020-06-11T16:52:26.7661200' AS DateTime2), 0)
INSERT [dbo].[CurrentAccounts] ([Id], [FirstName], [LastName], [CurrentAccountTypeId], [CreatedDate], [IsAffiliate]) VALUES (N'11850938-a689-41a2-eddf-08da4bcce35a', N'Erdinç', N'SÜZEL', N'a58e3c0f-25ac-42e8-a107-1c35f87f4460', CAST(N'2020-06-11T16:52:26.7661200' AS DateTime2), 1)
GO
INSERT [dbo].[CurrentAccountTypes] ([Id], [CurrentAccountTypeDesc]) VALUES (N'88ca23a6-2be1-48b5-99db-01257597abd8', N'Person')
INSERT [dbo].[CurrentAccountTypes] ([Id], [CurrentAccountTypeDesc]) VALUES (N'a58e3c0f-25ac-42e8-a107-1c35f87f4460', N'Customer')
GO
INSERT [dbo].[Discounts] ([Id], [DiscountCode], [DiscountName], [Percentage], [CreatedDate]) VALUES (N'7fce04f5-f5df-4ede-a41e-1aba0003b41d', N'003', N'Old Customer Discount', 5, CAST(N'2022-06-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Discounts] ([Id], [DiscountCode], [DiscountName], [Percentage], [CreatedDate]) VALUES (N'dbab0fb3-375b-45bd-bacb-310c4870d14c', N'002', N'Employee Discount', 30, CAST(N'2022-02-22T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Discounts] ([Id], [DiscountCode], [DiscountName], [Percentage], [CreatedDate]) VALUES (N'5f53c56b-af28-4b35-8c55-ac80868e9c60', N'004', N'Percent Per $100 Bill Discount', 5, CAST(N'2022-06-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Discounts] ([Id], [DiscountCode], [DiscountName], [Percentage], [CreatedDate]) VALUES (N'2105662d-ceea-494e-adfa-d255d4c033df', N'001', N'Affliate Discount', 10, CAST(N'2002-02-22T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Invoices] ([Id], [Amount], [IsGrocery], [CurrentAccountId], [CreatedDate]) VALUES (N'18f81bc0-a202-4510-079c-08da4bc9dfb1', CAST(200.00 AS Decimal(18, 2)), 1, N'bb6cdcf6-c48d-4c5b-5c48-08da4b0c7357', CAST(N'2022-06-11T19:46:04.0358114' AS DateTime2))
INSERT [dbo].[Invoices] ([Id], [Amount], [IsGrocery], [CurrentAccountId], [CreatedDate]) VALUES (N'b4e5e4c8-7282-45c8-0dbd-08da4bcbe03e', CAST(250.00 AS Decimal(18, 2)), 0, N'6573835f-e5a6-421b-5c49-08da4b0c7357', CAST(N'2022-06-11T20:00:23.9482340' AS DateTime2))
INSERT [dbo].[Invoices] ([Id], [Amount], [IsGrocery], [CurrentAccountId], [CreatedDate]) VALUES (N'013b35bc-ff48-4740-8f95-08da4bcc84a1', CAST(300.00 AS Decimal(18, 2)), 1, N'4446d44e-0dbc-46b0-2de7-08da4bb19d76', CAST(N'2022-06-11T20:04:59.7442603' AS DateTime2))
INSERT [dbo].[Invoices] ([Id], [Amount], [IsGrocery], [CurrentAccountId], [CreatedDate]) VALUES (N'cb9562bc-f55c-4292-8f96-08da4bcc84a1', CAST(250.00 AS Decimal(18, 2)), 1, N'11850938-a689-41a2-eddf-08da4bcce35a', CAST(N'2022-06-11T20:08:29.5479822' AS DateTime2))
GO
/****** Object:  Index [IX_CurrentAccounts_CurrentAccountTypeId]    Script Date: 13.06.2022 11:23:49 ******/
CREATE NONCLUSTERED INDEX [IX_CurrentAccounts_CurrentAccountTypeId] ON [dbo].[CurrentAccounts]
(
	[CurrentAccountTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoices_CurrentAccountId]    Script Date: 13.06.2022 11:23:49 ******/
CREATE NONCLUSTERED INDEX [IX_Invoices_CurrentAccountId] ON [dbo].[Invoices]
(
	[CurrentAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CurrentAccounts] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsAffiliate]
GO
ALTER TABLE [dbo].[CurrentAccountTypes] ADD  CONSTRAINT [DF_CurrentAccountTypes_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Discounts] ADD  CONSTRAINT [DF_Discounts_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[CurrentAccounts]  WITH CHECK ADD  CONSTRAINT [FK_CurrentAccounts_CurrentAccountTypes_CurrentAccountTypeId] FOREIGN KEY([CurrentAccountTypeId])
REFERENCES [dbo].[CurrentAccountTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CurrentAccounts] CHECK CONSTRAINT [FK_CurrentAccounts_CurrentAccountTypes_CurrentAccountTypeId]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_CurrentAccounts_CurrentAccountId] FOREIGN KEY([CurrentAccountId])
REFERENCES [dbo].[CurrentAccounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_CurrentAccounts_CurrentAccountId]
GO
USE [master]
GO
ALTER DATABASE [ShopsDb] SET  READ_WRITE 
GO
