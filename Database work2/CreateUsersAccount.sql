USE [PaymentPlatformV2]
GO
/****** Object:  StoredProcedure [dbo].[PCES_USERS_UPDATE]    Script Date: 12/23/2022 1:55:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PCES_USERS_UPDATE]
@UserId int,
@FullName varchar(250),
@CompanyName varchar(250),
@Email varchar(50),
@UserName varchar(50),
@AgreedTOC bit,
@PasswordHash varchar(32),
@IsGlobalAdmin bit,
@EnableMFA bit,
@LastLoginDate Datetime,
@Language varchar(15),
@PhoneNumber Varchar(15),
@WalletNumber varchar(15),
@IsVendor bit,
@isActive bit,
@ParentId int,
@IsVerified bit,

@Profile varchar(4000),
@CreatedBy varchar(30),
@UpdatedBy varchar(30),
@CreatedDate Datetime,
@UpdatedDate Datetime,
@FirstName varchar(180),
@MiddleName varchar(50),
@LastName varchar (180)

   AS
	  BEGIN 
	    UPDATE Users SET FullName= @FullName, CompanyName=@CompanyName, Email=@Email,UserName=@UserName,AgreedTOC=
@AgreedTOC,PasswordHash=@PasswordHash,IsGlobalAdmin=@IsGlobalAdmin,EnableMFA=@EnableMFA ,LastLoginDate=@LastLoginDate,Language=@Language,PhoneNumber=
@PhoneNumber,
		    WalletNumber=@WalletNumber,IsVendor=@IsVendor,IsActive=@isActive,ParentId=@ParentId,IsVerified=@IsVerified,Profile=@Profile,CreatedBy=@CreatedBy,UpdatedBy=@UpdatedBy,CreatedDate=@CreatedDate,UpdatedDate=
@UpdatedDate,FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName 
	
		
    WHERE UserId=@UserId
END
SELECT * FROM Users

exec  [dbo].[PCES_USERS_UPDATE]
         @UserId=16,
        @FullName="Alice Tieru",
		@CompanyName="PCES",
        @Email="Alice@PCES.MK",
        @UserName ="Alice",
        @AgreedTOC=1,
        @PasswordHash="Alice22irtc",
        @IsGlobalAdmin=1,
        @EnableMFA=1 ,
        @LastLoginDate="12-23-22",
        @Language ="English",
        @PhoneNumber="0549835567",
        @WalletNumber=432,
        @IsVendor=1,
        @isActive=1,
        @ParentId=233,
        @IsVerified=1,
        @Profile="abc",
        @CreatedBy="John",
        @UpdatedBy=Kojo,
        @CreatedDate="12-21-2022",
        @UpdatedDate="12-22-2022",
        @FirstName="Alice",
        @MiddleName ="z",
        @LastName ="tieru"