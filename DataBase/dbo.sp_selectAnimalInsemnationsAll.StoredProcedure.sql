USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectAnimalInsemnationsAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 01-Apr
-- Description:	Adds/inserts Employee in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectAnimalInsemnationsAll] 
	-- Add the parameters for the stored procedure here

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	i.ID,
	i.Animal,
	a.TagNo,
	i.Date,
	i.Comments
	
	FROM Animal_Insemnation i
	
	LEFT JOIN ANIMAL a
	ON
	i.Animal = a.ID

END
GO
