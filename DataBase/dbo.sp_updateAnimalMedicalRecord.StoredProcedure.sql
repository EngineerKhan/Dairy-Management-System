USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_updateAnimalMedicalRecord]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <12/03/2014 - 1:55PM>
-- Description:	<Update given Animal Medical Record>
-- =============================================
CREATE PROCEDURE [dbo].[sp_updateAnimalMedicalRecord]

@ID int,
@Date datetime,
@Animal int, --Must be changed later on
@Diagnosis varchar(50),
@Treatment varchar(50),
@Prognosis varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	UPDATE ANIMAL_MEDICAL_RECORD

	SET Date = @Date, Animal = @Animal, Diagnosis = @Diagnosis, Treatment = @Treatment, Prognosis = @Prognosis

	WHERE ID = @ID


END
GO
