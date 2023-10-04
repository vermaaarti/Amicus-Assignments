/*CREATE TABLE DepartmentMaster_aarti(
DepartmentMasterId  INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
DepartmentName  NVARCHAR(20) CHECK (DepartmentName IN ('IT', 'Finance', 'HR')),
);*/

 
 --select * from DepartmentMaster_aarti;


/*CREATE TABLE EmployeeMaster_aarti(
EmployeeId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
EmployeeName NVARCHAR(500),
DepartmentId INT,
FOREIGN KEY (DepartmentId) REFERENCES DepartmentMaster_aarti(DepartmentMasterId)
);*/

 --select * from EmployeeMaster_aarti


/*CREATE TABLE SalaryInformation_aarti(
SalaryInformatonId  INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
EmployeeId INT,
AmountPerYear DECIMAL(10,2),
FOREIGN KEY (EmployeeId) REFERENCES EmployeeMaster_aarti(EmployeeId)
);
*/

--select * from SalaryInformation_aarti
 

/*INSERT INTO SalaryInformation_aarti(EmployeeId, AmountPerYear)
VALUES 
(1, 30000),
(2, 40000),
(3, 50000)*/

 

/*INSERT INTO EmployeeMaster_aarti(EmployeeName,DepartmentId)
VALUES
('John',1),
('Sue',2),
('Mosh',3)*/

 

/*INSERT INTO SalaryInformation_Shivam(EmployeeId, AmountPerYear)
VALUES 
(1, 200),
(2, 300),
(3, 500)*/