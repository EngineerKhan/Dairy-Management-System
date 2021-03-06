USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectExpensesFiltered]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <18/03/2015 - 8PM>
-- Description:	<Select FILTERED Expenses>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectExpensesFiltered]

@Column varchar(20),
@QueryString varchar(20)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @TotalQuery nvarchar(max)

	--	 END

    -- Insert statements for procedure here
	SELECT @TotalQuery = 'SELECT e.[ID]
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

  WHERE ' + @Column + ' LIKE ''%'+@QueryString+'%'''

  EXEC(@TotalQuery)

END
GO
