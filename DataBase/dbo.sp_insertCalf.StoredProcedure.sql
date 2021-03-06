USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_insertCalf]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 05-Jan, 5:55 PM
-- Description:	Adds/inserts Animal in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertCalf] 
	-- Add the parameters for the stored procedure here
	@TagNo varchar(30),
         @RegistrationDate date,
           @AnimalType int,
           @Gender varchar(1),
           @BirthDate date,
           @Weight float,
           @Height float,
           @Length float,
           @Width float,
           @Price int,
           @Source int,
           @Breed int,
           @Status int,
           @OtherDetails varchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[ANIMAL]
           ([TagNo]
           ,[RegistrationDate]
           ,[AnimalType]
           ,[Gender]
           ,[BirthDate]
           ,[Weight]
           ,[Height]
           ,[Length]
           ,[Width]
           ,[Price]
           ,[Source]
           ,[Breed]
           ,[Status]
           ,[OtherDetails]
		   ,[IsCalf])
     VALUES
           (@TagNo,
           @RegistrationDate,
           @AnimalType,
           @Gender,
           @BirthDate,
           @Weight,
           @Height,
           @Length,
           @Width,
           @Price,
           @Source,
           @Breed,
           @Status,
           @OtherDetails,
		   'Y')

----Added 02-Apr
--DECLARE @Calf int

--SELECT @Calf = scope_identity()

--IF(@Mother=0 AND @Father=0)

--		   INSERT INTO [dbo].[CALF_PARENT]
--           ([Calf]
--           ,[Mother]
--           ,[Father])
--     VALUES
--           (@Calf,
--		   @Mother,
--		   @Father)
		   
		   
END
GO
