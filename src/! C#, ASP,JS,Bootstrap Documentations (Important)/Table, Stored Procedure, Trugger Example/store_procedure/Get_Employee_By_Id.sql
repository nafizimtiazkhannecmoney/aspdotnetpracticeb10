-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE GetEmployeeById 
	-- Add the parameters for the stored procedure here
	@id int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
	   [id_employee_key] Name
      ,[dtt_created]  CreatedAt
      ,[dtt_updated] UpdatedAt
      ,[tx_name] Name
      ,[id_age] Age 
      ,[dt_date_of_birth] Date_Of_Birth
      ,[dec_salary] Salary
      ,[dt_join_date] Join_Date
      ,[tx_email] Email
      ,[tx_phone_no] Phone_No
	FROM [Employee_Db].[dbo].[T_EMPLOYEE] where [id_employee_key] = @id
END
GO
