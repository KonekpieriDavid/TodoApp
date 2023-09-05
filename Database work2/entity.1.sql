CREATE PROCEDURE [dbo].[PCES_sp_InsertGovTeller]
    @UserId INT,
    @AccountNumber VARCHAR(100),
    @ApprovalStatusId INT,
    @OldAccount VARCHAR(50)
AS
BEGIN
    BEGIN TRY
        INSERT INTO GovTellers (UserId, AccountNumber, ApprovalStatusId, OldAccount)
        VALUES (@UserId, @AccountNumber, @ApprovalStatusId, @OldAccount);
		   set @id= SCOPE_IDENTITY()
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
    END CATCH;
END;
SELECT * FROM GovTellers
EXEC  [dbo].[PCES_sp_InsertGovTeller]
    @UserId = 1,
    @AccountNumber = '123456789',
    @ApprovalStatusId = 2,
    @OldAccount = '987654321';