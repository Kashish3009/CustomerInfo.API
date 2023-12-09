SET IDENTITY_INSERT Customers ON;

DECLARE @Counter INT = 1;

WHILE @Counter <= 100
BEGIN
    INSERT INTO Customers (CustomerID, FirstName, LastName, Email, PhoneNumber)
    VALUES
        (@Counter, 'FirstName' + CAST(@Counter AS VARCHAR(10)), 'LastName' + CAST(@Counter AS VARCHAR(10)),
         'email' + CAST(@Counter AS VARCHAR(10)) + '@example.com', '123-456-7890');

    SET @Counter = @Counter + 1;
END;

-- Turn OFF identity insert for the Customers table
SET IDENTITY_INSERT Customers OFF;

Select * from dbo.Customers