USE [master]
GO
/****** Object:  Database [SearchesAndResults]    Script Date: 06/11/2019 12:56:55 ******/
CREATE DATABASE [SearchesAndResults]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Serches&Results', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Serches&Results.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Serches&Results_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Serches&Results_log.ldf' , SIZE = 66560KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SearchesAndResults] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SearchesAndResults].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SearchesAndResults] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SearchesAndResults] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SearchesAndResults] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SearchesAndResults] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SearchesAndResults] SET ARITHABORT OFF 
GO
ALTER DATABASE [SearchesAndResults] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SearchesAndResults] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SearchesAndResults] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SearchesAndResults] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SearchesAndResults] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SearchesAndResults] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SearchesAndResults] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SearchesAndResults] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SearchesAndResults] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SearchesAndResults] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SearchesAndResults] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SearchesAndResults] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SearchesAndResults] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SearchesAndResults] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SearchesAndResults] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SearchesAndResults] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SearchesAndResults] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SearchesAndResults] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SearchesAndResults] SET  MULTI_USER 
GO
ALTER DATABASE [SearchesAndResults] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SearchesAndResults] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SearchesAndResults] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SearchesAndResults] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SearchesAndResults] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SearchesAndResults] SET QUERY_STORE = OFF
GO
USE [SearchesAndResults]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 06/11/2019 12:56:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[ResultID] [int] IDENTITY(1,1) NOT NULL,
	[SearchID] [int] NOT NULL,
	[FullPath] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED 
(
	[ResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Searches]    Script Date: 06/11/2019 12:56:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Searches](
	[SearchID] [int] IDENTITY(1,1) NOT NULL,
	[TextToSearch] [nvarchar](256) NOT NULL,
	[FolderToSearch] [nvarchar](256) NULL,
	[SearchTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Searches] PRIMARY KEY CLUSTERED 
(
	[SearchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_Searches] FOREIGN KEY([SearchID])
REFERENCES [dbo].[Searches] ([SearchID])
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_Searches]
GO
USE [master]
GO
ALTER DATABASE [SearchesAndResults] SET  READ_WRITE 
GO
