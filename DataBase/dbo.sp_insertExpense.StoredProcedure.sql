USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_insertExpense]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 30-Dec, 2:33 PM
-- Description:	Adds/inserts Employee in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertExpense] 
	-- Add the parameters for the stored procedure here
	@Date datetime,
		   @Category int,
		   @Amount int,
		   @SubType int,
		   @CurrentUser int,
		   @Comments varchar(100)
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[EXPENSES]
           ([Date]
           ,[Amount]
		   ,[Category]
           ,[SubType]
           ,[EnteredBy]
           ,[Comments])
     VALUES
           (@Date,
		   @Amount,
		   @Category,
		   @SubType,
		   @CurrentUser,
		   @Comments)
END
GO
