using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LinqToSqlJoinDemo
{

        public class BikeStoresContext : DbContext
{
        public DbSet<Order> Orders { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=localhost,1433;Initial Catalog=BikeStores;User ID=sa;Password=@dmin123;Encrypt=False;TrustServerCertificate=True;");
}


    class Program : BikeStoresContext
    {
        static void Main(string[] args)
        {
    

            using (BikeStoresContext db = new BikeStoresContext(connectionString))
            {
                // LINQ to SQL Join Query
                var query = from o in db.orders
                            join s in db.stores
                            on o.store_id equals s.store_id
                            select new
                            {
                                o.order_id,
                                o.order_date,
                                StoreName = s.store_name
                            };

                Console.WriteLine("Orders with Store Names:\n");

                foreach (var item in query)
                {
                    Console.WriteLine($"Order ID: {item.order_id}, " +
                                      $"Order Date: {item.order_date}, " +
                                      $"Store: {item.StoreName}");
                }
            }
        }
    }
}