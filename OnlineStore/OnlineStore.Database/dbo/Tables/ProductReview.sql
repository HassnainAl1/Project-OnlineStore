CREATE TABLE [dbo].[ProductReview] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [PId]    INT            NOT NULL,
    [UId]    INT            NOT NULL,
    [Review] NVARCHAR (500) NOT NULL,
    [Rating] INT            NOT NULL,
    CONSTRAINT [PK__ProductR__3214EC079391FF7E] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__ProductRevi__PId__286302EC] FOREIGN KEY ([PId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK__ProductRevi__UId__29572725] FOREIGN KEY ([UId]) REFERENCES [dbo].[User] ([Id])
);

