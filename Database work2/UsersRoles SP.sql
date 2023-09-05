---AUTHOR: Konekpieri David
----DATE:6th December,2022
----DESCRIPTION:Creating stored procedure to perform Update,Insert and Delete operation

CREATE or ALTER PROCEDURE PCES_USersRoles_Update_Insert_delete
       @UserId int=null,
      @RoleId int=null,
      @InsertedBy varchar(30)=null,
      @UpdatedBy varchar(30)=null,
      @InsertDate Datetime=null,
      @UpdateDate Datetime=null,
	 @UsersRoleId int OUTPUT,
	 @Action varchar(30)
    AS 
	    BEGIN
		If @Action is null
          BEGIN TRY
	
	           IF ( @InsertedBy is null or @InsertDate is null )
	                  RAISERROR('InsertedBy or InsertedDate do not accept null values',16,1)
		                IF EXISTS(SELECT 1 FROM dbo.UsersRoles 
			                WHERE UsersRoleId=@UsersRoleId)
			          BEGIN
				        Update UsersRoles SET  UserId= @UserId ,
                                        RoleId= @RoleId,
                                         InsertedBy=@InsertedBy,
                                         UpdatedBy=@UpdatedBy ,
                                         InsertDate=@InsertDate,
                                         UpdateDate=@UpdateDate
						          WHERE UsersRoleId=@UsersRoleId
                       END
			 ELSE
			           BEGIN
					         INSERT INTO UsersRoles (UserId,RoleId,InsertedBy,UpdatedBy,InsertDate,UpdateDate)
      
	                             VALUES
	                                  (
	                                   @UserId,
	                                   @RoleId ,
                                       @InsertedBy,
                                        @UpdatedBy,
                                         @InsertDate,
                                         @UpdateDate
	                                     )
					   END
			END TRY
			
					   BEGIN CATCH
					   	    
							PRINT 'Error Message: ' + ERROR_MESSAGE()
					   END CATCH
			ELSE IF (@Action <> 'Delete')
					   RAISERROR('Check action type',16,1)
            ELSE IF (@Action ='Delete')
			    BEGIN TRY
			         DELETE FROM UsersRoles
	                     WHERE  UsersRoleId=@UsersRoleId	  
		      END TRY
			BEGIN CATCH
			         PRINT'Error Message: ' + ERROR_MESSAGE()
			END CATCH
	END
 /*
        	---Update UsersRoles table with no null values
	                EXEC PCES_USersRoles_Update_Insert_delete
	                                         @UserId=1,
	                                         @RoleId=1,
											 @InsertedBy='Peal',
											 @UpdatedBy='Kone',
											 @InsertDate='6 December 2022',
											 @UpdateDate='6 December 2022',
											 @Action=null,
											 @UsersRoleId=3

	          ---Update UsersRoles table with  null values					 
		       EXEC PCES_USersRoles_Update_Insert_delete
		                                     @UserId=1,
	                                         @RoleId=1,
											 @InsertedBy=null,
											 @UpdatedBy='Kone',
											 @InsertDate=null,
											 @UpdateDate='23-November 2022',
											 @Action=null,
											 @UsersRoleId=3



     ---Insert UsersRoles table with  null values
	 EXEC PCES_USersRoles_Update_Insert_delete
	                                         @UserId=1,
	                                         @RoleId=1,
											 @InsertedBy=null,
											 @UpdatedBy='Kone',
											 @InsertDate=null,
											 @UpdateDate='23-November 2022',
											 @Action=null,
											  @UsersRoleId=null

	---Insert UsersRoles table with no null values
	             EXEC PCES_USersRoles_Update_Insert_delete
	                                         @UserId=1,
	                                         @RoleId=1,
											 @InsertedBy='KB Alex',
											 @UpdatedBy='Kone',
											 @InsertDate='23-November 2022',
											 @UpdateDate='23-November 2022',
											 @Action=null,
											  @UsersRoleId=null

--A delete operation perform on the table usersRoles with the correct action type
			EXEC PCES_USersRoles_Update_Insert_delete  @UsersRoleId=15,@action='Delete'
					
--A delete operation perform on the table usersRoles with the incorrect action type
			EXEC PCES_USersRoles_Update_Insert_delete  @UsersRoleId=15,@action='Delite'
					








	*/











