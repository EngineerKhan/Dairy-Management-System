USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_insertEmployee]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 27-Dec, 7:55 PM
-- Description:	Adds/inserts Employee in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertEmployee] 
	-- Add the parameters for the stored procedure here
	@Name varchar(100),
	@FatherName varchar(100),
	@DateofBirth date,
	@JoiningDate date,
	@Salary int,
	@Role int,
	@Description varchar(500),
	@CurrentAddress varchar(200),
	@PermanentAddress varchar(200),
	@CNIC_No varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[EMPLOYEE]
           ([Name]
           ,[Father_Name]
           ,[DateofBirth]
           ,[JoiningDate]
           ,[Salary]
           ,[Role]
           ,[Description]
           ,[CurrentAddress]
           ,[PermanentAddress]
           ,[CNIC_No])
     VALUES
           (@Name, 
		   @FatherName, 
		   @DateofBirth,
		   @JoiningDate, 
		   @Salary,
		   @Role,
		   @Description,
		   @CurrentAddress,
		   @PermanentAddress,
		   @CNIC_No)
END
GO
