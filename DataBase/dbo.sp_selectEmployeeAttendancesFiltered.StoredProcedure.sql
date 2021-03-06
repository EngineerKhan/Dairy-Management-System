USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectEmployeeAttendancesFiltered]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <19/03/2015 - 7:16AM>
-- Description:	<Select FILTERED Expenses>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectEmployeeAttendancesFiltered]

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
	SELECT @TotalQuery = 'SELECT [Date]
      ,[Employee]
	  ,emp.Name
	  ,emp.Role,
	  r.Description
      ,[Status]
	  ,st.Description
  FROM [dbo].[EMP_ATTENDANCE] emp_a

  LEFT JOIN EMPLOYEE emp
  ON emp.ID = emp_a.Employee

  LEFT JOIN ATTENDANCE_STATUS st
  ON 
  st.ID = emp_a.Status

  LEFT JOIN EMPLOYEE_ROLE r
  ON r.ID = emp.Role

  WHERE ' + @Column + ' LIKE ''%'+@QueryString+'%'''

  EXEC(@TotalQuery)

END
GO
