--GetById
CREATE PROC [DBO].[usp_Get_EmployeeById]
(
	@Id INT
)
AS
BEGIN
	SET NOCOUNT ON;
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
	FROM DBO.Employees WITH(NOLOCK)
	where [id_employee_key] = @id
END