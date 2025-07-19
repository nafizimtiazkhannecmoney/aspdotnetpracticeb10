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