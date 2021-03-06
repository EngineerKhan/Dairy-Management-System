USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectAnimalsFiltered]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <18/03/2015 - 8PM>
-- Description:	<Select FILTERED Animals>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectAnimalsFiltered]

@Column varchar(20),
@QueryString varchar(20)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Prefix varchar(10)
	DECLARE @TotalQuery nvarchar(max)


    -- Insert statements for procedure here
	SELECT @TotalQuery = 'SELECT [TagNo]
      ,[RegistrationDate]
      ,[AnimalType]
	  ,at.Description
      ,[Gender]
	  ,a.ID
      ,[BirthDate]
      ,isnull([Weight],0)
      ,isnull([Height],0)
      ,isnull([Length],0)
      ,isnull([Width],0)
      ,isnull([Price],0)
      ,[Source]
	  ,aso.Description
      ,[Breed]
	  ,ab.Description
      ,[Status]
	  ,ast.Description
      ,[OtherDetails]
  FROM [dbo].[ANIMAL] a

  LEFT JOIN ANIMAL_BREED ab 
  ON ab.ID = a.Breed

  LEFT JOIN ANIMAL_SOURCE aso
  ON aso.ID = a.Source

  LEFT JOIN ANIMAL_STATUS ast
  ON ast.ID = a.Status

  LEFT JOIN ANIMAL_TYPE at
  ON at.ID = a.AnimalType

  WHERE a.IsCalf= ''N'' AND ' + @Column + ' LIKE ''%'+@QueryString+'%'''

  EXEC(@TotalQuery)

END
GO
