USE [PCES]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE dbo.PCES_Registration
(
   @Id int,
   @UserName varchar(50),
   @Password varchar(50)

   )
    AS 
	 BEGIN
	 BEGIN TRY
	  INSERT INTO Registration_Login
	  (
	   UserName,
	   Password
	  )
	   VALUES
	   (
	   @UserName,
	   @Password
	   )
	
   END TRY

   BEGIN CATCH
     
	        SELECT  
                        ERROR_NUMBER() AS ErrorNumber  
                        ,ERROR_SEVERITY() AS ErrorSeverity  
                       ,ERROR_STATE() AS ErrorState  
                       ,ERROR_PROCEDURE() AS ErrorProcedure  
                        ,ERROR_LINE() AS ErrorLine  
                        ,ERROR_MESSAGE() AS ErrorMessage; 


   END CATCH
	
END

EXEC PCES_Registration @Id=null,@UserName='Joe',@Password='Walacott'
SELECT * FROM Registration_Login
