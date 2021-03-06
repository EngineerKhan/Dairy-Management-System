USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectExpenseCategoriesAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <30/12/2014 - 1PM>
-- Description:	<Select All Expense Types>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectExpenseCategoriesAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	

SELECT [ID]
      ,[Description]
      ,[Comments]
  FROM [dbo].[EXPENSE_TYPE]

END
GO
