USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectAnimals_all_withStatus]    Script Date: 05/16/2015 15:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <01/04/2015 - 2PM>
-- Description:	<Select All Statuses as per Gender>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectAnimals_all_withStatus]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT ash.[ID]
	,a.TagNo
	,ash.Date
     ,ast.Description
    ,ast.Comments
    ,ast.IsMilking
    ,ast.IsFemale  
    ,ast.IsCalf
    ,a.ID
    
      
  FROM [DairyDB].[dbo].[ANIMAL_STATUS_HISTORY] ash
  left join ANIMAL_STATUS ast
  ON
  ast.ID = ash.Status
  left join ANIMAL a
  ON a.ID = ash.Animal
  
END
GO
