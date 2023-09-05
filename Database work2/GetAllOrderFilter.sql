USE [PCES]
GO
/****** Object:  StoredProcedure [dbo].[PCES_GetAllOrder_Filter]    Script Date: 2/9/2023 4:54:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  ALTER    PROCEDURE [dbo].[PCES_GetAllOrder_Filter]
 
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
	   Date,
	   TransactionReference,
	   Currency,
	    Amount,
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
