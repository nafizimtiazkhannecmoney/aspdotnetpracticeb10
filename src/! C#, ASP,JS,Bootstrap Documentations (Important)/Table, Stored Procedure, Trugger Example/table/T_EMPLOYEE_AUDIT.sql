/**
* Author:Mohiuddin , Rakibul
* Description:This table is created to store employee information.
* Create Date:03/09/2024
**/

DROP TABLE IF EXISTS T_EMPLOYEE_AUDIT;
CREATE TABLE T_EMPLOYEE_AUDIT (
	id_employee_key				bigint										NOT NULL,
	id_employee_ver				int											NOT NULL,
	dtt_created					datetime									NULL	, -- employe created date
	dtt_updated					datetime									NULL	, -- employe updated date
    tx_name						varchar(30)									NOT NULL,
	id_age						int											NOT NULL,
	dt_date_of_birth			datetime									NOT NULL,
	dec_salary					decimal(18, 0)								NOT NULL,
	dt_join_date				datetime									NOT NULL,
	tx_email					varchar(30)									NOT NULL,
	tx_phone_no					varchar(30)									NOT NULL


);

-- CREATE UNIQUE INDEX idx_txn_type(id_transaction_type_key) -- IN/OUT

