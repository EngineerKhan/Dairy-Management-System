USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectGendersAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <02/01/2015 - 2PM>
-- Description:	<Select All Employee Roles>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectGendersAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT [ID]
      ,[Description]
	  ,[Comments]
  FROM [dbo].[GENDER]

END
GO
