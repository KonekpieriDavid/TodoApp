CREATE or ALTER PROCEDURE PCES_InsertCustomer(
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
--EXEC PCES_InsertCustomer  'Kojo Ben',445233344,'0538458752';

--SELECT * FROM CustomerTable
