CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [IsVisible]   BIT            NOT NULL,
    [OwnerId]     NVARCHAR (450) NULL,
    [Price]       FLOAT (53)     DEFAULT ((0.0000000000000000e+000)) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_AspNetUsers_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Products_OwnerId]
    ON [dbo].[Products]([OwnerId] ASC);

