CREATE Or ALTER  PROCEDURE PCES_Users_Login
(
@Username varchar(50),
@Password varchar(32)
)

AS
BEGIN TRY
        SELECT UserName, PasswordHash, Email, PhoneNumber, FirstName, LastName
        FROM dbo.Users
        WHERE Username = @UserName AND PasswordHash = @Password
END TRY
BEGIN CATCH
	DECLARE @szErrorMessage NVARCHAR(4000)
	SET @szErrorMessage = ISNULL(N'SP: ' + OBJECT_NAME(@@PROCID) + N', ', '') + 'LN: ' + CAST(ERROR_LINE() AS NVARCHAR(20)) + N', ' + CHAR(13) + ERROR_MESSAGE()
	IF @@TRANCOUNT > 0 ROLLBACK TRAN
	RAISERROR(@szErrorMessage, 16, 1)
END CATCH