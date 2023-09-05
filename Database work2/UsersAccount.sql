USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_USERS_INSERT1]    Script Date: 12/23/2022 12:36:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE dbo.PCES_USERS_INSERT_USERS
(
@FullName varchar(250),
@CompanyName varchar(250),
@Email varchar(50),
@UserName varchar(50),
@PasswordHash varchar(32),
@PhoneNumber Varchar(15)

)
    AS
    BEGIN 
     BEGIN TRY
	
				
	    INSERT INTO Users(
		FullName,
		CompanyName,
		Email,
		UserName,
		PasswordHash,
		PhoneNumber
		   )
		VALUES

		(

@FullName,
@CompanyName,
@Email,
@UserName,
@PasswordHash,
@PhoneNumber
)

  SELECT
     FullName,PhoneNumber,CompanyName,PasswordHash,Email
  FROM Users

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
 
     EXEC dbo.PCES_USERS_INSERT_USERS
	    
        @FullName="Banabas Jee",
		@CompanyName="PCES",
        @Email="ban@PCES.MK",
        @UserName ="Banabas",
        @PasswordHash="ban@34rt",
        @PhoneNumber="0504455000"
       

		SELECT * FROM Users
     DELETE FROM Users
	 WHERE  UserId=22
