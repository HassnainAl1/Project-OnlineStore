CREATE TABLE [dbo].[Order] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [OrderNumber] INT             NOT NULL,
    [UId]         INT             NOT NULL,
    [OrderDate]   DATETIME        NOT NULL,
    [Status]      NVARCHAR (50)   NOT NULL,
    [TotalAmount] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK__Order__3214EC074B552A45] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Order__UId__2D27B809] FOREIGN KEY ([UId]) REFERENCES [dbo].[User] ([Id])
);

