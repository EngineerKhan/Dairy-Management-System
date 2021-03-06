USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectEmployeesFiltered]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <18/03/2015 - 8PM>
-- Description:	<Select FILTERED Employees>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectEmployeesFiltered]

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
	SELECT @TotalQuery = 'SELECT emp.[ID]
      ,[Name]
      ,[Father_Name]
      ,[DateofBirth]
      ,[JoiningDate]
      ,[Salary]
      ,er.[Description] AS Role
      ,emp.[Description]
      ,[CurrentAddress]
      ,[PermanentAddress]
      ,[CNIC_No]
  FROM [dbo].[EMPLOYEE] emp

  LEFT JOIN EMPLOYEE_ROLE er

  ON emp.Role = er.ID

  WHERE ' + @Column + ' LIKE ''%'+@QueryString+'%'''

  EXEC(@TotalQuery)

END
GO
