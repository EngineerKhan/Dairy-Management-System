USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectExpenseSubTypesAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <30/12/2014 - 1PM>
-- Description:	<Select All Expense Sub Types>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectExpenseSubTypesAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
select exp_s.ID, ex.ID AS Parent_ID, ex.Description AS Parent_Category, exp_s.Description, exp_s.Comments
from EXPENSE_SUBTYPE exp_s
left join EXPENSE_TYPE ex
ON
exp_s.ParentCategory = ex.ID

END
GO
