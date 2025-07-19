-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mohiuddin, Rakibul
-- Create date: 03/09/2024
-- Description:	trg_product_audit
-- =============================================
CREATE TRIGGER dbo.trg_employee_audit ON  dbo.T_EMPLOYEE 
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO dbo.T_EMPLOYEE_AUDIT(
		   [id_employee_key]
		  ,[id_employee_ver]
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
    SELECT
         [id_employee_key]
		,[id_employee_ver]
		,[dtt_created]
		,[dtt_updated]
		,[tx_name]
		,[id_age]
		,[dt_date_of_birth]
		,[dec_salary]
		,[dt_join_date]
		,[tx_email]
		,[tx_phone_no]
    FROM
        inserted i
  --  UNION ALL
  --  SELECT
  --       [id_employee_key]
		--,(select count(*)+1 from T_EMPLOYEE where [id_employee_key]=i.id_employee_key) 
		--,[dtt_created]
		--,[dtt_updated]
		--,[tx_name]
		--,[id_age]
		--,[dt_date_of_birth]
		--,[dec_salary]
		--,[dt_join_date]
		--,[tx_email]
		--,[tx_phone_no]
  --  FROM
  --      deleted i
END
GO
