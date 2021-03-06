USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectCalfsAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <02/01/2015 - 8PM>
-- Description:	<Select All Animals>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectCalfsAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT (a.[TagNo])
      ,a.[RegistrationDate]
      ,a.[AnimalType]
	  ,at.Description
      ,a.[Gender]
	  ,a.ID
      ,a.[BirthDate]
      ,isnull(a.[Weight],0)
      ,isnull(a.[Height],0)
      ,isnull(a.[Length],0)
      ,isnull(a.[Width],0)
      ,isnull(a.[Price],0)
      ,a.[Source]
	  ,aso.Description
      ,a.[Breed]
	  ,ab.Description
      ,a.[Status]
	  ,ast.Description
      ,a.[OtherDetails]
	  
	 ,cpmd.TagNo
	,isnull(cpm.Parent,0)   
	 ,cpfd.TagNo 
	,isnull(cpf.Parent,0) 

   FROM [dbo].[ANIMAL] a
  
  LEFT JOIN CALF_PARENT cpm ON a.ID = cpm.Calf AND cpm.IsMother = 'Y'
  LEFT JOIN ANIMAL cpmd     ON cpmd.ID = cpm.Parent
  LEFT JOIN CALF_PARENT cpf ON a.ID = cpf.Calf AND cpf.IsMother = 'N'
  LEFT JOIN ANIMAL cpfd     ON cpfd.ID = cpf.Parent 
  
  --LEFT JOIN [CALF_PARENT] cp
  --ON a.ID = cp.Calf
  
  ----Modified Apr-02
  --LEFT JOIN ANIMAL a2
  --ON a2.ID = cp.Parent AND cp.IsMother = 'Y' AND a2.ID IS NOT NULL

  --LEFT JOIN ANIMAL a3
  --ON a3.ID = cp.Parent AND cp.IsMother = 'N' AND a3.ID IS NOT NULL

  LEFT JOIN ANIMAL_BREED ab 
  ON ab.ID = a.Breed

  LEFT JOIN ANIMAL_SOURCE aso
  ON aso.ID = a.Source

  LEFT JOIN ANIMAL_STATUS ast
  ON ast.ID = a.Status

  LEFT JOIN ANIMAL_TYPE at
  ON at.ID = a.AnimalType

  --Modifed 31-Mar

  WHERE a.IsCalf='Y'
  
  --GROUP BY a.TagNo, a.ID

END
GO
