USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectUsersAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <31/12/2014 - 8:25 AM>
-- Description:	<Select All Employee Roles>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectUsersAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	

SELECT U.[ID]
      ,[Type]
	  ,UR.[Description] AS UserType
      ,[UserName]
      ,[Password]
      ,u.[Comments]
  FROM [dbo].[USERS] u

  LEFT JOIN USER_ROLE ur
  ON
  u.Type = ur.ID



END
GO
