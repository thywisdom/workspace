use BikeStores;
GO

-- CREATE FUNCTION tfn_GetProductsByBrand( @Brand_ID INT)
-- RETURNS TABLE
-- AS
--    RETURN SELECT product_id  , product_name , category_id , list_price  FROM production.products WHERE brand_id = @Brand_ID

-- SELECT * 
-- FROM dbo.tfn_GetProductsByBrand(2);


-- CREATE FUNCTION tfn_GetOrdersByCustomers( @Customer_ID INT)
-- RETURNS TABLE
-- AS
--    RETURN SELECT order_id  , order_date , store_id , staff_id  FROM sales.orders WHERE Customer_id = @Customer_ID
-- GO

-- SELECT * 
-- FROM dbo.tfn_GetOrdersByCustomers(5);

ALTER FUNCTION sales.GetStockByStore( @Store_ID INT)
RETURNS TABLE
AS
   RETURN ( SELECT  st.product_id , pd.product_name , oi.quantity
            FROM production.stocks as st
            INNER JOIN production.products as pd
               ON st.product_id = pd.product_id
            INNER JOIN sales.order_items as oi 
               ON st.product_id = oi.product_id
            WHERE st.store_id = @Store_ID
            -- ORDER BY pd.product_id ASC  (seems like we acannot use ORDEY BY clauses in TableValued finctions )
         );
GO

SELECT * 
FROM sales.GetStockByStore(3) ORDER BY product_id ASC;


-- . Steps:
-- • Create a table-valued function named fn_GetStockByStore.
-- • The function should accept a store ID as an input parameter.
-- • Return a table containing product ID, product name, and quantity.