CREATE PROCEDURE [dbo].PCES_sp_InsertGovTellerSubEntity
    @TellerId INT,
    @SubEntityId INT,
    @ApprovalStatusId INT
AS
BEGIN
    BEGIN TRY
        INSERT INTO GovTellerSubEntities (TellerId, SubEntityId, ApprovalStatusId)
        VALUES (@TellerId, @SubEntityId, @ApprovalStatusId);
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
    END CATCH;
END;

SELECT * FROM GovApprovalStatuses
EXEC [dbo].PCES_sp_InsertGovTellerSubEntity
    @TellerId = 1,
    @SubEntityId = 123,
    @ApprovalStatusId = 2;