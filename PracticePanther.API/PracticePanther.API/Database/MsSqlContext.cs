using PracticePanther.Library.Models;
using Microsoft.Data.SqlClient;

namespace PracticePanther.API.Database
{
    public class MsSqlContext
    {
        private MsSqlContext()
        {
            connectionString = "Server=MASONSLAPTOP;Database=PracticePanther_DB;Trusted_Connection=True;TrustServerCertificate=True";
        }

        private string connectionString;

        public Client Insert(Client c)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var sql = $"exec InsertClient @name = '{c.Name}'";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        var Id = (int)cmd.ExecuteScalar();
                        c.Id = Id;
                    }
                }
            } catch (Exception)
            {
                return c;
            }

            return c;
        }

        public List<Client> Get()
        {
            var results = new List<Client>();
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = "select id, name from Clients";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(new Client
                        {
                            Id = (int)reader[0],
                            Name = reader[1]?.ToString() ?? string.Empty
                        });
                    }
                }
            }

            return results;
        }

        private static MsSqlContext? instance;
        public static MsSqlContext Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new MsSqlContext();
                }
                return instance;
            }
        }
    }
}
