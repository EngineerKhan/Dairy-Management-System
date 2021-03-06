USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_insertEmployeeAttendance]    Script Date: 04/04/2015 21:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Talha
-- Create date: 07-Jan, 9:25 AM
-- Description:	Adds/inserts Attendance of employees in Database
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertEmployeeAttendance] 
	-- Add the parameters for the stored procedure here
	@EmployeeID int,
         @AttendanceDate datetime,
		 @StatusID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[EMP_ATTENDANCE]
           ([Date]
           ,[Employee]
           ,[Status])
     VALUES
           (@AttendanceDate,
		   @EmployeeID,
		   @StatusID)
END
GO
