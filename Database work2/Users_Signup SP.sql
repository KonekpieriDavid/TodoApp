USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_USERS_INSERT_REGISTRATION]    Script Date: 1/12/2023 12:57:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 ALTER     PROCEDURE [dbo].[PCES_USERS_INSERT_REGISTRATION]
(
@FullName varchar(250),
@PhoneNumber Varchar(15),
@UserName varchar(50),
@PasswordHash varchar(32),
@Email varchar(32)


)
    AS
    BEGIN 
     BEGIN TRY
	     IF EXISTS(SELECT Email FROM Users WHERE Email = @Email)
		 THROW 51000, ' if Email  exists', 1;
	
	    INSERT INTO Users(
		FullName,
		PhoneNumber,
		UserName,
		PasswordHash,
		Email
		   )
		VALUES

		(

@FullName,
@PhoneNumber,
@UserName,
@PasswordHash,
@Email 

)

  
   END TRY

   BEGIN CATCH
     --reture error if email is found
	        SELECT  
                        ERROR_NUMBER() AS ErrorNumber  
                        ,ERROR_SEVERITY() AS ErrorSeverity  
                       ,ERROR_STATE() AS ErrorState  
                       ,ERROR_PROCEDURE() AS ErrorProcedure  
                        ,ERROR_LINE() AS ErrorLine  
                        ,ERROR_MESSAGE() AS ErrorMessage; 


   END CATCH
	
END




exec [dbo].[PCES_USERS_INSERT_REGISTRATION]
      @FullName="Henry Benard",
	   @UserName="Henry",
	   @PhoneNumber="0547819811",
	   @PasswordHash="Hen23@2022",
	    @Email="jhihi@mail.com"

		
		SELECT 
		FullName,
		PhoneNumber,
		UserName,
		PasswordHash,
		Email 
		FROM  Users 
		

	 select * from users

	 */



	DELETE  FROM Users WHERE Email='wayofatima@gmail.com'