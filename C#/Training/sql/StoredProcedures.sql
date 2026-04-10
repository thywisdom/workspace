use BikeStores;
GO

-- SELECT customer_id , city FROM sales.customers

-- CREATE PROCEDURE List_customers
-- AS
-- BEGIN 
--     SELECT customer_id , first_name , city FROM sales.customers WHERE city = 'New York'
-- END;

-- ALTER PROCEDURE List_customers(@city_name as VARCHAR(100))
-- AS
-- BEGIN 
--     SELECT customer_id , first_name , city FROM sales.customers WHERE city = @city_name;
-- END;

-- EXEC List_customers 'buffalo'
-- GO

-- CREATE PROCEDURE usp_GetProductsByCategory (@Category_ID as INT)
-- AS 
-- BEGIN
--         SELECT p.product_name, b.brand_name, p.list_price FROM production.products as p INNER JOiN production.brands as b
--         ON p.brand_id = b.brand_id where category_id = @Category_ID;
-- END

-- EXECUTE usp_GetProductsByCategory 6;

-- ALTER PROCEDURE usp_AddCustomer (
--     @First_name as VARCHAR(244), 
--     @Last_name as VARCHAR(244), 
--     @phone as VARCHAR(11), 
--     @Email as VARCHAR(244),
--     @Street as VARCHAR(244), 
--     @City as VARCHAR(100),
--     @State as VARCHAR(100),
--     @Zip_code as VARCHAR(6)
--     )
-- AS 
-- BEGIN
--         INSERT INTO sales.customers (first_name, last_name, phone, email, street, city, state, zip_code) 
--         VALUES (@First_Name, @Last_Name, @Phone, @Email, @Street, @City, @State, @Zip_code);
-- END

-- EXEC usp_AddCustomer
--     @First_Name = 'sample',
--     @Last_Name = 'name',
--     @Phone = '1234567890',
--     @Email = 'sample@example.com',
--     @Street = '123 Main St',
--     @City = 'New York',
--     @State = 'NY',
--     @Zip_code = '10001';

-- SELECT * from sales.customers
-- GO

-- CREATE PROCEDURE usp_UpdateProductStock (
--     @Store_ID as INT, @Product_ID as INT, @New_Stock_Quantity as INT
--     )
-- AS 
-- BEGIN
--         UPDATE production.stocks SET quantity = @New_Stock_Quantity WHERE store_id = @Store_ID AND product_id = @Product_ID;
-- END

-- EXECUTE usp_UpdateProductStock 1,1,50;
-- GO 

-- SELECT * FROM production.stocks;
-- GO

-- CREATE PROCEDURE usp_GetOrderDetails (@Order_ID as INT)
-- AS 
-- BEGIN
--     SELECT o.order_date,
--          c.first_name + ' ' + c.last_name AS customer_name,
--          s.store_name, p.product_name, oi.quantity,
--          oi.list_price
--     FROM sales.orders AS o 
--     INNER JOIN sales.customers AS c 
--             ON o.customer_id = c.customer_id
--     INNER JOIN sales.stores AS s
--             ON o.store_id = s.store_id 
--     INNER JOIN sales.order_items AS oi 
--             ON o.order_id = oi.order_id 
--     INNER JOIN production.products AS p 
--             ON oi.product_id = p.product_id 
--     WHERE o.order_id = @Order_ID
-- END

-- EXEC usp_GetOrderDetails 1001;

-- CREATE PROCEDURE usp_GetTotalSalesByStore (@StartDate DATE, @EndDate DATE)
-- AS 
-- BEGIN
--     SELECT s.store_name ,
--     SUM(oi.quantity * oi.list_price * (1- oi.discount) ) AS Total_Sales_Amount
    
--     FROM sales.orders AS o 
--     INNER JOIN sales.order_items as oi
--         ON o.order_id = oi.order_id
--     INNER JOIN sales.stores as s
--         ON o.store_id = s.store_id

--     WHERE  o.order_date BETWEEN @StartDate AND @EndDate
--     GROUP BY s.store_name;
-- END


EXECUTE usp_GetTotalSalesByStore '2016-12-01','2016-12-31';
GO

-- SELECT order_date FROM sales.orders;
