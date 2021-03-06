USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_insertAnimalInsemnation]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 01-Apr
-- Description:	Adds/inserts Employee in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertAnimalInsemnation] 
	-- Add the parameters for the stored procedure here
	@Date datetime,
@Animal int,
		   @Comments varchar(100)
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Animal_Insemnation]
           ([Animal],
		   [Date]
           ,[Comments])
     VALUES
           (@Animal,
		   @Date,
		   @Comments)
END
GO
