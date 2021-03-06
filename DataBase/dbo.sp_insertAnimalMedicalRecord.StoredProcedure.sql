USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_insertAnimalMedicalRecord]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 08-Jan, 2:33 PM
-- Description:	Adds/inserts Employee in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertAnimalMedicalRecord] 
	-- Add the parameters for the stored procedure here
	@Date datetime,
           @Animal varchar(30),
           @Diagnosis varchar(50),
           @Treatment varchar(50),
           @Prognosis varchar(50)
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	INSERT INTO [dbo].[ANIMAL_MEDICAL_RECORD]
           ([Date]
           ,[Animal]
           ,[Diagnosis]
           ,[Treatment]
           ,[Prognosis])
     VALUES
           (@Date,
           @Animal,
           @Diagnosis,
           @Treatment,
           @Prognosis)

END
GO
