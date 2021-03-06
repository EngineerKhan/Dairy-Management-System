USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectCustomersAll2]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <07/01/2015 - 9AM>
-- Description:	<Select All Animals>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectCustomersAll2]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	/****** Script for SelectTopNRows command from SSMS  ******/
SELECT  c.[ID]
      ,[DairyID]
      ,[Name]
      ,[Address]
      ,[ContactNo]
      ,[CNIC_No]
      ,[Reg_Date]

  FROM [DairyDB].[dbo].[CUSTOMER] c


END
GO
