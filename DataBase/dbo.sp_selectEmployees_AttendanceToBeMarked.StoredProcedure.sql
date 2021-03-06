USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectEmployees_AttendanceToBeMarked]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <09/01/2015 - 11 AM>
-- Description:	<Select those employees whose attendance is yet to be marked>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectEmployees_AttendanceToBeMarked]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


DECLARE @TodayDate date
SELECT @TodayDate = GETDATE();
    -- Insert statements for procedure here
	SELECT emp.[ID]
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

  WHERE emp.[ID] NOT IN (SELECT Employee FROM EMP_ATTENDANCE WHERE Date>=@TodayDate)

END
GO
