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