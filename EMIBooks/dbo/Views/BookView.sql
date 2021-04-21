CREATE VIEW BookView AS
SELECT *, CAST(1 AS bit) Subscribed FROM dbo.Book