USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_selectMilkEntriesAll]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <04/01/2015 - 2PM>
-- Description:	<Select All Milk Entries>
-- =============================================
CREATE PROCEDURE [dbo].[sp_selectMilkEntriesAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT m.ID,
		a.[TagNo]
      ,[EntryDate]
      ,[MilkingDate]
      ,[Shift]
      ,[Quantity]
      ,[Comments]
  FROM [DairyDB].[dbo].[MILK_ENTRY] m
  
  LEFT JOIN ANIMAL a 
  ON a.ID = m.Milk_Animal --modified 31 Mar
END
GO
