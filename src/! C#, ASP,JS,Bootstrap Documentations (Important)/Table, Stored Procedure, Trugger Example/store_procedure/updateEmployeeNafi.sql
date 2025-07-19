--Update
CREATE PROC [DBO].[usp_Update_Employee]
(
	@Id int,
	@Name varchar(30),
	@Age int,
	@Date_Of_Birth datetime,
	@Salary decimal(18,2),
	@Join_Date datetime,
	@Email varchar(30),
	@Phone_No varchar(14)
)
AS
BEGIN
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	update dbo.Employees set 
	   [id_employee_ver] = [id_employee_ver]+1
      ,[dtt_updated] = GETDATE()
      ,[tx_name] = @Name
      ,[id_age] = @Age 
      ,[dt_date_of_birth] = @Date_Of_Birth
      ,[dec_salary] = @Salary
      ,[dt_join_date] = @Join_Date
      ,[tx_email] =  @Email
      ,[tx_phone_no] = @Phone_No
	FROM [NZWalksDb].[dbo].Employees where [id_employee_key] = @Id
END