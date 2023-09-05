USE [PCES]
GO
/****** Object:  StoredProcedure [dbo].[PCES_Registration]    Script Date: 3/2/2023 10:29:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[PCES_Registration]
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