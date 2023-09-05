USE [Beginner2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_Supplier_Insert]    Script Date: 8/24/2023 4:15:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PCES_Supplier_Insert]
    @Date Datetime,
    @SupplierName VARCHAR(255),
    @ProductSupplied VARCHAR(255),
    @Quantity INT,
    @Price DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO SupplierTable (Date,SupplierName, ProductSupplied, Quantity, Price)
    VALUES ( @Date,@SupplierName, @ProductSupplied, @Quantity, @Price)
END;

CREATE PROCEDURE [dbo].[PCES_Supplier_Select]
AS
BEGIN
    SELECT
        Date,
        SupplierName,
        ProductSupplied,
        Quantity,
        Price
    FROM
        SupplierTable;
END;

EXEC dbo.PCES_Supplier_Select;