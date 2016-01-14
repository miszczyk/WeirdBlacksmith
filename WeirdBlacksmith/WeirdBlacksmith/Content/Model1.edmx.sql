
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/14/2016 01:25:09
-- Generated from EDMX file: D:\NetProjects\WeirdBlacksmith\WeirdBlacksmith\Content\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-WeirdBlacksmith-20160111082629];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AspNetUsersTitleModels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TitleModelsSet] DROP CONSTRAINT [FK_AspNetUsersTitleModels];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[TitleModelsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TitleModelsSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'TitleModelsSet'
CREATE TABLE [dbo].[TitleModelsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OwnedBy] nvarchar(max)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [CurrentUserRole] nvarchar(max)  NOT NULL,
    [WeaponsCount] int  NOT NULL,
    [AspNetUsersId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'WeaponsModelsSet'
CREATE TABLE [dbo].[WeaponsModelsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rarity] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [MinDamage] int  NOT NULL,
    [MaxDamage] int  NOT NULL,
    [ImageUrl] nvarchar(max)  NOT NULL,
    [Added] nvarchar(max)  NOT NULL,
    [TitleModelsId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TitleModelsSet'
ALTER TABLE [dbo].[TitleModelsSet]
ADD CONSTRAINT [PK_TitleModelsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WeaponsModelsSet'
ALTER TABLE [dbo].[WeaponsModelsSet]
ADD CONSTRAINT [PK_WeaponsModelsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AspNetUsersId] in table 'TitleModelsSet'
ALTER TABLE [dbo].[TitleModelsSet]
ADD CONSTRAINT [FK_AspNetUsersTitleModels]
    FOREIGN KEY ([AspNetUsersId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUsersTitleModels'
CREATE INDEX [IX_FK_AspNetUsersTitleModels]
ON [dbo].[TitleModelsSet]
    ([AspNetUsersId]);
GO

-- Creating foreign key on [TitleModelsId] in table 'WeaponsModelsSet'
ALTER TABLE [dbo].[WeaponsModelsSet]
ADD CONSTRAINT [FK_TitleModelsWeaponsModels]
    FOREIGN KEY ([TitleModelsId])
    REFERENCES [dbo].[TitleModelsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TitleModelsWeaponsModels'
CREATE INDEX [IX_FK_TitleModelsWeaponsModels]
ON [dbo].[WeaponsModelsSet]
    ([TitleModelsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------