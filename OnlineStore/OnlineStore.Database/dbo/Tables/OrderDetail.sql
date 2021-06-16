CREATE TABLE [dbo].[OrderDetail] (
    [ID]                   INT             IDENTITY (1, 1) NOT NULL,
    [PId]                  INT             NOT NULL,
    [OrderID]              INT             NOT NULL,
    [ProductPurchasePrice] DECIMAL (18, 2) NOT NULL,
    [ProductSellPrice]     DECIMAL (18, 2) NOT NULL,
    [Quantity]             INT             NOT NULL,
    [Discounts]            DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY ([PId]) REFERENCES [dbo].[Product] ([Id])
);

