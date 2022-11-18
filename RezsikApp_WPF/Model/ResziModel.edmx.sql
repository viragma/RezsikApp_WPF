
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/16/2022 13:34:45
-- Generated from EDMX file: C:\Users\virag\source\repos\RezsikApp_WPF\RezsikApp_WPF\Model\ResziModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\VIRAG\SOURCE\REPOS\REZSIKAPP_WPF\REZSIKAPP_WPF\BIN\DEBUG\REZSIKDB.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Felhasznalok'
CREATE TABLE [dbo].[Felhasznalok] (
    [Fid] int IDENTITY(1,1) NOT NULL,
    [V_Nev] nvarchar(max)  NOT NULL,
    [K_Nev] nvarchar(max)  NOT NULL,
    [Felh_Nev] nvarchar(max)  NOT NULL,
    [Jelszo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Rezsik'
CREATE TABLE [dbo].[Rezsik] (
    [Rid] int IDENTITY(1,1) NOT NULL,
    [Oraallas] float  NOT NULL,
    [Fizetendo] float  NOT NULL,
    [Datum] datetime  NOT NULL,
    [FelhasznaloFid] int  NOT NULL,
    [Tipus_Tid] int  NOT NULL
);
GO

-- Creating table 'Tipusok'
CREATE TABLE [dbo].[Tipusok] (
    [Tid] int IDENTITY(1,1) NOT NULL,
    [T_Nev] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Fid] in table 'Felhasznalok'
ALTER TABLE [dbo].[Felhasznalok]
ADD CONSTRAINT [PK_Felhasznalok]
    PRIMARY KEY CLUSTERED ([Fid] ASC);
GO

-- Creating primary key on [Rid] in table 'Rezsik'
ALTER TABLE [dbo].[Rezsik]
ADD CONSTRAINT [PK_Rezsik]
    PRIMARY KEY CLUSTERED ([Rid] ASC);
GO

-- Creating primary key on [Tid] in table 'Tipusok'
ALTER TABLE [dbo].[Tipusok]
ADD CONSTRAINT [PK_Tipusok]
    PRIMARY KEY CLUSTERED ([Tid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FelhasznaloFid] in table 'Rezsik'
ALTER TABLE [dbo].[Rezsik]
ADD CONSTRAINT [FK_FelhasznaloRezsi]
    FOREIGN KEY ([FelhasznaloFid])
    REFERENCES [dbo].[Felhasznalok]
        ([Fid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FelhasznaloRezsi'
CREATE INDEX [IX_FK_FelhasznaloRezsi]
ON [dbo].[Rezsik]
    ([FelhasznaloFid]);
GO

-- Creating foreign key on [Tipus_Tid] in table 'Rezsik'
ALTER TABLE [dbo].[Rezsik]
ADD CONSTRAINT [FK_RezsiTipus]
    FOREIGN KEY ([Tipus_Tid])
    REFERENCES [dbo].[Tipusok]
        ([Tid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RezsiTipus'
CREATE INDEX [IX_FK_RezsiTipus]
ON [dbo].[Rezsik]
    ([Tipus_Tid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------