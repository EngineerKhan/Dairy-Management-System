USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectAnimalMedicalRecords_Filtered]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <19/03/2015 - 6:25AM>
-- Description:	<Select Filtered Animal Records>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectAnimalMedicalRecords_Filtered]
@Column varchar(20),
@QueryString varchar(20)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @TotalQuery nvarchar(max)

	--	 END

    -- Insert statements for procedure here
	SELECT @TotalQuery = 'SELECT amr.[ID]
      ,[Date]
      ,[Animal]
	  ,at.[ID]
	  ,at.[Description]
	  ,a.[BirthDate]
      ,[Diagnosis]
      ,[Treatment]
      ,[Prognosis]
     ,a.[TagNo]
      
  FROM [dbo].[ANIMAL_MEDICAL_RECORD] amr

  LEFT JOIN ANIMAL a 
  ON a.ID = amr.Animal

  LEFT JOIN ANIMAL_TYPE at
  ON at.ID = a.AnimalType

  WHERE ' + @Column + ' LIKE ''%'+@QueryString+'%'''

  EXEC(@TotalQuery)

END
GO
