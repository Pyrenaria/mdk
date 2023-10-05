USE [master]
GO
/****** Object:  Database [mdk]    Script Date: 05.10.2023 22:19:32 ******/
CREATE DATABASE [mdk]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mdk', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\mdk.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'mdk_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\mdk_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [mdk] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mdk].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mdk] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mdk] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mdk] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mdk] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mdk] SET ARITHABORT OFF 
GO
ALTER DATABASE [mdk] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mdk] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mdk] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mdk] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mdk] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mdk] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mdk] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mdk] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mdk] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mdk] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mdk] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mdk] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mdk] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mdk] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mdk] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mdk] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mdk] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mdk] SET RECOVERY FULL 
GO
ALTER DATABASE [mdk] SET  MULTI_USER 
GO
ALTER DATABASE [mdk] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mdk] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mdk] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mdk] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [mdk] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [mdk] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'mdk', N'ON'
GO
ALTER DATABASE [mdk] SET QUERY_STORE = ON
GO
ALTER DATABASE [mdk] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [mdk]
GO
/****** Object:  Table [dbo].[Измерение]    Script Date: 05.10.2023 22:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Измерение](
	[ID Единиц] [int] IDENTITY(1,1) NOT NULL,
	[Единица измерения] [varchar](20) NULL,
 CONSTRAINT [PK_Измерение] PRIMARY KEY CLUSTERED 
(
	[ID Единиц] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Категория]    Script Date: 05.10.2023 22:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Категория](
	[ID Категории] [int] IDENTITY(1,1) NOT NULL,
	[Название категории] [varchar](50) NULL,
 CONSTRAINT [PK_Категория] PRIMARY KEY CLUSTERED 
(
	[ID Категории] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Кулинария]    Script Date: 05.10.2023 22:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Кулинария](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Название Блюда] [varchar](50) NULL,
	[ID Категории] [int] NULL,
	[Рецепт] [text] NULL,
	[Вес] [int] NULL,
	[Продукты] [text] NULL,
	[Калорийность] [int] NULL,
	[Цена] [int] NULL,
	[ID Единиц] [int] NULL,
 CONSTRAINT [PK_Кулинария] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Кулинария]  WITH CHECK ADD  CONSTRAINT [FK_Кулинария_Измерение] FOREIGN KEY([ID Единиц])
REFERENCES [dbo].[Измерение] ([ID Единиц])
GO
ALTER TABLE [dbo].[Кулинария] CHECK CONSTRAINT [FK_Кулинария_Измерение]
GO
ALTER TABLE [dbo].[Кулинария]  WITH CHECK ADD  CONSTRAINT [FK_Кулинария_Категория] FOREIGN KEY([ID Категории])
REFERENCES [dbo].[Категория] ([ID Категории])
GO
ALTER TABLE [dbo].[Кулинария] CHECK CONSTRAINT [FK_Кулинария_Категория]
GO
USE [master]
GO
ALTER DATABASE [mdk] SET  READ_WRITE 
GO
