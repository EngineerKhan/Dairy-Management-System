USE [DairyDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_AnimalStatus_ID]    Script Date: 05/16/2015 15:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Talha Irfan>
-- Create date: <18/03/2015 - 8PM>
-- Description:	<Select FILTERED Expenses>
-- =============================================
CREATE PROCEDURE [dbo].[sp_select_AnimalStatus_ID]

@Desc varchar(50),
@IsMilk varchar(1),
@IsFemale varchar(1)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--	 END

    -- Insert statements for procedure here
	--SELECT @TotalQuery = 
	SELECT ID
  FROM [dbo].[ANIMAL_STATUS] 
	WHERE Description = @Desc
	AND IsMilking = @IsMilk
	AND IsFemale = @IsFemale
	AND IsCalf = 'N'
 -- WHERE ' + @Column + ' LIKE ''%'+@QueryString+'%'''

  --EXEC(@TotalQuery)

END
GO
