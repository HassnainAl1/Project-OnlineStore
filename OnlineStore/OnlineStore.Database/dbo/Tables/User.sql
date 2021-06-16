CREATE TABLE [dbo].[User] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50) NOT NULL,
    [LastName]    NVARCHAR (50) NOT NULL,
    [Email]       NVARCHAR (50) NOT NULL,
    [Country]     NVARCHAR (50) NOT NULL,
    [PhoneNumber] NVARCHAR (50) NOT NULL,
    [Password]    NVARCHAR (50) NOT NULL,
    [CreatedAt]   DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

