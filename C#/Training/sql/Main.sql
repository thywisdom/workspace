use BikeStores;
GO

-- Select o.order_id, p.product_id, p.product_name, o.quantity, o.list_price
-- FROM sales.order_items as o 
-- INNER JOIN production.products as p
-- ON o.product_id = p.product_id
-- GO

-- SELECT c.customer_id, c.first_name, c.last_name, o.order_id
-- FROM sales.customers as c 
-- LEFT JOIN sales.orders as o 
-- ON c.customer_id = o.customer_id
-- GO

-- SELECT p.product_id, p.product_name, o.quantity, o.list_price
-- FROM sales.order_items as o
-- RIGHT JOIN production.products as p
-- ON o.product_id = p.product_id
-- GO

-- SELECT p.product_id, p.product_name, o.order_id, o.quantity
-- FROM sales.order_items as o 
-- FULL OUTER JOIN production.products as p
-- ON o.product_id = p.product_id
-- GO

-- SELECT * FROM sales.stores ; SELECT * FROM sales.staffs;
-- SELECT st.store_id, st.store_name, sf.staff_id, sf.first_name
-- FROM sales.stores as st
-- CROSS JOIN sales.staffs as sf
-- GO


-- SELECT  st.product_id , pd.product_name , oi.quantity
--             FROM production.stocks as st
--             INNER JOIN production.products as pd
--                ON st.product_id = pd.product_id
--             INNER JOIN sales.order_items as oi 
--                ON st.product_id = oi.product_id
--             WHERE st.store_id = 1 
--             ORDER BY pd.product_id ASC; 


-- sp_help 'sales.customers';