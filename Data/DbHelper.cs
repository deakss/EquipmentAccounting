using EquipmentAccounting.Data;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static EquipmentAccounting.Data.DbConnectionHelper;

public static class DbHelper
{
    public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
    {
        using (var conn = DbConnectionHelper.GetConnection())
        {
            conn.Open();

            using (var cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                using (var adapter = new SqlDataAdapter(cmd))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }
    }

    public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
    {
        using (var conn = DbConnectionHelper.GetConnection())
        {
            conn.Open();

            using (var cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return cmd.ExecuteNonQuery();
            }
        }
    }

    public static object ExecuteScalar(string query, params SqlParameter[] parameters)
    {
        using (var conn = DbConnectionHelper.GetConnection())
        {
            conn.Open();

            using (var cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return cmd.ExecuteScalar();
            }
        }
    }
}