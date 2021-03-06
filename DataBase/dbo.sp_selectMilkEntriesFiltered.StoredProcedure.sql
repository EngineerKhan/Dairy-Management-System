USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectMilkEntriesFiltered]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <19/03/2015 - 7AM>
-- Description:	<Select FILTERED Expenses>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectMilkEntriesFiltered]

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
	SELECT @TotalQuery = 'SELECT [ID]
      ,[Milk_Animal]
      ,[EntryDate]
      ,[MilkingDate]
      ,[Shift]
      ,[Quantity]
      ,[Comments]
  FROM [DairyDB].[dbo].[MILK_ENTRY]

  WHERE ' + @Column + ' LIKE ''%'+@QueryString+'%'''

  EXEC(@TotalQuery)

END
GO
