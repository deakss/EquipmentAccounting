using EquipmentAccounting.Helpers;
using EquipmentAccounting.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentAccounting.Services
{
    internal class AuthService
    {
        public User Login(string login, string password)
        {
            string hash = HashHelper.ComputeHash(password);

            string query = @"
        SELECT * FROM Users
        WHERE Login = @login AND PasswordHash = @hash";

            var parameters = new SqlParameter[]
            {
        new SqlParameter("@login", login),
        new SqlParameter("@hash", hash)
            };

            var table = DbHelper.ExecuteQuery(query, parameters);

            if (table.Rows.Count == 0)
                return null;

            var row = table.Rows[0];

            return new User
            {
                UserID = (int)row["UserID"],
                Login = row["Login"].ToString(),
                RoleID = (int)row["RoleID"],
                EmployeeID = row["EmployeeID"] as int?
            };
        }
    }
}
