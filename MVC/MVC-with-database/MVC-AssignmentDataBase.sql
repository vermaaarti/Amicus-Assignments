/*create table EmployeeInfo_aarti (
ID int NOT NULL PRIMARY KEY, 
Name nvarchar(25) NOT NULL,
Age int, 
Address nvarchar(50),
PhoneNumber nvarchar(10)
);*/


/*insert into EmployeeInfo_aarti(ID, Name, Age, Address, PhoneNumber)
values
(1,'Aarti',23, 'Raipur', '1234567890'),
(2,'Arti',20, 'Raipur', '1234567890'),
(3,'Aarhti',25, 'Raipur', '1234567890')*/

/*create table OfficeInfo_aarti (
 Id int,
 EmployeeDepartment nvarchar(25),
 ManagerName nvarchar(25),
  ManagerDepartment nvarchar(25),
  foreign key(Id) references EmployeeInfo_aarti(ID)
);*/

/*insert into OfficeInfo_aarti(Id, EmployeeDepartment, ManagerName, ManagerDepartment)
values
(1,'IT', 'Ramesh', 'IT'),
(2,'CS', 'Ram', 'CS'),
(3,'DB', 'RameshBabu', 'DB')*/

/*drop table OfficeInfo_aarti;*/

/*drop table EmployeeInfo_aarti;*/

/*select * from EmployeeInfo_aarti;*/

/*select * from OfficeInfo_aarti;*/


-- creating stored procedure





/*EXEC getDetails @EmployeeID=1*/

/*CREATE PROCEDURE getEmployeeOfficeDetails @EmpID INT
  AS
  BEGIN
  Select * from EmployeeInfo_aarti  WHERE ID=@EmpId
  Select * from OfficeInfo_aarti  WHERE  Id = @EmpId
 
  END;*/
  

 /* EXEC getEmployeeOfficeDetails @EmpID=2*/