
CREATE   PROCEDURE dbo.BookUnsubscribe(@BookId int, @UserId int)
AS
BEGIN
    SET NOCOUNT ON;  

    DECLARE @CurrentDate date = GETDATE();

    MERGE dbo.Subscription AS target 
    USING (SELECT @UserId, @BookId) AS source (UserId, BookId)  
    ON (target.UserId = source.UserId
        AND target.BookId = source.BookId 
        AND target.StartDate <= @CurrentDate
        AND (target.EndDate IS NULL OR target.EndDate > @CurrentDate))   
    WHEN MATCHED THEN
        UPDATE SET EndDate = @CurrentDate; 
END