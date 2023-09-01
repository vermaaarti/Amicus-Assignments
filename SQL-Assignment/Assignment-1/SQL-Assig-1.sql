

/*2. Created Customers table and inserted the records by insert query.*/

 

CREATE TABLE Customers_aarti (

    CustomerID INT ,

    CustomerName VARCHAR(255),

    ContactName VARCHAR(255),

    AddressDetails VARCHAR(255),

    City VARCHAR(255),

    PostalCode VARCHAR(255),

    Country VARCHAR(255)

);

 



 

INSERT INTO Customers_aarti(CustomerID, CustomerName, ContactName, AddressDetails, City, PostalCode, Country)

VALUES

 (1,'Alfreds Futterkiste', 'Maria Anders', 'Obere Dtr. 57', 'Berlin', '12209', 'Germany'),
    

 (2,'Ana trujillo Emparadados', 'Ana Trujillo', 'Avda de la', 'Mexico', '05021', 'Mexico'),

 
 (3,'Antonio Moreno', 'Antonio Moreno', 'Mataderos 2312', 'Mexico', '05023', 'Mexico'),

 
 (4,'Around the Horn', 'Thomas Hardy', '120 Manover Sq.', 'London', 'WA1 1DP', 'UK'),
  

 (5,'Berglunds', 'Christina Berglund', 'Berguvsvagen 8', 'Lule', 'S958 22', 'Sweden'),

 
 (6,'Blauer See', 'Hanna Moos', 'Forsterstr, 57', 'Mannheim', '68306', 'Germany'),
  

 (7,'Blaundel pere', 'Frederick Citeaux', '24, place Kleiber', 'Strasbourg', '67000', 'France'),

 
 (8,'Bolido comidas', 'Martin Sommer', 'C/ Araquil, 67', 'Madrid', '28023', 'Spain'),
  

 (9,'Bon app', 'Laurence Lebihans', '12, rue des Bouchers', 'Marseille', '13308', 'France'),

 
 (10,'Bottom Dollar', 'Elizabeth Lincoln', '23 Tsawassen Blvd.', 'Tsawassen', 'T2F 8M4', 'Canada'),

 
 (11,'B s Beverages', 'Victoria Ashworth', 'Fauntleroy Circus', 'London', 'EC2 5NT', 'UK');

 

 

/*-- 3. SQL statement for selecting the "CustomerName" and "City" columns from the "Customers_aarti" table*/

 
SELECT CustomerName, City FROM Customers_aarti;

 

 

/*--  4. SQL Query to create a PRIMARY KEY constraint first we add not null constraint and then we make CustomerID primary Key*/

 ALTER TABLE Customers_aarti ALTER COLUMN CustomerID INT NOT NULL;
 
   /* execute one by one */

ALTER TABLE Customers_aarti ADD PRIMARY KEY (CustomerID);

 

 

/*-- 5. SQL statement to selects only the DISTINCT values from the "Country" column in the "Customers" table*/

 SELECT DISTINCT Country FROM Customers_aarti;

 

 

/*-- 6. SQL statement selects all the customers from the country "Mexico" from "Customers_aarti" table  */

SELECT * FROM Customers_aarti WHERE Country = 'Mexico';

 

/*-- 7. selects all customers from the "Customers_aarti" table, sorted by the "Country" column */
 

 SELECT * FROM Customers_aarti ORDER BY Country; 

 

/*-- 8. SQL statement that selects all fields from Customers where Country is "Germany" AND City is "Berlin" AND PostalCode is higher than 12000 */
  

SELECT * FROM Customers_aarti WHERE Country = 'Germany' AND City = 'Berlin' AND PostalCode > 12000; 

 

 

/*-- 9. SQL statement that selects all fields from Customers where either City is "Berlin"or CustomerName starts with the letter "G" or Country is "Norway" */
 

SELECT * FROM Customers_aarti WHERE City = 'Berlin' OR CustomerName LIKE 'G%' OR Country='Norway';

 

 

/*-- 10.SQL statement that Select all customers that either are from Spain or starts with either "G" or "R" */

 SELECT * FROM Customers_aarti WHERE Country='Spain' or Country LIKE '[GR]%';

 

 

/* 11. SQL statement that selects records whose Contact name contains a “a” */  

 
SELECT * FROM Customers_aarti WHERE LEN(ContactName) - LEN(REPLACE(ContactName, 'a', '')) = 1;

   

 
 

/*-- 12. SQL statement that lists the number of customers in each country, sorted by high to low*/

  
SELECT Country, COUNT(*) as CountValue from Customers_aarti GROUP BY Country ORDER BY CountValue DESC;

 

 

 

/*-- 13. SQL statement that creates a stored procedure named "SelectAllCustomers" that selects all records from the "Customers" table. */

  
CREATE PROCEDURE SelectAllCustomers_Aarti AS BEGIN SELECT * FROM Customers_aarti END;

 

 

 

/* 14. SQL statement that creates a stored procedure that selects Customers from a particular City from the "Customers" table*/

 

CREATE PROCEDURE GETCustomersViaCountry_Aarti

    @City VARCHAR(255)

AS

BEGIN 

SELECT * FROM Customers_aarti WHERE City=@City

END; 
 
 

/*-- 15. SQL query that creates a view that selects every customer in the "Customers_aarti" table */

  

CREATE VIEW CustomersFromBr AS 

SELECT *
FROM Customers_aarti
WHERE Country = 'Brazil';