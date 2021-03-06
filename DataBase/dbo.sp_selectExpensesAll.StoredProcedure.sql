USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectExpensesAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <30/12/2014 - 6:55PM>
-- Description:	<Select All Expenses>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectExpensesAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT e.[ID]
      ,[Date]
      ,[Category]
	  ,et.Description
      ,[SubType]
	  ,est.Description
      ,[EnteredBy]
	  ,u.UserName
	  ,e.Amount
      ,e.[Comments]
  FROM [dbo].[EXPENSES] e

  LEFT JOIN EXPENSE_TYPE et ON 
  e.Category = et.ID
  LEFT JOIN EXPENSE_SUBTYPE est ON
  est.ID = e.SubType

  LEFT JOIN USERS u ON
  u.ID = e.EnteredBy



END
GO
