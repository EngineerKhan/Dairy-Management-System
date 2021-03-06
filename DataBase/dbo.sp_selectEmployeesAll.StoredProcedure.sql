USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectEmployeesAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <26/12/2014 - 9PM>
-- Description:	<Select All Employees>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectEmployeesAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

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

END
GO
