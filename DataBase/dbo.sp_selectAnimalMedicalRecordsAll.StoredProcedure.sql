USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectAnimalMedicalRecordsAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <08/01/2014 - 6:55PM>
-- Description:	<Select All Medical Records>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectAnimalMedicalRecordsAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT amr.[ID]
      ,[Date]
      ,[Animal]
	  ,at.[ID]
	  ,at.[Description]
	  ,a.[BirthDate]
      ,[Diagnosis]
      ,[Treatment]
      ,[Prognosis]
	  ,a.TagNo
  FROM [dbo].[ANIMAL_MEDICAL_RECORD] amr

  LEFT JOIN ANIMAL a 
  ON a.ID = amr.Animal		--Modified on 31-Mar. PK is changed

  LEFT JOIN ANIMAL_TYPE at
  ON at.ID = a.AnimalType


END
GO
