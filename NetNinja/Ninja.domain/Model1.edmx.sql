
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/27/2016 14:42:24
-- Generated from EDMX file: E:\School\Avans\Blok 5\Programmeren 5\Prog5.NetNinja\netninja\NetNinja\Ninja.domain\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EquipmentNinja_Equipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentNinja] DROP CONSTRAINT [FK_EquipmentNinja_Equipment];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentNinja_Ninja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentNinja] DROP CONSTRAINT [FK_EquipmentNinja_Ninja];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[NinjaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NinjaSet];
GO
IF OBJECT_ID(N'[dbo].[EquipmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipmentSet];
GO
IF OBJECT_ID(N'[dbo].[EquipmentNinja]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipmentNinja];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'NinjaSet'
CREATE TABLE [dbo].[NinjaSet] (
    [Name] nvarchar(max)  NOT NULL,
    [Agility] int  NOT NULL,
    [Intelligence] int  NOT NULL,
    [Strength] int  NOT NULL,
    [Gold] int  NOT NULL
);
GO

-- Creating table 'EquipmentSet'
CREATE TABLE [dbo].[EquipmentSet] (
    [Name] nvarchar(max)  NOT NULL,
    [Agility] int  NOT NULL,
    [Strength] int  NOT NULL,
    [Intelligence] int  NOT NULL,
    [Gold] int  NOT NULL,
    [Category] nvarchar(max)  NOT NULL,
    [ImageURL] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EquipmentNinja'
CREATE TABLE [dbo].[EquipmentNinja] (
    [Equipment_Name] nvarchar(max)  NOT NULL,
    [Ninja_Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Name] in table 'NinjaSet'
ALTER TABLE [dbo].[NinjaSet]
ADD CONSTRAINT [PK_NinjaSet]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [Name] in table 'EquipmentSet'
ALTER TABLE [dbo].[EquipmentSet]
ADD CONSTRAINT [PK_EquipmentSet]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [Equipment_Name], [Ninja_Name] in table 'EquipmentNinja'
ALTER TABLE [dbo].[EquipmentNinja]
ADD CONSTRAINT [PK_EquipmentNinja]
    PRIMARY KEY CLUSTERED ([Equipment_Name], [Ninja_Name] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Equipment_Name] in table 'EquipmentNinja'
ALTER TABLE [dbo].[EquipmentNinja]
ADD CONSTRAINT [FK_EquipmentNinja_Equipment]
    FOREIGN KEY ([Equipment_Name])
    REFERENCES [dbo].[EquipmentSet]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Ninja_Name] in table 'EquipmentNinja'
ALTER TABLE [dbo].[EquipmentNinja]
ADD CONSTRAINT [FK_EquipmentNinja_Ninja]
    FOREIGN KEY ([Ninja_Name])
    REFERENCES [dbo].[NinjaSet]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentNinja_Ninja'
CREATE INDEX [IX_FK_EquipmentNinja_Ninja]
ON [dbo].[EquipmentNinja]
    ([Ninja_Name]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------