using Npgsql;

namespace WinFormsApp.Db
{
    public static class Database
    {
        private static string connString = "Host =localhost;Port =5432;Username=farhan;Password=6yLwsk85;Database=Mbok_Wo_Reserve";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connString);
        }
    }
}