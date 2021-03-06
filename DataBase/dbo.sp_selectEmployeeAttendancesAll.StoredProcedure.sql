USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectEmployeeAttendancesAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <07/01/2015 - 9AM>
-- Description:	<Select All Attendances>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectEmployeeAttendancesAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Date]
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

END
GO
