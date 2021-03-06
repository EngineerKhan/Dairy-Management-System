USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectCalfsFiltered]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <18/03/2015 - 8PM>
-- Description:	<Select FILTERED Animals>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectCalfsFiltered]

@Column varchar(20),
@QueryString varchar(20)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Prefix varchar(10)
	DECLARE @TotalQuery nvarchar(max)


	--SELECT @Prefix =

	--CASE @Column
 --        WHEN 'Type' THEN 'at.Description'
 --        WHEN 'Gender' THEN 'g.Description'
 --        WHEN 'Source' THEN 'aso.Description'
 --        WHEN 'Breed' THEN 'ab.Description'
	--	 WHEN 'Status' THEN 'ast.Description'
 --        ELSE @Column

	--	 END

    -- Insert statements for procedure here
	SELECT @TotalQuery = 'SELECT DISTINCT (a.[TagNo])
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
  
  LEFT JOIN CALF_PARENT cpm ON a.ID = cpm.Calf AND cpm.IsMother = ''Y''
  LEFT JOIN ANIMAL cpmd     ON cpmd.ID = cpm.Parent
  LEFT JOIN CALF_PARENT cpf ON a.ID = cpf.Calf AND cpf.IsMother = ''N''
  LEFT JOIN ANIMAL cpfd     ON cpfd.ID = cpf.Parent 
  

  LEFT JOIN ANIMAL_BREED ab 
  ON ab.ID = a.Breed

  LEFT JOIN ANIMAL_SOURCE aso
  ON aso.ID = a.Source

  LEFT JOIN ANIMAL_STATUS ast
  ON ast.ID = a.Status

  LEFT JOIN ANIMAL_TYPE at
  ON at.ID = a.AnimalType

  WHERE a.IsCalf= ''Y'' AND ' + @Column + ' LIKE ''%'+@QueryString+'%'''

  EXEC(@TotalQuery)

END
GO
