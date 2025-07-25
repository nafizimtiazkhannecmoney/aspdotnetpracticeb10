USE [Employee_Db]
GO
/****** Object:  StoredProcedure [dbo].[UPD_Employee]    Script Date: 9/3/2024 6:17:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mohiuddin, Rakibul
-- Create date: 03/09/2024
-- Description:	Update existing employee
-- =============================================
ALTER PROCEDURE [dbo].[UPD_Employee] 
	@Id int,
	@Name varchar(30),
	@Age int,
	@Date_Of_Birth datetime,
	@Salary decimal(18,2),
	@Join_Date datetime,
	@Email varchar(30),
	@Phone_No varchar(14)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update T_EMPLOYEE set 
	   [id_employee_ver] = [id_employee_ver]+1
      ,[dtt_updated] = GETDATE()
      ,[tx_name] = @Name
      ,[id_age] = @Age 
      ,[dt_date_of_birth] = @Date_Of_Birth
      ,[dec_salary] = @Salary
      ,[dt_join_date] = @Join_Date
      ,[tx_email] =  @Email
      ,[tx_phone_no] = @Phone_No
	FROM [Employee_Db].[dbo].[T_EMPLOYEE] where [id_employee_key] = @Id
END
