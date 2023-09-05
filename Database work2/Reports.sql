CREATE TABLE Reports (
    ReportID INT IDENTITY(1,1) PRIMARY KEY,
    ReportDate DATE,
    SalesInformation NVARCHAR(MAX),
    Report NVARCHAR(MAX)
);
CREATE PROCEDURE InsertReport
    @ReportDate DATE,
    @SalesInformation NVARCHAR(MAX),
    @Report NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Reports (ReportDate, SalesInformation, Report)
    VALUES (@ReportDate, @SalesInformation, @Report);
END;

EXEC InsertReport
    @ReportDate = '2023-09-06',
    @SalesInformation = 'No sales for today',
    @Report = 'we could not make any sales today dues to the cleanup exercise.';

	SELECT * FROM Reports
	EXEC sp_helpconstraint 'Reports';