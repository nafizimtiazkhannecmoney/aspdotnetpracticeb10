/**
* Author:Mohiuddin
* Description:This table is created to store employee information.
* Create Date:03/09/2024
**/

DROP TABLE IF EXISTS T_ORDER;
CREATE TABLE T_ORDER (
	--id_employee_key				bigint IDENTITY(100000, 1)					NOT NULL,
	--id_employee_ver				int											NOT NULL,
	--dtt_created					datetime									NULL	, -- employe created date
	--dtt_updated					datetime									NULL	, -- employe updated date
	--tx_name						varchar(30)									NOT NULL,
	--id_age						int											NOT NULL,
	--dt_date_of_birth				datetime									NOT NULL,
	--dec_salary					decimal(18, 0)								NOT NULL,
	--dt_join_date					datetime									NOT NULL,
	--tx_email						varchar(30)									NOT NULL,
	--tx_phone_no					varchar(30)									NOT NULL

	 id_order_key			bigint IDENTITY(100000, 1)		NOT NULL
	,id_order_ver			int								NOT NULL	
	,BIC_SWIFT				varchar(20)						NULL
	,BankAccountNo			varchar(50)						NULL
	,BankAccountType		varchar(20)						NULL
	,BankBranchAddress		varchar(100)					NULL
	,BankBranchName			varchar(50)						NULL
	,BankBranchNo			varchar(20)						NULL
	,BankCity				varchar(50)						NULL
	,BankCode				varchar(20)						NULL
	,BankName				varchar(50)						NULL
	,BankRoutingCode		varchar(50)						NULL
	,BankRoutingType		varchar(30)						NULL
	,BeneAddress			varchar(255)					NULL
	,BeneAnswer				varchar(50)						NULL
	,BeneCellNo				varchar(20)						NULL
	,BeneCity				varchar(50)						NULL
	,BeneCountry			varchar(2)						NULL
	,BeneFirstName			varchar(50)						NULL
	,BeneID					int								NULL
	,BeneIDNo				varchar(50)						NULL
	,BeneIDType				varchar(50)						NULL
	,BeneLastName			varchar(50)						NULL
	,BeneLastName2			varchar(50)						NULL
	,BeneMessage			varchar(255)					NULL
	,BeneMiddleName			varchar(50)						NULL
	,BenePhoneNo			varchar(20)						NULL
	,BeneQuestion			varchar(20)						NULL
	,BeneState				varchar(20)						NULL
	,BeneTaxID				varchar(50)						NULL
	,BeneZipCode			varchar(20)						NULL
	,BenefciaryAmount		decimal(18,4)					NOT NULL
	,BenefciaryCurrency		varchar(3)						NOT NULL
	,CommissionAmount		decimal(18,4)					NOT NULL
	,CommissionCurrency		varchar(3)						NOT NULL
	,


	CONSTRAINT PK_T_ORDER PRIMARY KEY (id_order_key)
);

-- CREATE UNIQUE INDEX idx_txn_type(id_transaction_type_key) -- IN/OUT