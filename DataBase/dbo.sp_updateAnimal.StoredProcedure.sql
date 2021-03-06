USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_updateAnimal]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 02-Jan, 5:55 PM
-- Description:	Adds/inserts Animal in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_updateAnimal] 
	-- Add the parameters for the stored procedure here
	@TagNo varchar(30),
         @RegistrationDate date,
           @AnimalType int,
           @Gender int,
           @BirthDate date,
           @Weight float,
           @Height float,
           @Length float,
           @Width float,
           @Price int,
           @Source int,
           @Breed int,
           @Status int,
           @OtherDetails varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[ANIMAL]

	SET 
           [RegistrationDate]=@RegistrationDate
           ,[AnimalType]=@AnimalType
           ,[Gender]=@Gender
           ,[BirthDate]=@BirthDate
           ,[Weight]=@Weight
           ,[Height]=@Height
           ,[Length]=@Length
           ,[Width]=@Width
           ,[Price]=@Price
           ,[Source]=@Source
           ,[Breed]=@Breed
           ,[Status]=@Status
           ,[OtherDetails]=@OtherDetails

     WHERE TagNo = @TagNo
END
GO
