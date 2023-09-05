-- =============================================      
-- Author:      <Author, KoneKpieri David>      
-- Create Date: <Create Date, 28.8.2023 >      
-- Description: <Description, assign a subentity to a teller>      
-- =============================================      
CREATE PROCEDURE [dbo].[PCES_sp_GovAssignSubentityToTeller]      
@UserId int,      
@SubEntityId VARCHAR(50),
@AccountNumber VARCHAR (50)
AS      
BEGIN      
  DECLARE @FilterDelimeter NVARCHAR(1) = ',' 
  
   BEGIN 
     declare @TellerId int          
        INSERT INTO GovTellers (UserId, AccountNumber, ApprovalStatusId)
        VALUES (@UserId, @AccountNumber, 2 );
		   set @TellerId= SCOPE_IDENTITY()
    END 
	 BEGIN 
     INSERT INTO GovTellerSubEntities (TellerId, SubEntityId, ApprovalStatusId)
        VALUES (@TellerId, @SubEntityId, 2);
		   
    END 
END 
 SELECT * FROM GovTellers
 SELECT * FROM GovTellerSubEntities
EXEC [PCES_sp_GovAssignSubentityToTeller]  20,20,'1233333'