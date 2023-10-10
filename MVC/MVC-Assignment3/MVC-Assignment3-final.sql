

ALTER  PROCEDURE [dbo].[SaveEmployeeAarti]

@JsonEmployee  NVARCHAR(MAX) 

AS
BEGIN

 CREATE TABLE #TempTable (
    SalaryInformatonId INT PRIMARY KEY,
	IsModified INT,
	AmountPerYear  decimal(10,2) 
);


INSERT INTO #TempTable (SalaryInformatonId,IsModified,AmountPerYear)

SELECT 
		
		SalaryInformatonId, IsModified,AmountPerYear

	FROM OPENJSON ( @JsonEmployee )  
	WITH (   
  SalaryInformatonId  int '$.SalaryInformatonId',
IsModified int '$.IsModified',
  AmountPerYear decimal(10,2)  '$.AmountPerYear'
	
	 )

 

 UPDATE SalaryInformation_aarti
SET 
       SalaryInformation_aarti.AmountPerYear = #TempTable.AmountPerYear
FROM SalaryInformation_aarti
JOIN #TempTable ON SalaryInformation_aarti.SalaryInformatonId = #TempTable.SalaryInformatonId WHERE #TempTable.IsModified=1;


END;
