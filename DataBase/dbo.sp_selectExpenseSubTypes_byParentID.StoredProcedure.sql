USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectExpenseSubTypes_byParentID]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <30/12/2014 - 10 PM>
-- Description:	<Select Expense Sub Types for given parent category>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectExpenseSubTypes_byParentID]


@ParentID int

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
WHERE
ex.ID = @ParentID

END
GO
