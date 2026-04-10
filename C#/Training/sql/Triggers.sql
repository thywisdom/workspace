use BikeStores;
GO


-- CREATE TABLE production.product_audits(
--     change_id int identity(1,1) PRIMARY KEY,
--     Product_id int NOT NULL,
--     Brand_id int NOT NULL,
--     Category_id int NOT NULL,
--     Model_year int NOT NULL,
--     List_price DEC(10,2) NOT NULL,
--     Updated_at DATETIME NOT NULL,
--     Operation char(3) NOT NULL,
--     CHECK(operation = 'INS' OR operation = 'DEL' )
-- )

-- CREATE TRIGGER production.trg_product_audits
-- ON production.products
-- AFTER INSERT,DELETE
-- AS
-- BEGIN
--         INSERT INTO production.product_audits(
--             Product_id,
--             Brand_id,
--             Category_id,
--             Model_year,
--             List_price,
--             Updated_at,
--             Operation
--         ) SELECT 
--         i.Product_id,
--         Brand_id,
--         Category_id,
--         Model_year,
--         List_price,
--         GETDATE(),
--         'INS'
--         from inserted as i

--         UNION ALL

--         SELECT 
--         d.Product_id,
--         Brand_id,
--         Category_id,
--         Model_year,
--         List_price,
--         GETDATE(),
--         'DEL'
--         from deleted as d
-- END

-- INSERT INTO production.products
-- VALUES (999, 1, 2, 2000,00.00);

-- SELECT * FROM production.product_audits;
-- DELETE FROM production.products WHERE Product_id = 325;

-- PRACTICE

-- CREATE TABLE sales.order_log (
--     log_id INT IDENTITY PRIMARY KEY,
--     order_id INT NOT NULL,
--     customer_id INT NOT NULL,
--     order_status TINYINT NOT NULL,
--     order_date DATE NOT NULL,
--     required_date DATE NOT NULL,
--     shipped_date DATE NOT NULL,
--     store_id INT NOT NULL,
--     staff_id INT NOT NULL,
--     log_timestamp DATETIME
-- )
-- GO



-- CREATE TRIGGER sales.trg_sales_order 
-- ON sales.orders
-- AFTER INSERT , UPDATE 
-- AS
-- BEGIN 
--     INSERT INTO sales.order_log (
--         order_id,
--         customer_id,
--         order_status,
--         order_date,
--         required_date,
--         shipped_date,
--         store_id,
--         staff_id,
--         log_timestamp
--     )
--     SELECT
--         i.order_id,
--         i.customer_id,
--         i.order_status,
--         i.order_date,
--         i.required_date,
--         i.shipped_date,
--         i.store_id,
--         i.staff_id,
--         GETDATE()
--     FROM inserted i;
-- END

-- INSERT INTO sales.orders (

--     customer_id,
--     order_status,
--     order_date,
--     required_date,
--     shipped_date,
--     store_id,
--     staff_id
-- )
-- VALUES (
         
--     1,              
--     1,              
--     '2026-02-12',  
--     '2026-02-20',   
--     '2026-02-15',   
--     1,              
--     1      
-- );

-- SELECT * 
-- FROM sales.order_log;


-- CREATE TABLE production.price_change_log (
--     log_id INT IDENTITY PRIMARY KEY,
--     product_id INT NOT NULL,
--     old_price DECIMAL(10,2) NOT NULL,
--     new_price DECIMAL(10,2) NOT NULL,
--     change_date DATETIME NOT NULL DEFAULT GETDATE()
-- );
-- GO

-- CREATE TRIGGER production.trg_track_price_changes
-- ON production.products
-- AFTER UPDATE
-- AS
-- BEGIN
--     SET NOCOUNT ON;

--     INSERT INTO production.price_change_log (
--         product_id,
--         old_price,
--         new_price,
--         change_date
--     )
--     SELECT
--         d.product_id,
--         d.list_price AS old_price,
--         i.list_price AS new_price,
--         GETDATE()
--     FROM inserted i
--     INNER JOIN deleted d
--         ON i.product_id = d.product_id
--     WHERE i.list_price <> d.list_price;
-- END;
-- GO

-- UPDATE production.products
-- SET list_price = list_price + 100
-- WHERE product_id = 1;

-- SELECT * 
-- FROM production.price_change_log
-- WHERE product_id = 1;

