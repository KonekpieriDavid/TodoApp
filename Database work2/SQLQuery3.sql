CREATE PROCEDURE dbo.PCES_Supplier_Insert
    @SupplierName VARCHAR(255),
    @ProductSupplied VARCHAR(255),
    @Quantity INT,
    @Price DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Supplier (SupplierName, ProductSupplied, Quantity, Price)
    VALUES (@SupplierName, @ProductSupplied, @Quantity, @Price)
END;

EXEC dbo.PCES_Supplier_Insert
     
    @SupplierName = 'Mary Maafo',
    @ProductSupplied = 'Malta Gunies',
    @Quantity = 10,
    @Price = 200.00;

	SELECT * FROM Supplier