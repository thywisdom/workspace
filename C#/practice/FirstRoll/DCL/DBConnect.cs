using System;
using System.Data.SqlClient;

using Exceptions;

namespace DCL
{
    public static class DBconnnect
    {
        private static string connectionString =
         "Server=localhost,1433;Database=StudentDB;User Id=sa;Password=@dmin123";
    

    public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
            catch(SqlException ex)
            {
                throw new DatabaseConnectionException (
                    "Failed to connect to the database.",
                    ex
                );
            }
        }
    }
}