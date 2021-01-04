USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectEmployeeRolesAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <26/12/2014 - 9PM>
-- Description:	<Select All Employee Roles>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectEmployeeRolesAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT [ID]
      ,[Description]
  FROM [dbo].[EMPLOYEE_ROLE]

END
GO
