USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectAnimalStatusesbyGender]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <01/04/2015 - 2PM>
-- Description:	<Select All Statuses as per Gender>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectAnimalStatusesbyGender]

@Gender varchar(1)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT [ID]
      ,[Description]
	  ,[Comments]
	  ,[IsMilking]
  FROM [dbo].[ANIMAL_Status]
  WHERE IsFemale = @Gender
  AND
  IsCalf = 'N'
END
GO
