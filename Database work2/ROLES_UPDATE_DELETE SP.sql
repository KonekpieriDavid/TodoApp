 ----AUTHOR: Konekpieri David
----DATE:5th December,2022
----DESCRIPTION:Creating stored procedure to perform INSERT operation on the table Roles


CREATE OR ALTER PROCEDURE PCES_Roles_Update_Insert_Delete
(
      
 @RoleId int OUTPUT,
 @Name varchar(30)=null,
 @Description varchar (400)=null,
 @InsertedBy varchar(30)=null,
 @UpdatedBy varchar(30)=null,
 @InsertDate datetime=null,
 @UpdateDate datetime=null,
 @Action varchar(30)
 )
 AS
	BEGIN
	    IF @Action is null
         BEGIN TRY

		 IF (@RoleId is null or @Name is null)
				RAISERROR('RoleId or Name do not allow null values',16,1 )
					IF EXISTS(SELECT 1 FROM dbo.Roles WHERE RoleId=@RoleId)

                       BEGIN
                           UPDate Roles SET  Name= @Name,
				                   Description= @Description,
								   InsertedBy= @InsertedBy ,
								    UpdatedBy=  @UpdatedBy,
								     InsertDate=@InsertDate,
									 UpdateDate=@UpdateDate 

				             WHERE RoleId=@RoleId
				       END		  
         ELSE 
               BEGIN 
                       INSERT INTO Roles( Name, Description ,  InsertedBy,UpdatedBy,  InsertDate , UpdateDate)
	                            VALUES(
		                                @Name,
		                                @Description ,
		                                @InsertedBy, 
		                                @UpdatedBy,
	                                    @InsertDate ,
		                                @UpdateDate
	                                        )
	           END
          END TRY
	        BEGIN CATCH
							PRINT 'Error Message: ' + ERROR_MESSAGE()
	                
	        END CATCH

		else if(@Action<> 'DELETE' )
		       RAISERROR( 'Check action type',15,9)

	          else if @Action = 'DELETE'
		       BEGIN TRY
			       DELETE FROM Roles
	                 WHERE  RoleId=@RoleId	  
		      END TRY
		BEGIN CATCH
		       PRINT 'Error Message: ' + ERROR_MESSAGE()
	         			  
		END CATCH
	 END
	    

   /*
		---Update Roles table with no null values

	  EXEC PCES_Roles_Update_Insert_Delete @RoleId='4', @Name='Thadious', @Description='CEO', @InsertedBy='Edina',

	          @UpdatedBy='David', @InsertDate='5-December 2022', @UpdateDate ='5-December 2022', @Action=null

			  
		---Update Roles table with  null values

				  EXEC PCES_Roles_Update_Insert_Delete @RoleId=null, @Name=null, @Description='CEO', @InsertedBy='Edina',

	          @UpdatedBy='David', @InsertDate='5-December 2022', @UpdateDate ='5-December 2022', @Action=null

			  
		
	      ---Insert Roles table with  null values
				        EXEC PCES_Roles_Update_Insert_Delete @RoleId=null, @Name=null, @Description='CEO', @InsertedBy='Edina',

	          @UpdatedBy='David', @InsertDate='5-December 2022', @UpdateDate ='5-December 2022', @Action=null

		 ---Insert Roles table with no null values
			            EXEC PCES_Roles_Update_Insert_Delete @RoleId=1, @Name='Kofi', @Description='CEO', @InsertedBy='Edina',
	                          @UpdatedBy='David', @InsertDate='5-December 2022', @UpdateDate ='5-December 2022', @Action=null

			  --This is DELETE  with the delete action type and  specified RoleIdId	 
                    	    EXEC PCES_Roles_Update_Insert_Delete   @RoleId=3, @Action='DELETE'

			--This is DELETE  with incorrect delete action type and a specified RoleId	 
                    	    EXEC PCES_Roles_Update_Insert_Delete   @RoleId=3, @Action='DELETI'
	*/
    













       INSERT INTO Roles( Name, Description ,  InsertedBy,UpdatedBy,  InsertDate , UpdateDate)
	   VALUES(
	      
		    @Name,
		  @Description ,
		  @InsertedBy, 
		  @UpdatedBy,
		  @InsertDate ,
		  @UpdateDate
	       )
   END
          EXEC PCES_Roles_INSERT 'David','manerger','David','David','2022-12-02 14:30:23','2022-12-02 14:30:33'
		   EXEC PCES_Roles_INSERT 'Bennard','Secretary','juu','Kofi','2022-12-02 14:30:23','2022-12-02 14:30:33'
 
      SELECT * 
   FROM  Roles


  ----AUTHOR: Konekpieri David
----DATE:23nd November,2022
----DESCRIPTION:Creating stored procedure to perform SELECT operation on the table Roles

      ALTER PROCEDURE PCES_Roles_SELECT

	  AS
	  BEGIN
	         SELECT Name, InsertedBy, InsertDate
			 FROM ROLES
	  END
	     EXEC PCES_Roles_SELECT

----AUTHOR: Konekpieri David
----DATE:23nd November,2022
----DESCRIPTION:Creating stored procedure to perform UPDATE operation on the table Roles


		 ALTER PROCEDURE PCES_Roles_UPDATE
		 @RoleId int,
		    @Name varchar(30),
      @Description varchar (400),
      @InsertedBy varchar(30),
      @UpdatedBy varchar(30),
      @InsertDate datetime,
      @UpdateDate datetime
		 AS
		 BEGIN
		         UPDate Roles SET  Name= @Name,Description= @Description,InsertedBy= @InsertedBy ,UpdatedBy=  @UpdatedBy,InsertDate=@InsertDate,
				   UpdateDate=@UpdateDate 

				   WHERE RoleId=@RoleId
				       
				      
		 END
		   EXEC PCES_Roles_UPDATE 1,'Bruose','Secretary','Zaana','David','2022-12-02 14:30:23','2022-12-02 14:30:33'
 
   SELECT * FROM Roles

 ----AUTHOR: Konekpieri David
----DATE:23nd November,2022
----DESCRIPTION:Creating stored procedure to perform Delete operation on the table Roles

    
	  ALTER PROCEDURE PCES_Roles_DELETE
	  (
	     @RoleId int
		 )
	    AS
		BEGIN
		DELETE FROM Roles
		    WHERE RoleId=@RoleId
		END
		EXEC PCES_Roles_DELETE 2

		SELECT * FROM Roles

		