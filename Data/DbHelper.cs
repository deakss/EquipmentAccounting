using EquipmentAccounting.Data;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static EquipmentAccounting.Data.DbConnectionHelper;

public static class DbHelper
{
    public static DataTable ExecuteQuery(string query)
    {
        using (var conn = DbConnectionHelper.GetConnection())
        {
            conn.Open();

            using (var cmd = new SqlCommand(query, conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }

    public static int ExecuteNonQuery(string query)
    {
        using (var conn = DbConnectionHelper.GetConnection())
        {
            conn.Open();

            using (var cmd = new SqlCommand(query, conn))
            {
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public static object ExecuteScalar(string query)
    {
        using (var conn = DbConnectionHelper.GetConnection())
        {
            conn.Open();

            using (var cmd = new SqlCommand(query, conn))
            {
                return cmd.ExecuteScalar();
            }
        }
    }
}