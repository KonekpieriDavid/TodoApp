USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_USERS_INSERT_USERS]    Script Date: 12/23/2022 3:36:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE OR ALTER   PROCEDURE dbo.PCES_USERS_Login
(

   @UserName varchar(50),
   @PasswordHash varchar(32)

   )
    AS 
	 BEGIN
	 BEGIN TRY
	   
	   SELECT FullName,PhoneNumber,Email
	
      FROM Users

    WHERE
	     @UserName=UserName AND @PasswordHash=PasswordHasH

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

EXEC dbo.PCES_USERS_Login    @UserName="Jame Kay" ,@PasswordHash="@34rtc";
SELECT * FROM Users
/*
SELECT * FROM Users

EXEC dbo.PCES_USERS_Login    @UserName="Jame Kay" ,@PasswordHash="@34rtc";
SELECT * FROM Users
  */