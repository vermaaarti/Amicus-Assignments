

/*CREATE TABLE Clients_aarti(

ClientID INT CHECK(ClientID>0 and ClientID<=9999) NOT NULL Primary Key,

Cname VARCHAR(40) NOT NULL,

Address VARCHAR(30),

Email VARCHAR(30) Unique,

Phone BIGINT CHECK(Phone>=1000000000 and phone<=9999999999),

Business VARCHAR(20) NOT NULL 

);*/



/*CREATE TABLE Departments_aarti(

Deptno INT CHECK(Deptno>=1 and Deptno<=99) NOT NULL Primary Key,

Dname VARCHAR(15) NOT NULL,

Loc VARCHAR(20)

);*/



/*CREATE TABLE Employees_aarti(

Empno INT CHECK(Empno>0 and Empno<=9999) NOT NULL Primary Key,

Ename VARCHAR(20) NOT NULL,

Job VARCHAR(15),

Salary INT CHECK(Salary>0 and Salary<=9999999),

Deptno INT CHECK(Deptno>0 and Deptno<=99)Foreign Key REFERENCES Departments_aarti(Deptno) 

);*/




/*CREATE TABLE Projects_aarti(

ProjectID INT CHECK(ProjectID>0 and ProjectID<=999) NOT NULL Primary Key,

Descr VARCHAR(30) NOT NULL,

StartDate DATE,

PlannedEndDate DATE,

ActualEndDate DATE ,

Budget BIGINT CHECK(budget>0 and Budget <9999999999),

ClientID INT CHECK(ClientID>0 and ClientID<=9999) Foreign Key REFERENCES Clients_aarti( ClientID),

 

CONSTRAINT CHECKENDDATE_aarti CHECK(ActualEndDate>PlannedEndDate)

);*/



/*CREATE TABLE EmpProjectTasks_aarti

(

ProjectID INT CHECK(ProjectID >0 and ProjectID<=999 )NOT NULL,

Empno INT CHECK (Empno >0 and Empno <=9999) NOT NULL,

StartDate DATE,

EndDate DATE,

Task VARCHAR(25) NOT NULL,

Status VARCHAR(15) NOT NULL,

Primary Key(ProjectID, Empno),

Foreign Key(ProjectID) REFERENCES Projects_aarti(ProjectID),

Foreign Key(Empno) REFERENCES Employees_aarti(Empno)

);
*/

-- Inserting data into the Clients table
/*INSERT INTO Clients_aarti (ClientID, Cname, Address, Email, Phone, Business)
VALUES
    (1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', '9567880032', 'Manufacturing'),
    (1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', '8734210090', 'Consultant'),
    (1003, 'MoneySaver', 'Kolkata', 'save@moneysaver.co', '7799886655', 'Reseller'),
    (1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', '9210342219', 'Professional');*/


	/*INSERT INTO Employees_aarti (Empno, Ename, Job, Salary, Deptno)
	VALUES 	
	(7001, 'Sandeep', 'Analyst', 25000, 10),   
	(7002, 'Rajesh', 'Designer', 30000, 10),    
	(7003, 'Madhav', 'Developer', 40000, 20), 
	(7004, 'Manoj', 'Developer', 40000, 20),  
	(7005, 'Abhay', 'Designer', 35000, 10),  
	(7006, 'Uma', 'Tester', 30000, 30),    
	(7007, 'Gita', 'Tech. Writer', 30000, 40),   
	(7008, 'Priya', 'Tester', 35000, 30),  
	(7009, 'Nutan', 'Developer', 45000, 20),   
	(7010, 'Smita', 'Analyst', 20000, 10),   
	(7011, 'Anand', 'Project Mgr', 65000, 10);
	*/

	
/*	INSERT INTO Departments_aarti (Deptno, Dname, Loc)

VALUES
    (10, 'Design', 'Pune'),

    (20, 'Development', 'Pune'),

    (30, 'Testing', 'Mumbai'),

    (40, 'Document', 'Mumbai');  */


/*INSERT INTO Projects_aarti (ProjectID, Descr, StartDate, PlannedEndDate, ActualEndDate, Budget, ClientID)

VALUES

    (401, 'Inventory', '2011-04-01', '2011-10-01', '2011-10-31', 150000, 1001),

    (402, 'Accounting', '2011-08-01', '2012-01-01', NULL, 500000, 1002),

    (403, 'Payroll', '2011-10-01', '2011-12-31', NULL, 75000, 1003),

    (404, 'Contact Mgmt', '2011-11-01', '2011-12-31', NULL, 50000, 1004);  */



	/*INSERT INTO EmpProjectTasks_aarti (ProjectID, Empno, StartDate, EndDate, Task, Status)

VALUES

    (401, 7001, '2011-04-01', '2011-04-20', 'System Analysis', 'Completed'),

    (401, 7002, '2011-04-21', '2011-05-30', 'System Design', 'Completed'),

    (401, 7003, '2011-06-01', '2011-07-15', 'Coding', 'Completed'),

    (401, 7004, '2011-07-18', '2011-09-01', 'Coding', 'Completed'),

    (401, 7006, '2011-09-03', '2011-09-15', 'Testing', 'Completed'),

    (401, 7009, '2011-09-18', '2011-10-05', 'Code Change', 'Completed'),

    (401, 7008, '2011-10-06', '2011-10-16', 'Testing', 'Completed'),

    (401, 7007, '2011-10-06', '2011-10-22', 'Documentation', 'Completed'),

    (401, 7011, '2011-10-22', '2011-10-31', 'Sign off', 'Completed'),

    (402, 7010, '2011-08-01', '2011-08-20', 'System Analysis', 'Completed'),

    (402, 7002, '2011-08-22', '2011-09-30', 'System Design', 'Completed'),

    (402, 7004, '2011-10-01', NULL, 'Coding', 'In Progress');   */


--1.  To retrieve customer details with "Business" as "Consultant" from the "Clients_aarti" table

	/*SELECT * FROM Clients_aarti WHERE Business = 'Consultant';*/



--2. display employee details who are not developers

	/*SELECT * FROM Employees_aarti WHERE Job <> 'Developer';*/



	--3. display project details with budget >100000

	/*SELECT * FROM Projects_aarti WHERE Budget > 100000;*/



	--4. display details of projects that are already finished

	/*SELECT * FROM Projects_aarti WHERE ActualEndDate IS NOT NULL;*/




	--5. display employee names beginning with M

	/*SELECT Ename FROM Employees_aarti WHERE Ename LIKE 'M%';*/



	--6. display employee names ending with Ename

	/*SELECT FROM Employees_aarti a WHERE Ename LIKE '%a';*/


	--7. display the no. of months project 'inventory' took for completion

	/*SELECT DATEDIFF(MONTH, StartDate, ActualEndDate) AS MonthsToComplete FROM Projects_aarti WHERE Descr = 'Inventory';*/


	--8. 











