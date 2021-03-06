USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_insertCustomer]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 07-Jan, 8:40 AM
-- Description:	Adds/inserts Customer in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertCustomer] 
	-- Add the parameters for the stored procedure here
	@DairyID varchar (15),
	@Name varchar(50),
	@Address varchar(80),
	@ContactNo varchar(15),
	@CNIC_No varchar(15),
	@Reg_Date date

	--Commented 13 March - Talha
	--@Quantity float,
	--@Type int,
	--@PriceCategory int,
	--@Del_Time int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

INSERT INTO [dbo].[CUSTOMER]
           ([DairyID]
           ,[Name]
           ,[Address]
           ,[ContactNo]
           ,[CNIC_No]
		   ,[Reg_Date])
     VALUES
           (@DairyID,
           @Name,
           @Address,
           @ContactNo,
           @CNIC_No,
		   @Reg_Date)

SET NOCOUNT ON;

--Commented on March 13

--DECLARE @ID int;

--		   SELECT @ID = MAX(ID)
--		   FROM
--		   dbo.[CUSTOMER]

--INSERT INTO [dbo].[CUSTOMER_MILK_SPECS]
--           ([ID]
--           ,[Quantity]
--           ,[Type]
--           ,[Price_Category]
--		   ,[Time])

--     VALUES
--           (@ID,
--           @Quantity,
--           @Type,
--           @PriceCategory,
--		   @Del_Time)

END
GO
