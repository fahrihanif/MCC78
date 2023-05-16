using System.Data.SqlClient;

namespace BasicConnection.Context;

public class MyConnection
{
    private static readonly string connectionString =
        "Data Source=127.0.0.1,3333;Database=db_Emp;User Id=sa;Password=Database!2023;Integrated Security=False;Connect Timeout=30;Encrypt=False;";

    public static SqlConnection Get()
    {
        /*var connection = new SqlConnection(connectionString);
        try {
            connection.Open();
            Console.WriteLine("Connection Open!");
        }
        catch (Exception e){
            Console.WriteLine("Error in connection" + e.Message);
        }
        finally {
            connection.Close();
        }
        return connection;*/
        
        return new SqlConnection(connectionString);
    }
}