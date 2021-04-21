CREATE TABLE [dbo].[Subscription] (
    [SubscriptionId] INT  IDENTITY (1, 1) NOT NULL,
    [UserId]         INT  NOT NULL,
    [BookId]         INT  NOT NULL,
    [StartDate]      DATE NOT NULL,
    [EndDate]        DATE NULL,
    CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED ([SubscriptionId] ASC),
    CONSTRAINT [FK_Subscription_Book] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Book] ([BookId]),
    CONSTRAINT [FK_Subscription_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);



