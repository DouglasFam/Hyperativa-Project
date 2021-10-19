IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [HPRTV_Cards] (
    [Id] uniqueidentifier NOT NULL,
    [Identifier] varchar(2) NOT NULL,
    [Lote] varchar(8) NOT NULL,
    [CardNumber] varchar(20) NOT NULL,
    CONSTRAINT [PK_HPRTV_Cards] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [HPRTV_Users] (
    [Id] uniqueidentifier NOT NULL,
    [Username] varchar(200) NOT NULL,
    [Password] varchar(200) NOT NULL,
    [Access] varchar(10) NOT NULL,
    CONSTRAINT [PK_HPRTV_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211018103514_initial', N'5.0.11');
GO

COMMIT;
GO

