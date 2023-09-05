CREATE TABLE Sales (
    SaleID INT IDENTITY(1,1) PRIMARY KEY,
    Date DateTime,
    Title VARCHAR(255),
    Amount DECIMAL(10, 2)
);

CREATE PROCEDURE dbo.PCES_InsertSale
    @Date DateTime,
    @Title VARCHAR(255),
    @Amount DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Sales (Date, Title, Amount)
    VALUES (@Date, @Title, @Amount);
END;

EXEC  dbo.PCES_InsertSale '2023-08-23', 'Mango', 100.00;


CREATE PROCEDURE GetSalesData
AS
BEGIN
    SELECT SaleID, Date, Title, Amount
    FROM Sales;
END;

EXEC GetSalesData