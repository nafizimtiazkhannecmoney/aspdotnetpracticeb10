USE [Employee_Db]
GO
/****** Object:  StoredProcedure [dbo].[INS_Employee]    Script Date: 9/3/2024 6:16:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mohiuddin, Rakibul
-- Create date: 03/09/2024
-- Description:	Insert new employee
-- =============================================
ALTER PROCEDURE [dbo].[INS_Employee] 
	-- Add the parameters for the stored procedure here
	@Name varchar(30),
	@Age int,
	@Date_Of_Birth datetime,
	@Salary decimal(18,2),
	@Join_Date datetime,
	@Email varchar(30),
	@Phone_No varchar(14),
	@message int out
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.T_EMPLOYEE(
		   [id_employee_ver]
		  ,[dtt_created]
		  ,[dtt_updated]
		  ,[tx_name]
		  ,[id_age]
		  ,[dt_date_of_birth]
		  ,[dec_salary]
		  ,[dt_join_date]
		  ,[tx_email]
		  ,[tx_phone_no]
    )
    VALUES (     
		0
		,GETDATE()
		,null
		,@Name
		,@Age
		,@Date_Of_Birth
		,@Salary
		,@Join_Date
		,@Email
		,@Phone_No
	)
	set @message = SCOPE_IDENTITY()
END
