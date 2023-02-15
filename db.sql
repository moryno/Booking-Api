USE [master]
GO

/****** Object:  Database [Booking]    Script Date: 15/02/2023 17:41:06 ******/
CREATE DATABASE [Booking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Booking', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Booking.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Booking_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Booking_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Booking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Booking] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Booking] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Booking] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Booking] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Booking] SET ARITHABORT OFF 
GO

ALTER DATABASE [Booking] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Booking] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Booking] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Booking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Booking] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Booking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Booking] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Booking] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Booking] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Booking] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Booking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Booking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Booking] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Booking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Booking] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Booking] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Booking] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Booking] SET RECOVERY FULL 
GO

ALTER DATABASE [Booking] SET  MULTI_USER 
GO

ALTER DATABASE [Booking] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Booking] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Booking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Booking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Booking] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Booking] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Booking] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Booking] SET  READ_WRITE 
GO

