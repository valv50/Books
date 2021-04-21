
CREATE   FUNCTION dbo.IsSubscribed
(
	 @UserId int, @BookId int
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE @IsSubscribed bit = 0;

    IF EXISTS (
	    SELECT TOP 1 1 
        FROM [dbo].[Subscription]
        WHERE UserId = @UserId
            AND BookId = @BookId
            AND StartDate <= GETDATE()
            AND (EndDate IS NULL OR EndDate >= GETDATE())
            )
    BEGIN
        SET @IsSubscribed = 1;
    END;

	-- Return the result of the function
	RETURN @IsSubscribed
END