USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectMilk_PriceCategoriesAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <07/01/2015 - 2PM>
-- Description:	<Select All Employee Roles>
-- =============================================
create PROCEDURE [dbo].[sp_selectMilk_PriceCategoriesAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT [ID]
      ,[Description]
	  ,[Comments]
  FROM [dbo].[CUSTOMER_PRICE_CATEGORY]

END
GO
