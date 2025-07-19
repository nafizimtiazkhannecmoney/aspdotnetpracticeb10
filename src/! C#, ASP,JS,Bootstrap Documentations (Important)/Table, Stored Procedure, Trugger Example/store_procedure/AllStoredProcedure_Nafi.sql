--Read All Employees
ALTER PROC [DBO].[usp_Get_Employees]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		id_employee_key
		,dtt_created
		,dtt_updated
		,tx_name
		,id_age
		,dt_date_of_birth
		,dec_salary
		,dt_join_date
		,tx_email
		,tx_phone_no
	FROM DBO.Employees WITH(NOLOCK)
END



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


--Insert
CREATE PROC [DBO].[usp_Insert_Employee]
(
	@Name varchar(30),
	@Age int,
	@Date_Of_Birth datetime,
	@Salary decimal(18,2),
	@Join_Date datetime,
	@Email varchar(30),
	@Phone_No varchar(14),
	@message int out
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Employees(
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


--Update
ALTER PROC [DBO].[usp_Update_Employee]
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


--Delte
CREATE PROC [DBO].[usp_Delete_Employee]
(
	@Id    INT    
	
)
AS
BEGIN
	
	DELETE FROM DBO.Employees
	WHERE  [id_employee_key] = @Id
				
END






DROP TABLE IF EXISTS Employees;
CREATE TABLE [dbo].[Employees](
	 [id_employee_key] [int] 						IDENTITY(10000,1) NOT NULL,
	 [id_employee_ver] [int] 						NOT NULL,
	 [dtt_created] [datetime]						NULL,
	 [dtt_updated] [datetime] 					    NULL,
	 [tx_name] [VARCHAR](30) 						NOT NULL,
	 [id_age] [int]								    NOT NULL,
	 [dt_date_of_birth] [datetime]                  NOT NULL,
	 [dec_salary]  decimal(18, 0) 					NOT NULL,
	 [dt_join_date] [datetime]  					NOT NULL,
	 [tx_email] [VARCHAR](30) 						NOT NULL,
	 [tx_phone_no] [VARCHAR](30)					NOT NULL
	 
	CONSTRAINT [PK_Employees] PRIMARY KEY (id_employee_key)
);