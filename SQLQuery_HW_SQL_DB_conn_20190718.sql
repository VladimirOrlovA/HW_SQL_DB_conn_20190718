--------------------------------------------------------------------------------------------------------------------
------------------------------------------ HW Zadanie_1563464011 2019-07-18 ----------------------------------------
--------------------------------------------------------------------------------------------------------------------

--�������� 3 ���������
 
--1. ������� �� Customer
--customer_id 
--first_name 
--last_name
--�� @gender

--2. �������� ����� ������ � Customer

--3. ������� �� Customer �� @customer_id


--------------------------------------------------------------------------------------------------------------------

CREATE PROC p_select_by_gender
(
	@gender nvarchar
)
AS
SELECT *
FROM Customer
WHERE gender = @gender

EXEC p_select_by_gender 'f'


--------------------------------------------------------------------------------------------------------------------

CREATE PROC p_insert_to_customer
(
	@first_name NVARCHAR(15),
	@last_name NVARCHAR(15),
	@email NVARCHAR(15),
	@password NVARCHAR(10),
	@address NVARCHAR(15),
	@phone NUMERIC,
	@gender NVARCHAR,
	@birthdate DATE,
	@reg_date DATE,
	@bonus_percent INT
)
AS
INSERT INTO Customer
VALUES
( 
	@first_name,
	@last_name,
	@email,
	@password,
	@address,
	@phone,
	@gender,
	@birthdate,
	@reg_date,
	@bonus_percent
)

EXEC p_insert_to_customer '�������', '�������', 'smirnov@mail.ru', 'qwerty1', '���������, 510 - 35', 87019548651, 'm', '1985-03-08', '2019-07-25', 10

--------------------------------------------------------------------------------------------------------------------

CREATE PROC p_delete_from_Customer_by_id
(
	@customer_id INT
)
AS
DELETE FROM Customer
WHERE customer_id = @customer_id

EXEC p_delete_from_Customer_by_id 20

SELECT * FROM Customer
--------------------------------------------------------------------------------------------------------------------