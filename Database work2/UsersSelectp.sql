USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_USERS_SELECT]    Script Date: 3/21/2023 10:20:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PCES_USERS_SELECT]
	

	AS
	BEGIN
	    SELECT 
       FullName,
	   Email,
	   UserName,
	   PasswordHash,
	   PhoneNumber
		  

		  FROM USERS
	END
	--EXEC PCES_USERS_SELECT
	