USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_insertCalfwithMotherandFather]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 05-Jan, 5:55 PM
-- Description:	Adds/inserts Animal in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertCalfwithMotherandFather] 
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
           @OtherDetails varchar(100),
		   @Mother int,
		   @Father int
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

--Added 02-Apr
DECLARE @Calf int

SELECT @Calf = scope_identity()


		   INSERT INTO [dbo].[CALF_PARENT]
           ([Calf]
           ,[Parent]
           ,[IsMother])
     VALUES
           (@Calf,
		   @Mother,
		   'Y')
		   
		   
		   INSERT INTO [dbo].[CALF_PARENT]
           ([Calf]
           ,[Parent]
           ,[IsMother])
     VALUES
           (@Calf,
		   @Father,
		   'N')
		   
		   
END
GO
