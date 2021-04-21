CREATE TABLE [dbo].[User] (
    [UserId]    INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NULL,
    [Email]     NVARCHAR (50)  NOT NULL,
    [Password]  NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);



