USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_Users_Login]    Script Date: 3/29/2023 8:00:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER    PROCEDURE [dbo].[PCES_Users_Login]
(
@Username varchar(50),
@Password varchar(32)
)

AS
BEGIN TRY
  SET NOCOUNT ON
        --SELECT UserName, PasswordHash, Email, PhoneNumber, FirstName, LastName
		If Exists (SELECT UserName, PasswordHash
        FROM dbo.Users
        WHERE Username = @UserName AND PasswordHash = @Password)
		SELECT 'true' AS isExists
		ELSE
		SELECT 'false' AS isExists
END TRY 
BEGIN CATCH
	DECLARE @szErrorMessage NVARCHAR(4000)
	SET @szErrorMessage = ISNULL(N'SP: ' + OBJECT_NAME(@@PROCID) + N', ', '') + 'LN: ' + CAST(ERROR_LINE() AS NVARCHAR(20)) + N', ' + CHAR(13) + ERROR_MESSAGE()
	IF @@TRANCOUNT > 0 ROLLBACK TRAN
	RAISERROR(@szErrorMessage, 16, 1)
END CATCH