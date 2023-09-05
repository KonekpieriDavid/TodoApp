USE [PCES]
GO
/****** Object:  StoredProcedure [dbo].[PCES_TransactionAPITest_INSERT]    Script Date: 1/25/2023 8:13:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE OR ALTER  PROCEDURE dbo.PCES_GetAllOrder_Filter
 
 (
   @PageNo int =1,
   @PageSize int=10,
   @StartDate date=null,
   @EndDate date= null ,
   @Status varchar(30)= null

	
	)
	
AS
BEGIN
   BEGIN TRY

	 SELECT
	  ROW_NUMBER() OVER(ORDER BY OrderId) AS Num_row,
	   OrderId,
	   TransactionReference,
	   Amount,
	   Currency,
	   Date,
	   Status
	   FROM OrderTable

		    WHERE
		       (@Status IS NULL OR Status = @Status)
		  AND  (@StartDate IS NULL AND @EndDate IS NULL OR Date BETWEEN @StartDate AND @EndDate)
		   
        ORDER BY OrderId ASC
		OFFSET (@PageNo -1) * @PageSize ROWS
           FETCH NEXT 10 ROWS ONLY;


	     SELECT COUNT(*) AS Total,
		 SUM(CASE WHEN Status = 'Success' THEN 1 ELSE 0 END) as Success,
         SUM(CASE WHEN Status = 'failed' THEN 1 ELSE 0 END) as failed
   
         FROM OrderTable
		  WHERE
		       (@Status IS NULL OR Status = 'Success' OR Status= 'failed')
		  AND  (@StartDate IS NULL AND @EndDate IS NULL OR Date BETWEEN @StartDate AND @EndDate)
           
	  
		 
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

SELECT * FROM  OrderTable
EXEC dbo.PCES_GetAllOrder_Filter @Status=null, @PageNo = 2, @StartDate = '2023-02-06',@EndDate='2023-02-08'
EXEC dbo.PCES_GetAllOrder_Filter @Status = 'Success' 

*/
SELECT * FROM  OrderTable