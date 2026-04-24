using System.Data.SqlClient;

namespace EquipmentAccounting.Data
{
    public static class DbConnectionHelper
    {
        private static string connectionString =
            "Server=localhost;Database=EquipmentAccounting;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
