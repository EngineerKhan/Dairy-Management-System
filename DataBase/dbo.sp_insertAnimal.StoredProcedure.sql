USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_insertAnimal]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 02-Jan, 5:55 PM
-- Description:	Adds/inserts Animal in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertAnimal] 
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
		   @IsCalf varchar(1),
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
		   ,[IsCalf]
           ,[OtherDetails])
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
		   @IsCalf,
           @OtherDetails)
END
GO
