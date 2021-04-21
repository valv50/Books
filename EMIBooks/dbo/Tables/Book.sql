CREATE TABLE [dbo].[Book] (
    [BookId] INT             IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (MAX)  NOT NULL,
    [Text]   NVARCHAR (MAX)  NULL,
    [Price]  DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([BookId] ASC)
);

