/****** Object:  StoredProcedure [dbo].[PCES_sp_InsertGovTellerSubEntity]    Script Date: 8/30/2023 4:40:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PCES_sp_InsertGovTellerSubEntity]
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
EXEC PCES_sp_InsertGovTellerSubEntity ;