USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectCustomersFiltered]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <18/03/2015 - 8PM>
-- Description:	<Select FILTERED Animals>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectCustomersFiltered]

@Column varchar(20),
@QueryString varchar(20)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Prefix varchar(10)
	DECLARE @TotalQuery nvarchar(max)


	--SELECT @Prefix =

	--CASE @Column
 --        WHEN 'Type' THEN 'at.Description'
 --        WHEN 'Gender' THEN 'g.Description'
 --        WHEN 'Source' THEN 'aso.Description'
 --        WHEN 'Breed' THEN 'ab.Description'
	--	 WHEN 'Status' THEN 'ast.Description'
 --        ELSE @Column

	--	 END

    -- Insert statements for procedure here
	SELECT @TotalQuery = 'SELECT  c.[ID]
      ,[DairyID]
      ,[Name]
      ,[Address]
      ,[ContactNo]
      ,[CNIC_No]
      ,[Reg_Date]

  FROM [DairyDB].[dbo].[CUSTOMER] c
	
  WHERE ' + @Column + ' LIKE ''%'+@QueryString+'%'''

  EXEC(@TotalQuery)

END
GO
