use BikeStores;
GO

-- CREATE VIEW vw_ProductDetails
-- AS
--     SELECT   pd.product_name , bd.brand_name,  ct.category_name , pd.list_price
--             FROM production.brands as bd
--             INNER JOIN production.products as pd
--                ON bd.brand_id = pd.brand_id
--             INNER JOIN production.categories as ct 
--                ON pd.category_id = ct.category_id
-- GO
            
-- SELECT * FROM vw_ProductDetails ORDER BY product_name
-- GO


-- CREATE VIEW vw_CustomerDetails
-- AS
--     SELECT   o.order_id , o.order_date , CONCAT(c.first_name, ' ', c.last_name) as CustomerName, 
--              s.store_name , SUM(oi.quantity) AS TotalQuantity
--             FROM sales.orders as o
--             INNER JOIN sales.customers as c
--                ON o.customer_id = c.customer_id
--             INNER JOIN sales.stores as s
--                ON o.store_id = s.store_id
--             INNER JOIN sales.order_items as oi
--                 ON o.order_id = oi.order_id 
--             GROUP BY  o.order_id , o.order_date , c.first_name, c.last_name, 
--              s.store_name;
-- GO
            
-- SELECT * FROM vw_CustomerDetails --ORDER BY product_name
-- GO


-- CREATE VIEW  vw_StockStoreLevels
-- AS
--     SELECT st.store_name , pd.product_name , s.quantity FROM 
--     production.stocks as s
--     INNER JOIN production.products as pd 
--         ON s.product_id = pd.product_id
--     INNER JOIN sales.stores as st
--         ON s.store_id = st.store_id
-- GO

-- SELECT * FROM vw_StockStoreLevels ORDER BY store_name
-- GO

-- CREATE VIEW  vw_TopSellingProducts
-- AS
--     SELECT  pd.product_name , SUM(oi.quantity) as TotalQuantity,
--     SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS TotalSalesAmount
--     FROM sales.order_items as oi
--     INNER JOIN production.products as pd 
--         ON oi.product_id = pd.product_id
--     GROUP BY pd.product_name
-- GO

-- SELECT * FROM vw_TopSellingProducts ORDER BY TotalQuantity DESC
-- GO

CREATE VIEW  vw_OrderSummary
AS
    SELECT  o.order_date , COUNT(o.order_id) as orders ,
    SUM(oi.quantity) as TotalQuantity, SUM(oi.quantity * oi.list_price * ( 1 - oi.discount)) as TotalSalesAmount
    FROM sales.orders as o
    INNER JOIN sales.order_items as oi 
        ON o.order_id =oi.order_id 
   GROUP BY o.order_date
GO

SELECT * FROM vw_OrderSummary ORDER BY order_date ASC
GO

