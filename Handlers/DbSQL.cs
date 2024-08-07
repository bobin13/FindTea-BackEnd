using Npgsql;

namespace FindTeaBackEnd.Handlers
{
    public class DbSQL
    {
        string connString = "Host=localhost;Username=postgres;Password=;Database=tims";
        public NpgsqlConnection GetConnection()
        {
            using (var conn = new NpgsqlConnection())
            {
                conn.Open();
                return conn;
            }
        }

        public void CloseConnection(NpgsqlConnection conn)
        {
            conn.Close();
        }
        public string GetStoresByCity(string cityQuery)
        {

            using (var conn = new NpgsqlConnection(connString))
            {
                string query = "SELECT * FROM stores WHERE stores.city = @city";
                string result = "";
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("city", cityQuery);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string storeName = reader.GetString(1);
                            string city = reader.GetString(2);
                            Console.WriteLine($"ID: {id}, Name: {storeName}, City: {city}");
                            result += $"ID: {id}, Name: {storeName}, City: {city}\n";
                        }
                    }

                }

                return result;
            }
        }
    }
}