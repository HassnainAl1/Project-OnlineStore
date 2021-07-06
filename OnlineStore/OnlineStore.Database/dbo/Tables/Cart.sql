CREATE TABLE [dbo].[Cart] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [PId]      INT            NOT NULL,
    [UKey]     NVARCHAR (150) NOT NULL,
    [Quantity] INT            CONSTRAINT [DF_Cart_Quantity] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cart_Product] FOREIGN KEY ([PId]) REFERENCES [dbo].[Product] ([Id])
);

