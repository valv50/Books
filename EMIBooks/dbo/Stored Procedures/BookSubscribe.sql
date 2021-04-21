
CREATE   PROCEDURE dbo.BookSubscribe(@BookId int, @UserId int)
AS
BEGIN
    SET NOCOUNT ON;  

    DECLARE @CurrentDate date = GETDATE();

    MERGE dbo.Subscription AS target 
    USING (SELECT @UserId, @BookId) AS source (UserId, BookId)  
    ON (target.UserId = source.UserId
        AND target.BookId = source.BookId 
        AND target.StartDate <= @CurrentDate)   
    WHEN MATCHED AND target.EndDate >= @CurrentDate THEN
        UPDATE SET EndDate = NULL
    WHEN NOT MATCHED THEN  
        INSERT (UserId, BookId, StartDate)  
        VALUES (source.UserId, source.BookId, @CurrentDate); 
END