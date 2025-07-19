

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