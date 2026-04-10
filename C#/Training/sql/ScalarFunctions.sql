use BikeStores;
GO

-- CREATE FUNCTION sales.udf_netsales (
--     @quantity INT,
--     @list_price DEC(10,2),
--     @discount DEC(10,2)
-- )
-- RETURNS DEC(10,2)
-- AS 
-- BEGIN 
--         RETURN (@quantity * @list_price * ( 1 - @discount));
-- END
-- GO 

-- SELECT sales.udf_netsales(1,100,0.2)

-- SELECT order_id , SUM(sales.udf_netsales(quantity,list_price,discount)) AS BillAmount FROM sales.order_items 
-- GROUP BY order_id 
-- ORDER BY order_id ASC ,
-- BillAmount DESC;

-- CREATE FUNCTION production.udf_getProductsByYear ( @Model_year  SMALLINT)
-- RETURNS TABLE
--         RETURN  SELECT * FROM production.products WHERE model_year = @Model_year
-- GO

-- SELECT * FROM production.udf_getProductsByYear(2017)
-- GO

-- DROP FUNCTION dbo.udf_getProductsByYear;

-- Practice Questions

-- CREATE FUNCTION sales.CalculateDiscountedPrice (
--     @list_price DEC(10,2),
--     @discount DEC(10,2)
-- )
-- RETURNS DEC(10,2)
-- AS 
-- BEGIN 
--         RETURN ( @list_price * ( 1 - @discount));
-- END

-- SELECT sales.CalculateDiscountedPrice(100,0.2)

-- CREATE FUNCTION sales.fn_FullCustomerName (
--     @First_Name VARCHAR(225),
--     @Last_Name VARCHAR(225)
-- )
-- RETURNS VARCHAR(450)
-- AS 
-- BEGIN 
--         RETURN CONCAT(@First_Name,' ', @Last_Name);
-- END

-- SELECT sales.fn_FullCustomerName('Suman','Ezhumalai')

-- CREATE FUNCTION sales.fn_CalculateTotalOrderAmount (
--     @Order_ID INT
-- )
-- RETURNS DECIMAL(10,2)
-- AS 
-- BEGIN 
--     RETURN (select SUM(quantity * list_price *(1 - discount)) FROM sales.order_items
--     WHERE order_id = @Order_ID )
-- END
-- GO

-- ALTER --- 

        -- CREATE FUNCTION sales.fn_CalculateTotalOrderAmount (
        --     @Order_ID INT
        -- )
        -- RETURNS DECIMAL(10,2)
        -- AS
        -- BEGIN
        --     RETURN (
        --         SELECT SUM(quantity * list_price * (1 - discount))
        --         FROM sales.order_items
        --         WHERE order_id = @Order_ID
        --     );
        -- END;
        -- GO

SELECT sales.fn_CalculateTotalOrderAmount (1001) AS TotalAmount;


