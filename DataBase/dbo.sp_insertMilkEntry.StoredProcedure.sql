USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_insertMilkEntry]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 04-Jan, 5:55 PM
-- Description:	Adds/inserts Animal in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertMilkEntry] 
	-- Add the parameters for the stored procedure here
	@ID int,	--Added on 1 Apr
         @RegistrationDate datetime,
		 @MilkingDate date,
		 @Shift varchar(7),
		 @Quantity float,
           @Comments varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[MILK_ENTRY]
           ([Milk_Animal]
           ,[EntryDate]
           ,[MilkingDate]
           ,[Shift]
           ,[Quantity]
           ,[Comments])
     VALUES
           (@ID,
           @RegistrationDate,
           @MilkingDate,
		   @Shift,
		   @Quantity,
		   @Comments)
END
GO
