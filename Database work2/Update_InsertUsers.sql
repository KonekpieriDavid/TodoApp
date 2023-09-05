------AUTHOR : KONEKPIERI DAVID
------DATE: 1stDecember,2022 
-----TIME: 10:40AM

CREATE OR ALTER PROCEDURE [dbo].[PCES_USERS_INSERT_UPDATE_DELETE]
(
           @UserId int OUTPUT ,
            @FullName varchar(250)=NULL,
             @CompanyName varchar(250)=NULL,
                 @Email varchar(50)=NULL,
                 @UserName varchar(50)=NULL,
                  @AgreedTOC bit=NULL,
                  @PasswordHash varchar(32)=NULL,
                   @IsGlobalAdmin bit=NULL,
                  @EnableMFA bit=NULL,
                 @LastLoginDate Datetime=NULL,
                  @Language varchar(15)=NULL,
                   @PhoneNumber Varchar(15)=NULL,
                  @WalletNumber varchar(15)=NULL,
                @IsVendor bit=NULL,
               @isActive bit=NULL,
               @ParentId int=NULL,
               @IsVerified bit=NULL,

                @Profile varchar(4000)=NULL,
                 @CreatedBy varchar(30)=NULL,
                 @UpdatedBy varchar(30)=NULL,
                 @CreatedDate Datetime=NULL,
                   @UpdatedDate Datetime=NULL,
                   @FirstName varchar(180)=NULL,
                      @MiddleName varchar(50)=NULL,
                  @LastName varchar (180)=NULL,
                  @Action   varchar(180)
)
    AS
       BEGIN 
     IF  @Action is null
	       BEGIN TRY
		  
		   IF( @FirstName IS NULL OR @MiddleName IS NULL)
			
	          RAISERROR('FirstName and MiddleName do not accept null values',15,1)


		IF EXISTS(SELECT 1 FROM dbo.Users WHERE UserId=@UserId)
			BEGIN
				  UPDATE Users SET FullName= @FullName, CompanyName=@CompanyName, Email=@Email,UserName=@UserName,AgreedTOC=
          @AgreedTOC,PasswordHash=@PasswordHash,IsGlobalAdmin=@IsGlobalAdmin,EnableMFA=@EnableMFA ,LastLoginDate=@LastLoginDate,Language=@Language,PhoneNumber=
          @PhoneNumber,
		    WalletNumber=@WalletNumber,IsVendor=@IsVendor,IsActive=@isActive,ParentId=@ParentId,IsVerified=@IsVerified,Profile=@Profile,CreatedBy=@CreatedBy,UpdatedBy=@UpdatedBy,CreatedDate=@CreatedDate,UpdatedDate=
           @UpdatedDate,FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName 
	
		
                          WHERE UserId=@UserId
	
		          END
		                    ELSE
			         BEGIN
				
	    INSERT INTO Users(FullName,CompanyName,Email,UserName,AgreedTOC,PasswordHash,IsGlobalAdmin,EnableMFA,LastLoginDate,Language,PhoneNumber,
		    WalletNumber,IsVendor,IsActive,ParentId,IsVerified,Profile,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate,FirstName,MiddleName,LastName)
		VALUES(

                     @FullName,
                        @CompanyName,
                           @Email,
                            @UserName,
                              @AgreedTOC,
                                 @PasswordHash,
                                   @IsGlobalAdmin,
                                       @EnableMFA ,
                                   @LastLoginDate,
                                @Language ,
                                  @PhoneNumber,
                             @WalletNumber,
                             @IsVendor,
                          @isActive,
                         @ParentId,
                      @IsVerified,
                    @Profile,
                   @CreatedBy,
                   @UpdatedBy,
                   @CreatedDate,
                    @UpdatedDate,
                    @FirstName,
                    @MiddleName,
                     @LastName 
)
			END
		
			
	
	
	
			
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


	                else if(@Action<> 'DELETE' )
	               RAISERROR( 'Check action type',15,9)


	                 else if @Action = 'DELETE'
	   BEGIN TRY
                       DELETE FROM Users
	                      WHERE  UserId=@UserId
						  
						  END TRY

				 BEGIN CATCH
				 
						
						  SELECT  
                        ERROR_NUMBER() AS ErrorNumber  
                        ,ERROR_SEVERITY() AS ErrorSeverity  
                       ,ERROR_STATE() AS ErrorState 
						  
						 END CATCH
			 END

			 /*
	  
	  ---update with null values
	      EXEC PCES_USERS_INSERT_UPDATE_DELETE  @UserId = 7,  @FullName='Nana Boateng', @CompanyName='PCES', @Email='kwame@pces.mk',@UserName='David',
		  @AgreedTOC=1,@PasswordHash='ktweeety', @IsGlobalAdmin=1,@EnableMFA=1,@LastLoginDate='21 November 2022',@Language ='English',
		    @PhoneNumber=0547819871,
                              @WalletNumber=223,@IsVendor=1,@isActive=1,      @ParentId=2, @IsVerified=1,@Profile='aa',@CreatedBy='kwame', 
							  @UpdatedBy='kwame',@CreatedDate='21-December 2022', @UpdatedDate='21-December 2022',@FirstName=null, @MiddleName=null, @LastName='Kwame', @Action=null

  ----Update with no null values
   EXEC PCES_USERS_INSERT_UPDATE_DELETE @UserId = 14,  @FullName='Nana Boateng', @CompanyName='PCES', @Email='kwame@pces.mk',@UserName='David',
		  @AgreedTOC=1,@PasswordHash='ktweeety', @IsGlobalAdmin=1,@EnableMFA=1,@LastLoginDate='21 November 2022',@Language ='English',
		    @PhoneNumber=0547819871,
                              @WalletNumber=223,@IsVendor=1,@isActive=1,      @ParentId=2, @IsVerified=1,@Profile='aa',@CreatedBy='kwame', 
							  @UpdatedBy='kwame',@CreatedDate='21-December 2022', @UpdatedDate='21-December 2022',@FirstName='james', @MiddleName='Jacob', @LastName='Kwame',@Action=null



            
   ---This is INSERT with null values

         EXEC PCES_USERS_INSERT_UPDATE_DELETE @UserId = null,  @FullName='Nana Boateng', @CompanyName='PCES', @Email='kwame@pces.mk',@UserName='David',
		  @AgreedTOC=1,@PasswordHash='ktweeety', @IsGlobalAdmin=1,@EnableMFA=1,@LastLoginDate='21 November 2022',@Language ='English',
		    @PhoneNumber=0547819871,
                              @WalletNumber=223,@IsVendor=1,@isActive=1,      @ParentId=2, @IsVerified=1,@Profile='aa',@CreatedBy='kwame', 
							  @UpdatedBy='kwame',@CreatedDate='21-December 2022', @UpdatedDate='21-December 2022',@FirstName=null, @MiddleName=null, @LastName='Kwame',@Action=null

                   
   ----this is the INSERT with no null values

           EXEC PCES_USERS_INSERT_UPDATE_DELETE @UserId = null,  @FullName='Nana Boateng', @CompanyName='PCES', @Email='kwame@pces.mk',@UserName='David',
		  @AgreedTOC=1,@PasswordHash='ktweeety', @IsGlobalAdmin=1,@EnableMFA=1,@LastLoginDate='21 November 2022',@Language ='English',
		    @PhoneNumber=0547819871,
                              @WalletNumber=223,@IsVendor=1,@isActive=1,      @ParentId=2, @IsVerified=1,@Profile='aa',@CreatedBy='kwame',
							  @UpdatedBy='kwame',@CreatedDate='21-December 2022', @UpdatedDate='21-December 2022',@FirstName='Kojo', @MiddleName='quashi', @LastName='Kwame',@Action=null

                       
						----This DELETE  with the delete action type and  specified UserId	 
                    EXEC PCES_USERS_INSERT_UPDATE_DELETE @UserId=9, @Action='DELETE'
				
				----This DELETE  with the  wrong action type
				      EXEC PCES_USERS_INSERT_UPDATE_DELETE @UserId=9, @Action='DELE'

   
 
*/


		