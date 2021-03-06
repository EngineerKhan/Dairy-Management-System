USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_updateAnimalStatus]    Script Date: 05/16/2015 15:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 02-Jan, 5:55 PM
-- Description:	Adds/inserts Animal in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_updateAnimalStatus] 
	-- Add the parameters for the stored procedure here
	@ID int,
	@NewStatus int,
	@Date date,
	@Comments varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[ANIMAL]
           
           SET status = @NewStatus
           WHERE ID = @ID
           
           
           INSERT INTO [dbo].[ANIMAL_STATUS_HISTORY]
           (Animal,Status,Date,Comments)
           VALUES
           (@ID,@NewStatus,@Date,@Comments)
           
           
END
GO
