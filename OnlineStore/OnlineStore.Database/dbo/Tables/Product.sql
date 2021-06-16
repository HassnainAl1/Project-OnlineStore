CREATE TABLE [dbo].[Product] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [PName]         NVARCHAR (50)   NOT NULL,
    [PImage]        NVARCHAR (50)   NOT NULL,
    [Description]   NVARCHAR (MAX)  NOT NULL,
    [PurchasePrice] DECIMAL (18, 2) NOT NULL,
    [SellPrice]     DECIMAL (18, 2) NOT NULL,
    [CreatedDate]   DATETIME        NOT NULL,
    CONSTRAINT [PK__Product__3214EC07CF3E1BC9] PRIMARY KEY CLUSTERED ([Id] ASC)
);

