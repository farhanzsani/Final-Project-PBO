using Npgsql;  // Untuk koneksi PostgreSQL
using WinFormsApp.Models;  // Untuk akses class User
using WinFormsApp.Db;  // Untuk akses fungsi Database.GetConnection

namespace WinFormsApp.Controllers
{
    public static class AuthController
    {
        public static User Login(string username, string password)
        {
            using var conn = Database.GetConnection();  // Ambil koneksi dari Utils/Database.cs
            conn.Open();
            string query = "SELECT id, username, role FROM users WHERE username = @u AND password_hash = crypt(@p, password_hash)";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("u", username);
            cmd.Parameters.AddWithValue("p", password);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Role = reader.GetString(2)
                };
            }
            return null;
        }
    }
}
