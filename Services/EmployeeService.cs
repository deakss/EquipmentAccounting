using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentAccounting.Data;
using EquipmentAccounting.Helpers;
using EquipmentAccounting.Models;

namespace EquipmentAccounting.Services
{
    public class EmployeeService
    {
        // Получаем всех пользователей -> возвращаем таблицу
        public DataTable GetUsers()
        {
            string query = @"
                SELECT 
                    u.UserID AS UserID,
                    u.Login,
                    u.RoleID,
                    r.Name AS RoleName,
                    u.EmployeeID,
                    e.FullName AS EmployeeName
                FROM Users u
                INNER JOIN Roles r ON u.RoleID = r.RoleID
                LEFT JOIN Employees e ON u.EmployeeID = e.EmployeeID
                ORDER BY u.Login";

            return DbHelper.ExecuteQuery(query);
        }

        // Добавляем нового пользователя -> хэшируем пароль
        public void AddUser(User user, string plainPassword)
        {
            string query = @"
                INSERT INTO Users (Login, PasswordHash, RoleID, EmployeeID)
                VALUES (@Login, @PasswordHash, @RoleID, @EmployeeID)";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@Login", user.Login),
                new SqlParameter("@PasswordHash", HashHelper.ComputeHash(plainPassword)),
                new SqlParameter("@RoleID", user.RoleID),
                new SqlParameter("@EmployeeID", (object)user.EmployeeID ?? DBNull.Value));
        }

        // Обновляем существующего пользователя
        public void UpdateUser(User user, string password)
        {
            string query;

            // если пароль НЕ введён — не меняем его
            if (string.IsNullOrWhiteSpace(password))
            {
                query = @"
            UPDATE Users
            SET Login = @Login,
                RoleID = @RoleID,
                EmployeeID = @EmployeeID
            WHERE UserID = @UserID";

                DbHelper.ExecuteNonQuery(query,
                    new SqlParameter("@UserID", user.UserID),
                    new SqlParameter("@Login", user.Login),
                    new SqlParameter("@RoleID", user.RoleID),
                    new SqlParameter("@EmployeeID", (object)user.EmployeeID ?? DBNull.Value)
                );
            }
            else
            {
                // если введён новый пароль — обновляем
                string hash = HashHelper.ComputeHash(password);

                query = @"
            UPDATE Users
            SET Login = @Login,
                PasswordHash = @PasswordHash,
                RoleID = @RoleID,
                EmployeeID = @EmployeeID
            WHERE UserID = @UserID";

                DbHelper.ExecuteNonQuery(query,
                    new SqlParameter("@UserID", user.UserID),
                    new SqlParameter("@Login", user.Login),
                    new SqlParameter("@PasswordHash", hash),
                    new SqlParameter("@RoleID", user.RoleID),
                    new SqlParameter("@EmployeeID", (object)user.EmployeeID ?? DBNull.Value)
                );
            }
        }

        // Удаляем пользователя по ID
        public void DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE UserID = @UserID";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@UserID", userId));
        }

        // Получаем всех сотрудников -> возвращаем таблицу
        public DataTable GetEmployees()
        {
            string query = @"
                SELECT 
                    e.EmployeeID,
                    e.FullName,
                    e.Position,
                    e.DepartmentID,
                    d.Name AS DepartmentName
                FROM Employees e
                INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
                ORDER BY e.FullName";

            return DbHelper.ExecuteQuery(query);
        }

        // Добавляем нового сотрудника
        public void AddEmployee(Employee employee)
        {
            string query = @"
                INSERT INTO Employees (FullName, Position, DepartmentID)
                VALUES (@FullName, @Position, @DepartmentID)";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@Position", (object)employee.Position ?? DBNull.Value),
                new SqlParameter("@DepartmentID", employee.DepartmentID));
        }

        // Обновляем существующего сотрудника
        public void UpdateEmployee(Employee employee)
        {
            string query = @"
                UPDATE Employees
                SET FullName = @FullName,
                    Position = @Position,
                    DepartmentID = @DepartmentID
                WHERE EmployeeID = @EmployeeID";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@EmployeeID", employee.EmployeeID),
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@Position", (object)employee.Position ?? DBNull.Value),
                new SqlParameter("@DepartmentID", employee.DepartmentID));
        }

        // Удаляем сотрудника по ID
        public void DeleteEmployee(int employeeId)
        {
            string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@EmployeeID", employeeId));
        }

        // Получаем все отделы -> возвращаем таблицу
        public DataTable GetDepartments()
        {
            string query = @"
                SELECT DepartmentID, Name
                FROM Departments
                ORDER BY Name";

            return DbHelper.ExecuteQuery(query);
        }

        // Добавляем новый отдел
        public void AddDepartment(Department department)
        {
            string query = @"
                INSERT INTO Departments (Name)
                VALUES (@Name)";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@Name", department.Name));
        }

        // Обновляем существующий отдел
        public void UpdateDepartment(Department department)
        {
            string query = @"
                UPDATE Departments
                SET Name = @Name
                WHERE DepartmentID = @DepartmentID";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@DepartmentID", department.DepartmentID),
                new SqlParameter("@Name", department.Name));
        }

        // Удаляем отдел по ID
        public void DeleteDepartment(int departmentId)
        {
            string query = "DELETE FROM Departments WHERE DepartmentID = @DepartmentID";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@DepartmentID", departmentId));
        }

        // Получаем все роли -> возвращаем таблицу
        public DataTable GetRoles()
        {
            string query = @"
                SELECT RoleID, Name
                FROM Roles
                ORDER BY Name";

            return DbHelper.ExecuteQuery(query);
        }

        // Добавляем новую роль
        public void AddRole(Role role)
        {
            string query = @"
                INSERT INTO Roles (Name)
                VALUES (@Name)";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@Name", role.Name));
        }

        // Обновляем существующую роль
        public void UpdateRole(Role role)
        {
            string query = @"
                UPDATE Roles
                SET Name = @Name
                WHERE RoleID = @RoleID";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@RoleID", role.RoleID),
                new SqlParameter("@Name", role.Name));
        }

        // Удаляем роль по ID
        public void DeleteRole(int roleId)
        {
            string query = "DELETE FROM Roles WHERE RoleID = @RoleID";

            DbHelper.ExecuteNonQuery(query,
                new SqlParameter("@RoleID", roleId));
        }
    }
}