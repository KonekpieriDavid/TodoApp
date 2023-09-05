USE [PCES]
GO
/****** Object:  StoredProcedure [dbo].[PCES_InsertCustomer]    Script Date: 5/5/2023 8:47:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[PCES_InsertCustomer](
    @CustomerName VARCHAR(50),
    @TeleUserId VARCHAR(50),
    @PhoneNumber VARCHAR(20)
	)
 
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the phone number already exists
    IF EXISTS (SELECT * FROM CustomerTable WHERE PhoneNumber = @PhoneNumber)
    BEGIN
        RAISERROR('Phone number already exists in CustomerTable', 16, 1);
        RETURN;
    END

    -- Insert the new customer record
    INSERT INTO CustomerTable (CustomerName, TeleUserId, PhoneNumber)
    VALUES (@CustomerName, @TeleUserId, @PhoneNumber);
    
    SELECT SCOPE_IDENTITY() AS 'CustomerId';
END
EXEC PCES_InsertCustomer  'Braman ken',445238884,'2558458752';

--SELECT * FROM CustomerTable
