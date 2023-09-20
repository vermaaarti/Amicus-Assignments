/*drop table Clients_aarti;
drop table Departments_aarti;
drop table Employees_aarti;
drop table Projects_aarti;
drop table EmpProjectTasks_aarti;*/
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



	--6. display employee names ending with a

	/*SELECT Ename FROM Employees_aarti WHERE Ename LIKE '%a';*/



	--7. display the no. of months project 'inventory' took for completion

	/*SELECT DATEDIFF(MONTH, StartDate, ActualEndDate) AS MonthsToComplete FROM Projects_aarti WHERE Descr = 'Inventory';*/


	--8. display the task that is in progress

	/*SELECT Task FROM EmpProjectTasks_aarti WHERE Status = 'In Progress';*/



	--9. display details of departments located in pune

	/*SELECT * FROM Departments_aarti WHERE Loc = 'Pune';*/



	--10. display employee name and salary in descending order of salary

	/*SELECT Ename, Salary FROM Employees_aarti ORDER BY Salary DESC;*/



	 --11. display task in ascending order of end date

/*SELECT Task, EndDate FROM EmpProjectTasks_aarti ORDER BY EndDate ASC;*/



--12. display distinct jobs from Employees table

/*SELECT DISTINCT Job FROM Employees_aarti;*/



--13. display employee names in all uppercase

/*SELECT UPPER(Ename) AS UppercaseName FROM Employees_aarti;*/



--14. display employee name, salary and bonus calculated as 25% of salary

/*SELECT Ename, Salary, Salary * 0.25 AS Bonus FROM Employees_aarti;*/



--15. display concatenated string 'Employee works as job'(e.g. Manoj works as Develpoer) for all employees 

/*SELECT CONCAT(Ename, ' works as ', Job) AS EmployeeJob FROM Employees_aarti;*/



--16. Display day of week (e.g. Friday) for each start date of projects

/*SELECT StartDate, DATENAME(dw, StartDate) AS DayOfWeek FROM Projects_aarti;*/



--17. Display position number of '@' symbol in each email id of clients 

/*SELECT Email, CHARINDEX('@', Email) AS AtSymbolPosition FROM Clients_aarti;*/



--18. Display first 3 characters of each client name

/*SELECT LEFT(Cname, 3) AS FirstThreeCharacters FROM Clients_aarti;*/



--19. Display project budget values formatted as '$150,000'

/*SELECT CONCAT('$', FORMAT(Budget, 'N0')) AS FormattedBudget FROM Projects_aarti;*/



--20. Display planned end date and review date as 3 months after planned end date for each project

/*SELECT PlannedEndDate, DATEADD(MONTH, 3, PlannedEndDate) AS ReviewDate FROM Projects_aarti;*/










--1. Display count of client 

/*SELECT COUNT(*) AS ClientCount FROM Clients_aarti;*/



--2. Display count of employees and sum of their salaries

/*SELECT COUNT(*) AS EmployeeCount, SUM(Salary) AS TotalSalary FROM Employees_aarti;*/



--3. Display max salary per department

/*SELECT Deptno, MAX(Salary) AS MaxSalary FROM Employees_aarti GROUP BY Deptno;*/



--4. Display min salary per job

/*SELECT Job, MIN(Salary) AS MinSalary FROM Employees_aarti GROUP BY Job;*/



--5. Display average salary 

/*SELECT AVG(Salary) AS AverageSalary FROM Employees_aarti;*/



--6. Display sum of budget

/*SELECT SUM(Budget) AS TotalBudget FROM Projects_aarti;*/




--7. Display count of 'coding' task

/*SELECT COUNT(*) AS CodingTaskCount FROM EmpProjectTasks_aarti WHERE Task = 'Coding';*/




--8. Display department wise count and sum of salary of employees

/*SELECT Deptno, COUNT(*) AS EmployeeCount, SUM(Salary) AS TotalSalary FROM Employees_aarti GROUP BY Deptno;*/



--9. Display client names and their project desc, start date and budget

/*SELECT C.Cname AS ClientName, P.Descr AS ProjectDescription, P.StartDate, P.Budget FROM Clients_aarti AS C INNER JOIN Projects_aarti 
AS P ON C.ClientID = P.ClientID;*/



--10. Display department name, employee name and job

/*SELECT D.Dname AS DepartmentName, E.Ename AS EmployeeName, E.Job FROM Employees_aarti AS
E INNER JOIN Departments_aarti AS D ON E.Deptno = D.Deptno;*/



--11. Display names of employees doing 'System Analysis' along with project name

/*SELECT E.Ename AS EmployeeName, P.Descr AS ProjectName FROM Employees_aarti AS E
INNER JOIN EmpProjectTasks_aarti AS T ON E.Empno = T.Empno INNER JOIN Projects_aarti AS P ON T.ProjectID = P.ProjectID
WHERE T.Task = 'System Analysis';*/



--12. Display job wise count

/*SELECT Job, COUNT(*) AS JobCount FROM Employees_aarti GROUP BY Job;*/



--13. Display employee numbers not present in EmpProjectTasks table necessary set operator

/*SELECT Empno FROM Employees_aarti

EXCEPT

SELECT Empno FROM EmpProjectTasks_aarti;*/




--14. Display employee numbers present in both Employees and EmpProjectTasks table using necessary set operator

/*SELECT Empno FROM Employees_aarti

INTERSECT

SELECT Empno FROM EmpProjectTasks_aarti;*/



--15. Display all employee numbers present in both Employees and EmpProjectTasks table using necessary set operator

/*SELECT E.Empno FROM Employees_aarti AS E INNER JOIN EmpProjectTasks_aarti AS T ON E.Empno = T.Empno;*/



























--1. Display the project name with highest budget

/*SELECT Descr AS ProjectName FROM Projects_aarti WHERE Budget = (SELECT MAX(Budget) FROM Projects_aarti);*/





--2. Display employee names who have the same job as Madhav

/*SELECT Ename FROM Employees_aarti WHERE Job = (SELECT Job FROM Employees_aarti WHERE Ename = 'Madhav');*/




--3. Display employee's name and job who worked on 'Code Change' task of project 401

/*SELECT E.Ename, E.Job
FROM Employees_aarti AS E INNER JOIN EmpProjectTasks_aarti AS T ON E.Empno = T.Empno 
WHERE T.ProjectID = 401 AND T.Task = 'Code Change';*/




--4. Display client name whose project's 'Coding' task is 'in progress' 

/*SELECT C.Cname FROM Clients_aarti AS C 
INNER JOIN Projects_aarti AS P ON C.ClientID = P.ClientID
INNER JOIN EmpProjectTasks_aarti AS T ON P.ProjectID = T.ProjectID
WHERE T.Task = 'Coding' AND T.Status = 'In Progress';*/




--5. Display department number, names and salaries of employees who are earning max salary in their departments

/*SELECT D.Deptno, D.Dname, E.Ename, E.Salary
FROM Departments_aarti AS D
INNER JOIN Employees_aarti AS E ON D.Deptno = E.Deptno
WHERE E.Salary = (
    SELECT MAX(Salary)
    FROM Employees_aarti AS E2
    WHERE E2.Deptno = D.Deptno
);
*/










--6. Display name of department with highest SUM of salary

/*SELECT D.Dname FROM Departments_aarti AS D
INNER JOIN (
    SELECT Deptno, SUM(Salary) AS TotalSalary
    FROM Employees_aarti
    GROUP BY Deptno
    HAVING SUM(Salary) = (
        SELECT MAX(TotalSalary)
        FROM (
            SELECT Deptno, SUM(Salary) AS TotalSalary
            FROM Employees_aarti
            GROUP BY Deptno
        ) AS Subquery
    )
) AS MaxSalaryDept ON D.Deptno = MaxSalaryDept.Deptno;*/




--7. Create a table named 'CLIENT_PROJECTS' using CTAS method that includes CLIENT_ID, CNAME, ADDRESS, BUSINESS, DESCR, 
--BUDGET columns from CLIENTS and PROJECTS table

/*CREATE TABLE CLIENT_PROJECTS_aartiv (
    CLIENT_ID INT,
    CNAME VARCHAR(40),
    ADDRESS VARCHAR(30),
    BUSINESS VARCHAR(20),
    DESCR VARCHAR(30),
    BUDGET BIGINT
);*/

-- first execute the above code then the below 

/*INSERT INTO CLIENT_PROJECTS_aartiv (CLIENT_ID, CNAME, ADDRESS, BUSINESS, DESCR, BUDGET)
SELECT
    C.ClientID,
    C.Cname,
    C.Address,
    C.Business,
    P.Descr,
    P.Budget
FROM Clients_aarti AS C
INNER JOIN Projects_aarti AS P ON C.ClientID = P.ClientID;*/





--8. increase salary of employees by 15% who have performed task of 'Testing' on projects

/*UPDATE Employees_aarti SET Salary = Salary * 1.15
WHERE Empno IN (
    SELECT DISTINCT E.Empno
    FROM Employees_aarti AS E
    INNER JOIN EmpProjectTasks_aarti AS T ON E.Empno = T.Empno
    WHERE T.Task = 'Testing'
);*/



--9. Create a view named DEPT_EMP with DEPTNO, DNAME, LOC, ENAME, JOB and SALARY columns

/*CREATE VIEW DEPT_EMP_aarti AS
SELECT
    D.Deptno,
    D.Dname,
    D.Loc,
    E.Ename,
    E.Job,
    E.Salary
FROM Departments_aarti AS D
INNER JOIN Employees_aarti AS E ON D.Deptno = E.Deptno;*/







--- procedure

--CREATE PROCEDURE newProcudure  @Firstname varchar(255)
--AS
--BEGIN
--SELECT LastName FROM Person_aarti WHERE FirstName = @Firstname
--END;

--execute fullname terri













