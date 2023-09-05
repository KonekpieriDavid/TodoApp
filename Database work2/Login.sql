USE [PCES]
GO
/****** Object:  StoredProcedure [dbo].[PCES_SignUp_Form_Login]    Script Date: 3/1/2023 2:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE dbo.PCES_Login
(

   @UserName varchar(50),
   @Password varchar(50)

   )
    AS 
	 BEGIN
	 BEGIN TRY
	

	   Declare @status int
	   if Exists(select * FROM Registration_Login
	   WHERE UserName=@UserName AND Password = @Password)

   Set @status =1
   else
   set @status = 0
   Select @status

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
EXEC PCES_Login @UserName='Daniel',@Password='Qwerty'