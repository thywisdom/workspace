USE BikeStores
GO

-- CREATE PROCEDURE usp_InsertCustomerWithExceptionHandling
--     @first_name NVARCHAR(255),
--     @last_name NVARCHAR(255),
--     @phone NVARCHAR(25) = NULL,
--     @email NVARCHAR(255),
--     @street NVARCHAR(255) = NULL,
--     @city NVARCHAR(50) = NULL,
--     @state NVARCHAR(25) = NULL,
--     @zip_code NVARCHAR(5) = NULL
-- AS
-- BEGIN
--     BEGIN TRY
--         INSERT INTO sales.customers (first_name, last_name, phone, email, street, city, state, zip_code)
--         VALUES (@first_name, @last_name, @phone, @email, @street, @city, @state, @zip_code);

--         PRINT 'Customer inserted successfully.';
--     END TRY

--     BEGIN CATCH
--         PRINT 'Error occurred: ' + ERROR_MESSAGE();
--     END CATCH
-- END;
-- GO

EXEC usp_InsertCustomerWithExceptionHandling
    @first_name = 'John',
    --@last_name = 'Doe',
    @phone = '123-456-7890',
    @email = 'john.doe@example.com',
    @street = '123 Main St',
    @city = 'Puducherry',
    @state = 'PY',
    @zip_code = '60500';
