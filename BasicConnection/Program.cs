using System.Data;
using System.Data.SqlClient;

namespace BasicConnection;

public class Program
{
    private static readonly string connectionString =
        "Data Source=CAMOUFLY;Database=db_dts_mvc;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public static void Main()
    {
        /*SqlConnection connection = new SqlConnection(connectionString);

        try {
            connection.Open();
            Console.WriteLine("Connection opened successfully.");
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        } finally {
            connection.Close();
            Console.WriteLine("Connection closed successfully.");
        }*/

        var results = GetUniversities();
        foreach (var result in results) {
            Console.WriteLine("Id: " + result.Id);
            Console.WriteLine("Name: " + result.Name);
        }

        var university = new University();
        university.Name = "Universitas Negeri Jakarta";

        /*var result = InsertUniversity(university);
        if (result > 0) {
            Console.WriteLine("Insert success.");
        } else {
            Console.WriteLine("Insert failed.");
        }*/
    }

    // GET : Universities
    public static List<University> GetUniversities()
    {
        var universities = new List<University>();
        using SqlConnection connection = new SqlConnection(connectionString);
        try {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_universities";

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    var university = new University();
                    university.Id = reader.GetInt32(0);
                    university.Name = reader.GetString(1);

                    universities.Add(university);
                }

                return universities;
            }

        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        } finally {
            connection.Close();
        }
        return new List<University>();
    }

    // GET : Universities(5)


    // INSERT : Universities
    public static int InsertUniversity(University university)
    {
        int result = 0;
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try {
            // Command melakukan insert
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO tb_m_universities(name) VALUES (@name)";
            command.Transaction = transaction;

            // Membuat parameter
            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Size = 50;
            pName.Value = university.Name;

            // Menambahkan parameter ke command
            command.Parameters.Add(pName);

            // Menjalankan command
            result = command.ExecuteNonQuery();
            transaction.Commit();

            return result;

        } catch (Exception e) {
            transaction.Rollback();
        } finally {
            connection.Close();
        }

        return result;
    }

    // UPDATE : Universities(obj)


    // DELETE : Universities(5)
}
