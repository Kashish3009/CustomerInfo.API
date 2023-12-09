


-- Create a new database


CREATE DATABASE CustomerInformation;
GO

-- Use the newly created database
USE CustomerInformation;
GO

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(20)
);

-- Insert 100 sample records into Customers table
DECLARE @Counter INT = 1;
WHILE @Counter <= 100
BEGIN
    INSERT INTO Customers (CustomerID, FirstName, LastName, Email, PhoneNumber)
    VALUES
        (@Counter, 'FirstName' + CAST(@Counter AS VARCHAR(10)), 'LastName' + CAST(@Counter AS VARCHAR(10)),
         'email' + CAST(@Counter AS VARCHAR(10)) + '@example.com', '123-456-7890');

    SET @Counter = @Counter + 1;
END;

Select * from dbo.Customers