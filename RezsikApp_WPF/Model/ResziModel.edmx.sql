
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/24/2022 18:57:49
-- Generated from EDMX file: C:\Users\virag\source\repos\RezsikApp_WPF\RezsikApp_WPF\Model\ResziModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\VIRAG\SOURCE\REPOS\REZSIKAPP_WPF\REZSIKAPP_WPF\BIN\DEBUG\REZSIDB.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RezsikFelhasznalok_Rezsik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RezsikFelhasznalok] DROP CONSTRAINT [FK_RezsikFelhasznalok_Rezsik];
GO
IF OBJECT_ID(N'[dbo].[FK_RezsikFelhasznalok_Felhasznalok]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RezsikFelhasznalok] DROP CONSTRAINT [FK_RezsikFelhasznalok_Felhasznalok];
GO
IF OBJECT_ID(N'[dbo].[FK_TipusokRezsik_Tipusok]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipusokRezsik] DROP CONSTRAINT [FK_TipusokRezsik_Tipusok];
GO
IF OBJECT_ID(N'[dbo].[FK_TipusokRezsik_Rezsik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipusokRezsik] DROP CONSTRAINT [FK_TipusokRezsik_Rezsik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RezsikSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RezsikSet];
GO
IF OBJECT_ID(N'[dbo].[FelhasznalokSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FelhasznalokSet];
GO
IF OBJECT_ID(N'[dbo].[TipusokSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipusokSet];
GO
IF OBJECT_ID(N'[dbo].[RezsikFelhasznalok]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RezsikFelhasznalok];
GO
IF OBJECT_ID(N'[dbo].[TipusokRezsik]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipusokRezsik];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RezsikSet'
CREATE TABLE [dbo].[RezsikSet] (
    [Rid] int IDENTITY(1,1) NOT NULL,
    [Oraallas] float  NOT NULL,
    [Fizetendo] float  NOT NULL,
    [Datum] datetime  NOT NULL,
    [Felhasznalok_Fid] int  NOT NULL,
    [Tipusok_Tid] int  NOT NULL
);
GO

-- Creating table 'FelhasznalokSet'
CREATE TABLE [dbo].[FelhasznalokSet] (
    [Fid] int IDENTITY(1,1) NOT NULL,
    [V_Nev] nvarchar(max)  NOT NULL,
    [K_Nev] nvarchar(max)  NOT NULL,
    [Felh_Nev] nvarchar(max)  NOT NULL,
    [Jelszo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TipusokSet'
CREATE TABLE [dbo].[TipusokSet] (
    [Tid] int IDENTITY(1,1) NOT NULL,
    [Tipus_Nev] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Rid] in table 'RezsikSet'
ALTER TABLE [dbo].[RezsikSet]
ADD CONSTRAINT [PK_RezsikSet]
    PRIMARY KEY CLUSTERED ([Rid] ASC);
GO

-- Creating primary key on [Fid] in table 'FelhasznalokSet'
ALTER TABLE [dbo].[FelhasznalokSet]
ADD CONSTRAINT [PK_FelhasznalokSet]
    PRIMARY KEY CLUSTERED ([Fid] ASC);
GO

-- Creating primary key on [Tid] in table 'TipusokSet'
ALTER TABLE [dbo].[TipusokSet]
ADD CONSTRAINT [PK_TipusokSet]
    PRIMARY KEY CLUSTERED ([Tid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Felhasznalok_Fid] in table 'RezsikSet'
ALTER TABLE [dbo].[RezsikSet]
ADD CONSTRAINT [FK_RezsikFelhasznalok]
    FOREIGN KEY ([Felhasznalok_Fid])
    REFERENCES [dbo].[FelhasznalokSet]
        ([Fid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RezsikFelhasznalok'
CREATE INDEX [IX_FK_RezsikFelhasznalok]
ON [dbo].[RezsikSet]
    ([Felhasznalok_Fid]);
GO

-- Creating foreign key on [Tipusok_Tid] in table 'RezsikSet'
ALTER TABLE [dbo].[RezsikSet]
ADD CONSTRAINT [FK_TipusokRezsik]
    FOREIGN KEY ([Tipusok_Tid])
    REFERENCES [dbo].[TipusokSet]
        ([Tid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipusokRezsik'
CREATE INDEX [IX_FK_TipusokRezsik]
ON [dbo].[RezsikSet]
    ([Tipusok_Tid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------