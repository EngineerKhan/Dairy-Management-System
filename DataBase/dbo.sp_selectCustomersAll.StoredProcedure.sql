USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectCustomersAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <07/01/2015 - 9AM>
-- Description:	<Select All Animals>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectCustomersAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	/****** Script for SelectTopNRows command from SSMS  ******/
SELECT  c.[ID]
	  ,cm.ID
      ,[DairyID]
      ,[Name]
      ,[Address]
      ,[ContactNo]
      ,[CNIC_No]
      ,[Reg_Date]
	  ,cm.Time
	  ,cm.Price_Category
	  ,price.Description
	  ,cm.Quantity
	  ,cm.Type
	  ,ty.Description
	  ,cm.Time
	  ,tm.Description

  FROM [DairyDB].[dbo].[CUSTOMER] c
  LEFT JOIN customer_milk_specs cm
  ON
  c.ID = cm.ID
  LEFT JOIN CUSTOMER_PRICE_CATEGORY price
  ON
  price.ID = cm.Price_Category
  LEFT JOIN ANIMAL_TYPE Ty
  ON
  Ty.ID = cm.Type
  LEFT JOIN CUSTOMER_TIME_CATEGORY tm
  ON
  tm.ID = cm.Time

END
GO
