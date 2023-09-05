Create PROCEDURE dbo.PCES_Registration_Select
	(
	@UserName varchar(50),
	@Password varchar(50)
	)

	AS
	BEGIN
	    SELECT
          UserName,Password
		  
		  FROM  Registration_login
	END

	EXEC PCES_Registration_Select @UserName='Daniel',@Password='Qwerty'
