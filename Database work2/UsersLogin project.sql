USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_USERS_INSERT]    Script Date: 3/20/2023 9:41:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER PROCEDURE [dbo].[pces_Users_InsSignUp]
(
@FullName varchar(50) = NULL,
@Email varchar(30) = NULL,
@UserName varchar(30) = NULL,
@PasswordHash varchar(30) = NULL,
@PhoneNumber varchar(20) = NULL

)
AS
BEGIN TRY
      --throw an error if the first name or last name is null
      IF EXISTS(SELECT 1 FROM Users WHERE Email = @Email)
	  BEGIN;
	    THROW 70000, 'The email address already exists',1;
	  END;

ELSE 
BEGIN
	INSERT INTO dbo.Users(
	   FullName,
	   Email,
	   UserName,
	   PasswordHash,
	   PhoneNumber
	)
	VALUES (
	   @FullName,
	   @Email,
	   @UserName,
	   @PasswordHash,
	   @PhoneNumber
	)
END
END TRY
BEGIN CATCH
--return error
  SELECT ERROR_NUMBER() AS ErrorNumber,
         ERROR_SEVERITY() AS ErrorSeverity,
		 ERROR_STATE() AS ErrorState,
		 ERROR_PROCEDURE() AS ErrorProcedure,
		 ERROR_LINE() AS ErrorLine,
		 ERROR_MESSAGE() AS ErrorMessage
END CATCH

--EXEC pces_Users_InsSignUp @FullName ="Kojo Ben", @Email="kojben@gmail.com",@UserName="Ben",@PasswordHash="@kb12345678",@PhoneNumber="0245698756"


--Select  FullName,Email , UserName,  PasswordHash,   PhoneNumber 	
--from dbo.Users  WHERE FullName='Kojo Ben'AND Email='kojben@gmail.com'AND UserName='Ben'AND PasswordHash='@kb12345678'AND PhoneNumber='0245698756'
--SELECT FullName, Email,UserName,PasswordHash from Users
	
	