﻿/*
Deployment script for ASPOptimizationDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ASPOptimizationDB"
:setvar DefaultFilePrefix "ASPOptimizationDB"
:setvar DefaultDataPath "C:\Users\Hammam\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Hammam\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating Table [dbo].[Branch_Product]...';


GO
CREATE TABLE [dbo].[Branch_Product] (
    [BranchID]  INT NOT NULL,
    [ProductID] INT NOT NULL
);


GO
PRINT N'Creating Table [dbo].[Branches]...';


GO
CREATE TABLE [dbo].[Branches] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (64)  NOT NULL,
    [Address]     VARCHAR (256) NOT NULL,
    [PhoneNumber] VARCHAR (11)  NOT NULL,
    [Deleted]     DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Cargoes]...';


GO
CREATE TABLE [dbo].[Cargoes] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [CourierCompany] VARCHAR (64) NOT NULL,
    [Deleted]        DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Customers]...';


GO
CREATE TABLE [dbo].[Customers] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (64)  NOT NULL,
    [Surname]     VARCHAR (64)  NOT NULL,
    [Address]     VARCHAR (256) NOT NULL,
    [PhoneNumber] VARCHAR (11)  NOT NULL,
    [Deleted]     DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Employees]...';


GO
CREATE TABLE [dbo].[Employees] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Email]    VARCHAR (64) NOT NULL,
    [Password] VARCHAR (40) NOT NULL,
    [BranchID] INT          NOT NULL,
    [Deleted]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC)
);


GO
PRINT N'Creating Table [dbo].[LoginFailures]...';


GO
CREATE TABLE [dbo].[LoginFailures] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [EmployeeEmail] VARCHAR (64) NOT NULL,
    [Time]          DATETIME     NOT NULL,
    [Password]      VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Orders]...';


GO
CREATE TABLE [dbo].[Orders] (
    [Id]      INT      IDENTITY (1, 1) NOT NULL,
    [Date]    DATETIME NOT NULL,
    [CargoID] INT      NOT NULL,
    [Deleted] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Product_Order]...';


GO
CREATE TABLE [dbo].[Product_Order] (
    [NumberOfProducts] INT NOT NULL,
    [ProductID]        INT NOT NULL,
    [CustomerID]       INT NOT NULL,
    [OrderID]          INT NOT NULL
);


GO
PRINT N'Creating Table [dbo].[Products]...';


GO
CREATE TABLE [dbo].[Products] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (64) NOT NULL,
    [Price]   INT          NOT NULL,
    [StockID] INT          NOT NULL,
    [Deleted] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Stocks]...';


GO
CREATE TABLE [dbo].[Stocks] (
    [Id]      INT      IDENTITY (1, 1) NOT NULL,
    [Amount]  INT      NOT NULL,
    [Deleted] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Branch_Product]...';


GO
ALTER TABLE [dbo].[Branch_Product]
    ADD FOREIGN KEY ([BranchID]) REFERENCES [dbo].[Branches] ([Id]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Branch_Product]...';


GO
ALTER TABLE [dbo].[Branch_Product]
    ADD FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([Id]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Employees]...';


GO
ALTER TABLE [dbo].[Employees]
    ADD FOREIGN KEY ([BranchID]) REFERENCES [dbo].[Branches] ([Id]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[LoginFailures]...';


GO
ALTER TABLE [dbo].[LoginFailures]
    ADD FOREIGN KEY ([EmployeeEmail]) REFERENCES [dbo].[Employees] ([Email]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Orders]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD FOREIGN KEY ([CargoID]) REFERENCES [dbo].[Cargoes] ([Id]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Product_Order]...';


GO
ALTER TABLE [dbo].[Product_Order]
    ADD FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([Id]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Product_Order]...';


GO
ALTER TABLE [dbo].[Product_Order]
    ADD FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([Id]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Product_Order]...';


GO
ALTER TABLE [dbo].[Product_Order]
    ADD FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([Id]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Products]...';


GO
ALTER TABLE [dbo].[Products]
    ADD FOREIGN KEY ([StockID]) REFERENCES [dbo].[Stocks] ([Id]);


GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
