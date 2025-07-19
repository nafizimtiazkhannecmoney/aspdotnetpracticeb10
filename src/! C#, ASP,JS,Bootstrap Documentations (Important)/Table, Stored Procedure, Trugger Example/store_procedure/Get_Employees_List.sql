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
-- Author:		Mohiuddin, Rakibul
-- Create date: 03/09/2024
-- Description:	Get all employees as list
-- =============================================
CREATE PROCEDURE Get_Employees_List
	-- Add the parameters for the stored procedure here
	@Name varchar(30) = '',
	@Age int = 0,
	@Date_Of_Birth datetime = null,
	@Salary decimal(18,2) = 0,
	@Join_Date datetime = null,
	@Email varchar(30) = '',
	@Phone_No varchar(14) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [id_employee_key] Id
      ,[dtt_created]  CreatedAt
      ,[dtt_updated] UpdatedAt
      ,[tx_name] Name
      ,[id_age] Age 
      ,[dt_date_of_birth] Date_Of_Birth
      ,[dec_salary] Salary
      ,[dt_join_date] Join_Date
      ,[tx_email] Email
      ,[tx_phone_no] Phone_No
	FROM [Employee_Db].[dbo].[T_EMPLOYEE] 
	where 
	(isnull(tx_phone_no,'') = '' or tx_phone_no like  '%'+@Phone_No+'%')
	and (isnull(tx_name,'') = '' or tx_name like  '%'+@Name+'%')
	and (isnull([tx_email],'') = '' or [tx_email] like  '%'+@Email+'%')
	and isnull(id_age,0) = 0 and id_age = @Age

	end
GO
